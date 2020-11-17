// 8.2. Example: Concurrent Clock Server
//
// Clock1 is a TCP server that periodically writes the time.
// with nc `netcat` tool may listen.
// `nc localhost 3031`

package main

import (
	"flag"
	"io"
	"log"
	"net"
	"time"
)

var port *string = flag.String("p", "3031", "Set port option")

func main() {
	flag.Parse()

	addr := "localhost:" + *port

	listener, err := net.Listen("tcp", addr)
	if err != nil {
		log.Fatalf("listener fails with: %v", err)

	}

	log.Printf("listening on: %s", addr)

	for {
		conn, err := listener.Accept()
		if err != nil {
			log.Fatalf("connection error: %v", err) // e.g. connection lost
			continue
		}

		// running concurrently
		go handleConn(conn)
	}
}

// handleConn handles ONE connection at a time.
func handleConn(c net.Conn) {
	defer c.Close()

	for {
		_, err := io.WriteString(c, time.Now().Format("15:04:05\n"))
		if err != nil {
			log.Fatalf("string writer fails: %v", err)
		}

		time.Sleep(1 * time.Second)
	}
}
