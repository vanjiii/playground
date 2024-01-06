package search

// [lo, hi)
func FindBinary(arr [11]int, needle int) bool {
	lo := 0
	hi := len(arr)

	for lo < hi {
		// maybe we do not need math.Floor
		m := lo + (hi-lo)/2
		v := arr[m]

		if v == needle {
			return true
		} else if v > needle {
			hi = m
		} else {
			lo = m + 1
		}
	}

	return false
}
