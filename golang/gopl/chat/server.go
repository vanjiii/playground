package main

import (
	"bufio"
	"fmt"
	"log"
	"net"
	"time"
)

func main() {
	listener, err := net.Listen("tcp", "localhost:8000")
	if err != nil {
		log.Fatal(err)
	}

	go broadcaster()
	for {
		conn, err := listener.Accept()
		if err != nil {
			log.Print(err)
			continue
		}
		go handleConn(conn)
	}
}

type client chan<- string //an outgoing message channel

var (
	entering = make(chan client)
	leaving  = make(chan client)
	messages = make(chan string) // all incoming client messages
)

func broadcaster() {
	clients := make(map[client]bool) // all connected clients
	for {
		select {
		case msg := <-messages:
			// Broadcast incoming message to all clients'
			// outgoing message channels.
			for cli := range clients {
				cli <- msg
			}
		case cli := <-entering:
			clients[cli] = true
		case cli := <-leaving:
			delete(clients, cli)
			close(cli)
		}
	}
}

func handleConn(conn net.Conn) {
	input := bufio.NewScanner(conn)
	var who string
	fmt.Fprint(conn, "Input your name: ")
	if input.Scan() {
		who = input.Text()
	}

	ch := make(chan string) // outgoing client messages
	go clientWriter(conn, ch)

	ch <- "You are " + who
	messages <- who + " has arrived"
	entering <- ch

	notIdleCh := make(chan bool)
	go countIdleTime(conn, who, notIdleCh)

	for input.Scan() {
		notIdleCh <- true
		messages <- who + ": " + input.Text()
	}
	// NOTE: ignore potential errors from input.Err()

	leaving <- ch
	messages <- who + " has left"
	conn.Close()
}

func clientWriter(conn net.Conn, ch <-chan string) {
	for msg := range ch {
		fmt.Fprintln(conn, msg) // NOTE: ignoring network errors
	}
}

func countIdleTime(conn net.Conn, who string, notIdleCh <-chan bool) {
	ticker := time.NewTicker(time.Second)
	counter := 0
	max := 10 // 20 seconds
	for {
		select {
		case <-ticker.C:
			counter++
			if counter == max {
				msg := who + " idle too long. Kicked out."
				messages <- msg
				fmt.Fprintln(conn, msg) // Let to-be-closed client see this msg
				ticker.Stop()
				conn.Close()
				return
			}
		case <-notIdleCh:
			counter = 0
		}
	}
}
