package http

import (
	"encoding/base64"
	"fmt"
	"net"
	"net/http"
	"runtime"
	"strings"
	"sync"
	"time"

	"github/vanjiii/golang/fndy/service"

	"github.com/gorilla/mux"
	log "github.com/sirupsen/logrus"
	"golang.org/x/time/rate"
)

// ServeMux creates a muxer defines from gorilla/mux.
//
// Here as well are define and all of the endpoints.
func ServeMux(env *service.Env) http.Handler {
	f := NewFile(env)

	muxer := mux.NewRouter()
	muxer.HandleFunc("/debug/ping", func(w http.ResponseWriter, _ *http.Request) {
		w.Header().Set("content-type", "text/plain")
		fmt.Fprintf(w, "version=%s\ngo=%s\n", "dev", runtime.Version())
	})

	muxer.HandleFunc("/download", f.download).
		Methods("GET").
		Queries("file_identifier", "{file_identifier}")

	muxer.HandleFunc("/bulkdownload", f.bulkdownload).
		Methods("GET").
		Queries("file_identifier", "{file_identifier}")

	muxer.HandleFunc("/search", f.search).
		Methods("GET")

	muxer.Use(loggingMiddleware)
	muxer.Use(throttle)
	muxer.Use(loginMiddleware)

	return muxer
}

func loggingMiddleware(next http.Handler) http.Handler {
	return http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
		log.WithFields(log.Fields{
			"uri": r.RequestURI,
		}).Info("middleware")
		next.ServeHTTP(w, r)
	})
}

// ip:limiter
var requests = new(sync.Map)

func throttle(next http.Handler) http.Handler {
	return http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
		ip, _, err := net.SplitHostPort(r.RemoteAddr)
		if err != nil {
			log.Println(err.Error())
			http.Error(w, "Internal Server Error", http.StatusInternalServerError)
			return
		}

		v, ok := requests.Load(ip)
		if !ok {
			// once per 20 seconds
			rt := rate.Every(20 * time.Second / 1)
			limiter := rate.NewLimiter(rt, 5)

			requests.Store(ip, limiter)
			v = limiter
		}

		ll := v.(*rate.Limiter)

		if ll.Allow() == false {
			http.Error(w, http.StatusText(http.StatusTooManyRequests), http.StatusTooManyRequests)
			return
		}
		next.ServeHTTP(w, r)
	})
}

func loginMiddleware(next http.Handler) http.Handler {
	return http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
		auth := strings.SplitN(r.Header.Get("Authorization"), " ", 2)

		if len(auth) != 2 || auth[0] != "Basic" {
			http.Error(w, "authorization failed", http.StatusUnauthorized)
			return
		}

		payload, _ := base64.StdEncoding.DecodeString(auth[1])
		pair := strings.SplitN(string(payload), ":", 2)

		if pair[0] != "user" || pair[1] != "secret123" {
			http.Error(w, "authorization failed", http.StatusUnauthorized)
			return
		}

		next.ServeHTTP(w, r)
	})
}
