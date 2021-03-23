package client

import (
	"testing"
	"time"
)

func TestClient(t *testing.T) {
	env := tenv(t)
	cl := New(env.Config)

	// creation of a service
	crs := Service{
		Metadata: &ObjectMeta{
			Name: "new-test-service",
		},
		Spec: &ServiceSpec{
			Ports: []ServicePort{{Port: 123, Name: "https"}},
		},
	}

	if err := cl.Create(
		crs,
		CreateParams{Pretty: true},
		ForObject("services"),
	); err != nil {
		t.Fatalf("post fails with: %v", err)
	}

	if s := getSer(cl.List, crs.Metadata.Name); s.Metadata.Name != crs.Metadata.Name {
		t.Fatalf("exp name: %v, got: %v", crs.Metadata.Name, s.Metadata.Name)
	}

	// patch a service
	ps := Service{
		Spec: &ServiceSpec{
			Ports: []ServicePort{
				{Port: 80, TargetPort: 8080, Name: "http"}},
		},
	}

	err := cl.Patch(
		crs.Metadata.Name,
		ps,
		PatchParam{},
		ForNamespace("default"),
		ForVersion("v1"),
		ForObject("services"),
	)
	if err != nil {
		t.Fatalf("patch fails with: %v", err)
	}

	if s := getSer(cl.List, crs.Metadata.Name); s.Spec.Ports[0].Name != ps.Spec.Ports[0].Name {
		t.Fatalf("exp port name to be: %v, got: %v", ps.Spec.Ports[0].Name, s.Spec.Ports[0].Name)
	}

	// patch service's status
	pss := Service{
		Status: &ServiceStatus{
			Conditions: []Condition{
				{
					LastTransitionTime: time.Now(),
					Message:            "new message",
					Reason:             "testing reason",
					Status:             "stat",
					Type:               "tp",
				},
			},
		},
	}

	err = cl.PatchStatus(
		crs.Metadata.Name,
		pss,
		PatchParam{},
		ForNamespace("default"),
		ForVersion("v1"),
		ForObject("services"),
	)

	if err != nil {
		t.Fatalf("patch status fails: %v", err)
	}

	if s := getSer(cl.List, crs.Metadata.Name); s.Status.Conditions[0].Message != pss.Status.Conditions[0].Message {
		t.Fatalf("exp cond msg to be: %v, got: %v", pss.Status.Conditions[0].Message, s.Status.Conditions[0].Message)
	}

	// delete a service
	err = cl.Delete(
		crs.Metadata.Name,
		DeleteParams{GracePeriodSeconds: 0},
		ForObject("services"),
	)

	if err != nil {
		t.Fatalf("delete service fails: %v", err)
	}

	if s := getSer(cl.List, crs.Metadata.Name); s.Metadata != nil {
		t.Fatalf("exp name to be: %v, got: %v", nil, s)
	}

}

func getSer(list func(opts ...opt) []Service, name string) Service {
	servs := list(ForObject("services"))
	var res Service

	for _, v := range servs {
		if v.Metadata.Name == name {
			res = v
		}
	}

	return res
}
