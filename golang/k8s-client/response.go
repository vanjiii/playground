package client

type Response struct {
	Kind string

	ApiVersion string
	Metadata   RMetadata
	Status     string
	Message    string
	Reason     string
	Code       int
}

type RMetadata struct {
	Name string
}
