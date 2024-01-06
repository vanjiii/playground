package search_test

import (
	"math"
	"math/rand"
	"testing"

	"github.com/stretchr/testify/require"

	"algo_course/search"
)

func TestCrystalBalls(t *testing.T) {
	idx := math.Floor(rand.Float64() * 10000)
	data := [10000]bool{}

	for i := int(idx); i < 10000; i++ {
		data[i] = true
	}

	require.EqualValues(t, idx, search.TwoCrystalBalls(data))
	require.EqualValues(t, -1, search.TwoCrystalBalls([10000]bool{}))
}
