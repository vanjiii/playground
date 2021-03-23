package client

import (
	"fmt"
	"net/url"
)

type Encoder interface {
	Encode(*url.URL)
}

type CreateParams struct {
	// If 'true', then the output is pretty printed.
	Pretty bool
	// All: all dry run stages will be processed
	DryRun string

	FieldManager string
}

func (p CreateParams) Encode(url *url.URL) {
	q := url.Query()
	q.Set("pretty", fmt.Sprintf("%v", p.Pretty))

	if p.DryRun != "" {
		q.Set("dryRun", p.DryRun)
	}

	if p.FieldManager != "" {
		q.Set("fieldManager", p.FieldManager)
	}

	url.RawQuery = q.Encode()
}

type DeleteParams struct {
	Pretty             bool
	DryRun             string
	GracePeriodSeconds int
	PropagationPolicy  PropagationPolicy
}

func (p DeleteParams) Encode(url *url.URL) {
	q := url.Query()

	q.Set("pretty", fmt.Sprintf("%v", p.Pretty))
	q.Set("gracePeriodSeconds", fmt.Sprintf("%v", p.GracePeriodSeconds))

	if p.DryRun != "" {
		q.Set("dryRun", p.DryRun)
	}

	if p.PropagationPolicy != PropagationPolicyUnkn {
		q.Set("propagationPolicy", p.PropagationPolicy.String())
	}

	url.RawQuery = q.Encode()
}

type PropagationPolicy uint8

const (
	PropagationPolicyUnkn PropagationPolicy = iota
	PropagationPolicyOrphan
	PropagationPolicyBackground
)

func (p PropagationPolicy) String() string {
	var s string
	switch p {
	default:
		s = "Unknown"
	case PropagationPolicyOrphan:
		s = "Orphan"
	case PropagationPolicyBackground:
		s = "Background"
	}

	return s
}

type PatchParam struct {
	Pretty       bool
	DryRun       string
	FieldManager string
	//Force        bool
}

func (p PatchParam) Encode(url *url.URL) {
	q := url.Query()
	q.Set("pretty", fmt.Sprintf("%v", p.Pretty))
	//q.Set("force", fmt.Sprintf("%v", p.Force))

	if p.DryRun != "" {
		q.Set("dryRun", p.DryRun)
	}

	if p.FieldManager != "" {
		q.Set("fieldManager", p.FieldManager)
	}

	url.RawQuery = q.Encode()
}
