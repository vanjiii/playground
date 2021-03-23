package client

import (
	"bytes"
	"crypto/tls"
	"crypto/x509"
	"encoding/json"
	"fmt"
	"io/ioutil"
	"log"
	"net/http"
	"net/url"
	stdpath "path"

	"github/vanjiii/go-client/errors"
)

// protocol://<ip>:<port>/api/<version>/namespace/<namespacename>/<obect>
// e.g. https://192.168.49.2:8443/api/v1/namespaces/default/services
const endpoint = "https://%s:%d/api/%s/namespaces/%s/%s"

type opt func(*path)

// New creates new instance of client. if certificates are not passed
// properly, it will terminate executable with os.Exit(1).
//
// By default sets
//   version: v1
//   namespace: default
func New(c Config, opts ...opt) *Client {
	clientcert, err := tls.LoadX509KeyPair(c.UCert, c.UKey)
	if err != nil {
		log.Fatal(err)
	}

	caCert, err := ioutil.ReadFile(c.CA)
	if err != nil {
		log.Fatal(err)
	}
	caCertPool := x509.NewCertPool()
	caCertPool.AppendCertsFromPEM(caCert)

	client := &http.Client{
		Transport: &http.Transport{
			TLSClientConfig: &tls.Config{
				RootCAs:      caCertPool,
				Certificates: []tls.Certificate{clientcert},
			},
		},
	}

	cl := Client{
		client: client,

		ip:   c.IP,
		port: c.Port,
		respath: path{
			version:   "v1",
			namespace: "default",
		},
	}

	return &cl
}

// Client for k8s api.
type Client struct {
	client *http.Client

	ip      string
	port    int
	respath path
}

type path struct {
	version   string
	namespace string
	object    string
}

// ForObject sets the object.
func ForObject(o string) opt {
	return func(p *path) {
		p.object = o
	}
}

// ForVersion sets the version.
func ForVersion(v string) opt {
	return func(p *path) {
		p.version = v
	}
}

// ForNamespace sets the namespace.
func ForNamespace(n string) opt {
	return func(p *path) {
		p.namespace = n
	}
}

func mustParseURI(port int, ip, v, n, obj string) *url.URL {
	rawurl := fmt.Sprintf(endpoint, ip, port, v, n, obj)

	var u, err = url.Parse(rawurl)
	if err != nil {
		panic(err)
	}
	return u
}

func (c *Client) constructurl(opts ...opt) *url.URL {
	path := c.respath

	for _, o := range opts {
		o(&path)
	}

	return mustParseURI(c.port, c.ip, path.version, path.namespace, path.object)
}

func (c *Client) List(opts ...opt) []Service {
	resp, err := c.client.Get(c.constructurl(opts...).String())
	if err != nil {
		log.Fatalf("fail to make request: %v", err)
		return nil
	}
	defer resp.Body.Close()

	var services struct {
		Kind  string
		Items []Service
	}

	if err := json.NewDecoder(resp.Body).Decode(&services); err != nil {
		log.Fatalf("fail to decode respose: %v", err)
		return nil
	}

	return services.Items
}

func (c *Client) Create(s Service, params Encoder, opts ...opt) error {
	bts, err := json.Marshal(s)
	if err != nil {
		return errors.New(err, http.StatusBadRequest, "")
	}

	u := c.constructurl(opts...)
	params.Encode(u)

	resp, err := c.client.Post(u.String(), "application/json", bytes.NewBuffer(bts))
	if err != nil {
		return errors.New(err, resp.StatusCode, "")
	}
	defer resp.Body.Close()

	return decodeError(resp)
}

func (c *Client) Delete(name string, params Encoder, opts ...opt) error {
	u := c.constructurl(opts...)
	u.Path = stdpath.Join(u.Path, name)
	params.Encode(u)

	req, err := http.NewRequest("DELETE", u.String(), nil)
	if err != nil {
		return errors.New(err, http.StatusBadRequest, "fail to create request")
	}

	resp, err := c.client.Do(req)
	if err != nil {
		return errors.New(err, http.StatusBadRequest, "request fails")
	}

	return decodeError(resp)
}

func (c *Client) Patch(sname string, serv Service, params Encoder, opts ...opt) error {
	bts, err := json.Marshal(serv)
	if err != nil {
		return errors.New(err, http.StatusBadRequest, "")
	}

	u := c.constructurl(opts...)
	u.Path = stdpath.Join(u.Path, sname)
	params.Encode(u)

	req, err := http.NewRequest("PATCH", u.String(), bytes.NewBuffer(bts))
	if err != nil {
		return errors.New(err, http.StatusBadRequest, "fail to create request")
	}

	req.Header.Set("Content-Type", "application/strategic-merge-patch+json")

	resp, err := c.client.Do(req)
	if err != nil {
		return errors.New(err, http.StatusBadRequest, "request fails")
	}
	defer resp.Body.Close()

	return decodeError(resp)
}

func (c *Client) PatchStatus(sname string, serv Service, params Encoder, opts ...opt) error {
	bts, err := json.Marshal(serv)
	if err != nil {
		return errors.New(err, http.StatusBadRequest, "")
	}

	u := c.constructurl(opts...)
	u.Path = stdpath.Join(u.Path, sname, "status")
	params.Encode(u)

	req, err := http.NewRequest("PATCH", u.String(), bytes.NewBuffer(bts))
	if err != nil {
		return errors.New(err, http.StatusBadRequest, "fail to create request")
	}

	req.Header.Set("Content-Type", "application/strategic-merge-patch+json")

	resp, err := c.client.Do(req)
	if err != nil {
		return errors.New(err, http.StatusBadRequest, "request fails")
	}
	defer resp.Body.Close()

	return decodeError(resp)
}

func decodeError(resp *http.Response) error {
	c := resp.StatusCode
	if c >= 200 && c <= 299 {
		return nil
	}

	var res Response
	if err := json.NewDecoder(resp.Body).Decode(&res); err != nil {
		return errors.New(err, resp.StatusCode, "fail to parse response")
	}

	return errors.New(
		errors.ErrBadRequest,
		res.Code,
		res.Message,
	)
}
