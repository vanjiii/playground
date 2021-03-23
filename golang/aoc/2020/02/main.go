package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strconv"
	"strings"
)

type secret struct {
	min    int
	max    int
	letter byte
	pass   string
}

func main() {
	log.SetFlags(0)

	f, err := os.Open("input")
	if err != nil {
		log.Fatalf("fail to open input file: %v", err)
	}
	defer f.Close()

	sc := bufio.NewScanner(f)
	var input = []secret{}
	for sc.Scan() {
		s, err := string2secret(sc.Text())
		if err != nil {
			log.Fatalf("fail to parse secret: %v", err)
		}
		input = append(input, *s)
	}

	if err := sc.Err(); err != nil {
		log.Fatalf("fail while reading file: %v", err)
	}

	log.Println(correctSecrets(input))
	log.Println(correct2(input))
}

// O(NxM)
func correctSecrets(secrets []secret) int {
	var correct int
	for _, secret := range secrets {
		occ := 0
		for i := 0; i < len(secret.pass); i++ {
			if secret.pass[i] == secret.letter {
				occ++
			}
		}
		if occ >= secret.min && occ <= secret.max {
			correct++
		}
	}

	return correct
}

func correct2(secrets []secret) int {
	var correct int
	for _, secret := range secrets {
		// XOR -> (X || Y) && !(X && Y)
		x := secret.pass[secret.min-1] == secret.letter
		y := secret.pass[secret.max-1] == secret.letter
		if (x || y) && !(x && y) {
			correct++
		}
	}

	return correct
}

func string2secret(s string) (*secret, error) {
	byspace := strings.Split(s, " ")

	policies := strings.Split(byspace[0], "-")

	n1, err := strconv.Atoi(policies[0])
	if err != nil {
		return nil, fmt.Errorf("cannot parse first number of %s: %w", s, err)
	}

	n2, err := strconv.Atoi(policies[1])
	if err != nil {
		return nil, fmt.Errorf("cannot parse second number of %s: %w", s, err)
	}

	return &secret{
		min:    n1,
		max:    n2,
		letter: byspace[1][0],
		pass:   byspace[2],
	}, nil
}
