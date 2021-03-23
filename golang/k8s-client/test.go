package client

import (
	"os"
	pt "path"
	"testing"
)

type env struct {
	Config Config
}

func tenv(t *testing.T) *env {
	t.Helper()

	udir, err := os.UserHomeDir()
	if err != nil {
		t.Fatalf("cannot obtain user home dir: %v", err)
	}

	cfg := NewConfig(
		8443,
		"192.168.49.2",
		pt.Join(udir, ".minikube/profiles/minikube/client.key"),
		pt.Join(udir, ".minikube/profiles/minikube/client.crt"),
		pt.Join(udir, ".minikube/ca.crt"),
	)
	return &env{
		Config: cfg,
	}
}
