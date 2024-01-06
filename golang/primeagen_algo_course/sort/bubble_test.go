package sort_test

import (
	"testing"

	"github.com/stretchr/testify/require"

	"algo_course/sort"
)

func TestBubble(t *testing.T) {
	var arr = []int{9, 3, 7, 4, 69, 420, 42}

	require.EqualValues(t, []int{3, 4, 7, 9, 42, 69, 420}, sort.Bubble(arr))
}
