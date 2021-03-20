package service

import (
	"testing"

	"github/vanjiii/golang/fndy/file"
	"github/vanjiii/golang/fndy/store"
)

// Env is environment object for initializing necessary dependencies.
type Env struct {
	FileHandler  file.Filer
	Downloadpath string
}

// NewEnv returns new instance of Env.
func NewEnv() (*Env, error) {
	db := store.NewDB()
	st := store.NewFile(db)
	path := "/tmp"

	f := file.New(st, path)

	return &Env{
		FileHandler:  f,
		Downloadpath: path,
	}, nil
}

func NewTestEnv(t *testing.T) *Env {
	return &Env{
		FileHandler:  nil,
		Downloadpath: "",
	}
}
