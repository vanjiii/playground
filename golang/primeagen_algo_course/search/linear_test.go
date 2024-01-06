package search_test

import (
	"algo_course/search"
	"fmt"
	"testing"

	"github.com/stretchr/testify/require"
)

func TestLinear(t *testing.T) {
	var foo = [11]int{1, 3, 4, 69, 71, 81, 90, 99, 420, 1337, 69420}

	cases := []struct {
		needle   int
		expvalue bool
	}{
		{69, true},
		{1336, false},
		{69420, true},
		{69421, false},
		{1, true},
		{0, false},
	}

	for _, tc := range cases {
		t.Run(fmt.Sprint(tc.needle), func(t *testing.T) {
			res := search.FindLinear(foo, tc.needle)

			require.EqualValues(t, tc.expvalue, res)
		})
	}
}
