# go-client

A go client for k8s api

## Install
`go get github/vanjiii/go-client`

## Usage
- Create an instance with `client.New(cfg)`
- Make the desire request `cl.Create(...)`
  - you may decorate the request with needed properties; to see all possible decorating funcs exec `go doc github/vanjiii/go-client | grep For`
  - query parameters are passed with appropriate types;

For more complete example, see `client_test.go`
