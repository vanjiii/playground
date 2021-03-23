package client

import (
	"encoding/json"
	"time"
)

type Service struct {
	Metadata *ObjectMeta    `json:"metadata,omitempty"`
	Spec     *ServiceSpec   `json:"spec,omitempty"`
	Status   *ServiceStatus `json:"status,omitempty"`
}

type ObjectMeta struct {
	Name            string            `json:"name,omitempty"`
	Namespace       string            `json:"namespace,omitempty"`
	Labels          map[string]string `json:"labels,omitempty"`
	Annotations     map[string]string `json:"annotations,omitempty"`
	ResourceVersion string            `json:"resourceVersion,omitempty"`
	Generation      int64             `json:"generation,omitempty"`
}

type ServiceSpec struct {
	Selector map[string]string `json:"selector,omitempty"`
	Type     string            `json:"type,omitempty"`
	Ports    []ServicePort     `json:"ports,omitempty"`
}

type ServicePort struct {
	Port       int32    `json:"port,omitempty"`
	TargetPort int      `json:"targetPort,omitempty"`
	Protocol   Protocol `json:"protocol,omitempty"`
	Name       string   `json:"name,omitempty"`
}

type ServiceStatus struct {
	Conditions   []Condition   `json:"conditions,omitempty"`
	LoadBalancer *LoadBalancer `json:"loadBalancer,omitempty"`
}

type Condition struct {
	LastTransitionTime time.Time `json:"lastTransitionTime"`
	Message            string    `json:"message"`
	Reason             string    `json:"reason"`
	Status             string    `json:"status"`
	Type               string    `json:"type"`
	ObservedGeneration int64     `json:"observedGeneration,omitempty"`
}

type LoadBalancer struct {
	Ingress []LoadBalancerIngress `json:"ingress,omitempty"`
}

type LoadBalancerIngress struct {
	Hostname string       `json:"hostname,omitempty"`
	IP       string       `json:"ip,omitempty"`
	Ports    []PortStatus `json:"portStatus,omitempty"`
}

type PortStatus struct {
	Port     int32    `json:"port,omitempty"`
	Protocol Protocol `json:"protocol,omitempty"`
	Error    string   `json:"error,omitempty"`
}

type Protocol uint8

const (
	ProtocolUnknown Protocol = iota
	ProtocolTCP
	ProtocolUDP
	ProtocolSCTP
)

func (p *Protocol) UnmarshalJSON(b []byte) error {
	var s string
	if err := json.Unmarshal(b, &s); err != nil {
		return err
	}
	switch s {
	default:
		*p = ProtocolUnknown
	case "TCP":
		*p = ProtocolTCP
	case "UDP":
		*p = ProtocolUDP
	case "SCTP":
		*p = ProtocolSCTP
	}

	return nil
}

func (p Protocol) MarshalJSON() ([]byte, error) {
	var s string
	switch p {
	default:
		s = "Unknown"
	case ProtocolTCP:
		s = "TCP"
	case ProtocolUDP:
		s = "UDP"
	case ProtocolSCTP:
		s = "SCTP"
	}

	return json.Marshal(s)
}
