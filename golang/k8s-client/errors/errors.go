package errors

import (
	"errors"
	"fmt"
)

var (
	ErrBadRequest = errors.New("bad request")
)

type httpError struct {
	Err     error
	Code    int
	Message string
}

func New(e error, c int, m string) *httpError {
	return &httpError{
		Err:     e,
		Code:    c,
		Message: m,
	}
}

func (e httpError) Error() string {
	return fmt.Sprintf(
		"error: %s; code: %v; message: %s",
		e.Err.Error(),
		e.Code,
		e.Message,
	)
}
