package sort_test

import (
	"testing"

	"algo_course/sort"

	"github.com/stretchr/testify/require"
)

func TestLinkedList(t *testing.T) {
	require := require.New(t)
	list := sort.NewList(5)

	list.Append(7)
	list.Append(9)

	require.EqualValues(9, *list.Get(2))
	require.EqualValues(7, *list.RemoveAt(1))
	require.EqualValues(2, list.Getlen())

	list.Append(11)
	require.EqualValues(9, *list.RemoveAt(1))
	require.Nil(list.Remove(9))
	require.EqualValues(5, *list.RemoveAt(0))
	require.EqualValues(11, *list.RemoveAt(0))
	require.EqualValues(0, list.Getlen())

	list.Prepend(5)
	list.Prepend(7)
	list.Prepend(9)

	require.EqualValues(5, *list.Get(2))
	require.EqualValues(9, *list.Get(0))
	require.EqualValues(9, *list.Remove(9))
	require.EqualValues(2, list.Getlen())
	require.EqualValues(7, *list.Get(0))
}
