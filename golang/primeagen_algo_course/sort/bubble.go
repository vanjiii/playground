package sort

func Bubble(arr []int) []int {
	var res = make([]int, len(arr))

	copy(res, arr)

	for j := range res {
		// -1 we do not want to go out of bound
		// -j every j loop we have the biggest element at the end
		// so we can skip this (comparing with last)
		for i := 0; i < len(res)-1-j; i++ {
			if res[i] > res[i+1] {
				res[i], res[i+1] = res[i+1], res[i]
			}
		}
	}

	return res
}
