package http

import (
	"net/http"
	"net/url"
)

func extractFileIndent(r *http.Request) string {
	m, err := parsequery(r)
	if err != nil {
		return ""
	}
	return m["file_identifier"][0]
}

func extractFileIndents(r *http.Request) []string {
	m, err := parsequery(r)
	if err != nil {
		return nil
	}
	return m["file_identifier"]
}

func extractSearchQs(r *http.Request) map[string]string {
	qs := map[string]string{
		"appName": "",
		"os":      "",
		"version": "",
	}

	m, err := parsequery(r)
	if err != nil {
		return qs
	}

	for k := range qs {
		if v, ok := m[k]; ok {
			qs[k] = v[0]
		}
	}

	return qs
}

func parsequery(r *http.Request) (url.Values, error) {
	return url.ParseQuery(r.URL.RawQuery)
}
