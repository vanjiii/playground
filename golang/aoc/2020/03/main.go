package main

import (
	"bufio"
	"log"
	"os"
)

func main() {
	f, err := os.Open("input")
	if err != nil {
		log.Fatalf("fail to open file: %v", err)
	}
	defer f.Close()

	sc := bufio.NewScanner(f)
	sc.Split(bufio.ScanRunes)

	var input = []byte{}
	for sc.Scan() {
		// sc.Text()
	}

	if err := sc.Error(); err != nil {
		log.Fatalf("error occur while scanning: %v", err)
	}
}
