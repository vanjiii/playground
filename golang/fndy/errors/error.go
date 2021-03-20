package errors

import "errors"

var (
	// ErrBadRequest is for general error handling
	ErrBadRequest = errors.New("bad request")

	// ErrUnauthorized is for authentication
	ErrUnauthorized = errors.New("unauthorized")
)

// Is is as it is from errors.Is
func Is(err, target error) bool { return errors.Is(err, target) }
