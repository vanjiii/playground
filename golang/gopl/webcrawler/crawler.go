package main

import (
	"flag"
	"fmt"
	"log"

	"github/Playground/golang/gopl/links"
)

// Using counting semaphores to enforce a limit of N concurrent
// requests.
var tokens = make(chan struct{}, 20)

func semCrawl(url string, d int) []string {
	if d > *depth {
		return nil
	}

	fmt.Println("url: " + url)
	tokens <- struct{}{} // acquire a token
	list, err := links.Extract(url)
	<-tokens //release the token

	if err != nil {
		log.Print(err)
	}

	return list
}

var depth = flag.Int("depth", 10, "Initialize the depth of the search.")
var url = flag.String("url", "", "The URL to be crawled.")

// This approach is too parallel. It calls every url.Extract in its
// own goroutine which makes operations such as DNS lookups and calls
// to net.Dial to start failing.
func main() {
	flag.Parse()

	worklist := make(chan []string)
	var n int // number of pending send to worklist

	n++ // start with the cli (given url)

	// Start with the command line arguments. This needs to be in
	// a goroutine because of deadlock.
	go func() { worklist <- []string{*url} }()

	// Crawl the web concurrently.
	seen := make(map[string]bool)

	// depth
	var dd int
	for ; n > 0; n-- {
		list := <-worklist
		for _, link := range list {
			if !seen[link] {
				seen[link] = true
				n++
				go func(link string) {
					// worklist <- crawl(link)
					worklist <- semCrawl(link, dd)
				}(link)
			}
		}
		dd++
	}
}

func crawl(url string) []string {
	log.Printf("url: %s", url)

	list, err := links.Extract(url)
	if err != nil {
		log.Fatal(err)
	}
	return list
}

// breadthFirst calls f for each item in the worklist.
// Any items returned by f are added to the worklist.
// f is called at most once for each item.
// func breadthFirst(
// 	f func(item string) []string,
// 	worklist []string) ([]string, error) {

// 	seen := make(map[string]bool)

// 	for len(worklist) > 0 {
// 		items := worklist
// 		worklist = nil

// 		for _, item := range items {
// 			if !seen[item] {
// 				seen[item] = true
// 				worklist = append(worklist, f(item)...)
// 			}
// 		}
// 	}
// }
