package main

import (
	"fmt"
	"io/ioutil"
	"log"
	"net/http"
	"sync"
	"time"
)

func main() {
	urls := []string{
		"https://stageai.tech/",
		"https://golang.org/",
		"https://google.com/",
		"https://golang.org/",
		"https://golang.org/",
		"https://godoc.org/",
		"https://gopl.io",
	}

	m := new(httpGetBody)

	var wg sync.WaitGroup
	for _, url := range urls {
		wg.Add(1)
		go func(url string) {
			start := time.Now()
			value, err := m.Get(url)
			if err != nil {
				log.Print(err)
			}

			fmt.Printf("%s, %s, %d bytes\n",
				url, time.Since(start), len(value.([]byte)))
			wg.Done()
		}(url)
	}

	wg.Wait()
}

type memo struct {
	f     Func
	cache map[string]*entry
	mu    sync.Mutex // guards cache
}

type Func func(string) (interface{}, error)

type result struct {
	value interface{}
	err   error
}

type entry struct {
	res   result
	ready chan struct{} //closed when res is ready
}

func new(f Func) *memo {
	return &memo{
		f:     f,
		cache: make(map[string]*entry),
	}
}

func (m *memo) Get(key string) (interface{}, error) {
	m.mu.Lock()
	e := m.cache[key]
	if e == nil {
		// This is the first request for this key.
		// This goroutine becomes responsible for computing
		// the value and broadcasting the ready condition.
		e = &entry{ready: make(chan struct{})}

		m.cache[key] = e
		m.mu.Unlock()

		e.res.value, e.res.err = m.f(key)
		close(e.ready)
	} else {
		// This is a repeat request for this key.
		m.mu.Unlock()

		<-e.ready // wait for ready condition
	}
	return e.res.value, e.res.err
}

func httpGetBody(url string) (interface{}, error) {
	resp, err := http.Get(url)
	if err != nil {
		return nil, err
	}
	defer resp.Body.Close()
	return ioutil.ReadAll(resp.Body)
}
