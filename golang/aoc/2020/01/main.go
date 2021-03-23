package main

import (
	"bufio"
	"log"
	"os"
	"strconv"
)

func main() {
	log.SetFlags(0)

	f, err := os.Open("input")
	if err != nil {
		log.Fatalf("err occur: %v", err)
	}
	defer f.Close()

	sc := bufio.NewScanner(f)
	input := make([]int, 0)
	for sc.Scan() {
		num, err := strconv.Atoi(sc.Text())
		if err != nil {
			log.Fatalf("fail to convert line: %v; err: %v", sc.Text(), err)
		}

		input = append(input, num)
	}
	if err := sc.Err(); err != nil {
		log.Fatalf("scan file error: %v", err)
		return
	}

	// solution
	// part one
	nums := map[int]bool{}
	for _, num := range input {
		nums[num] = true
	}

	var num1, num2 int
	for _, n := range input {
		tmp := 2020 - n
		if ok := nums[tmp]; ok {
			num1 = tmp
			num2 = n
			break
		}
	}

	log.Printf("%d X %d = %d", num1, num2, num1*num2)

	// part two
	var n1, n2, n3 int
	for i := 0; i < len(input); i++ {
		for j := 1; j < len(input); j++ {
			tmp := input[i] + input[j]
			tmp = 2020 - tmp
			if ok := nums[tmp]; ok {
				n1 = input[i]
				n2 = input[j]
				n3 = tmp
				break
			}
		}
	}

	log.Printf("%d X %d X %d= %d", n1, n2, n3, n1*n2*n3)
}
