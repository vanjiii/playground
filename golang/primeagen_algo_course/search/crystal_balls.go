package search

import "math"

// req:
// You have 2 crystal balls; find the perfect height where the crystal ball
// will break.

// problem:
// Basically we have arr of bools (fl1:f, fl2:f, fl3:t, fl4:t) or
// [f, f, t, t] => on floor 3 is the sufficient floor (height).
//
// sol 1:
// we may combine binary + linear.
// implement binary; when found floor=t; then do linear (lo->m)
// time: O(logN+N) == O(N)
//
// sol 2:
// we will implement this with hops with sqrt(N) of lenght for single hop.
// basically:
// go to sqrt(N) if false
// go to sqrt(N) if true
// do linear search Xsqrt(N)->X+1 sqrt(N)
// time: O(sqrt(N) + sqrt(N)) => O(sqrt(N))

func TwoCrystalBalls(breaks [10_000]bool) int {
	lenarr := len(breaks)
	jmpAmount := math.Floor(math.Sqrt(float64(lenarr)))
	jmp := int(jmpAmount)

	i := jmp

	for ; i < lenarr; i += jmp {
		if breaks[i] {
			break
		}
	}

	i -= jmp

	for j := 0; j < jmp; j++ {
		if breaks[i] {
			return i
		}

		i++
	}

	return -1
}
