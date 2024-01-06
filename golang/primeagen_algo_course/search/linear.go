package search

// time complexity: O(N)
func FindLinear(haystack [11]int, needle int) bool {
	for i := 0; i < len(haystack); i++ {
		if haystack[i] == needle {
			return true
		}
	}

	return false
}
