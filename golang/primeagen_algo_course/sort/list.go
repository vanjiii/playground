package sort

type LinkedList interface {
	Getlen() int
	InsertAt(item int, index int)
	Remove(item int) *int
	RemoveAt(index int) *int
	Append(item int)
	Prepend(item int)
	Get(index int) *int
}

type list struct {
	first *node
}

type node struct {
	val  int
	next *node
}

func NewList(i int) LinkedList {
	n := node{
		val:  i,
		next: nil,
	}
	return &list{
		first: &n,
	}
}

func (l *list) Getlen() int {
	if l.first == nil {
		return 0
	}

	var lenght = 1

	curr := l.first.next

	for curr != nil {
		lenght++
		curr = curr.next
	}

	return lenght
}

func (l *list) InsertAt(item int, index int) {}

func (l *list) Remove(item int) *int {
	var curr = l.first
	if l.first.val == item {
		return l.RemoveAt(0)
	}

	for curr.next.val != item {
		curr = curr.next

		if curr.next == nil {
			return nil
		}
	}

	toDelete := curr.next
	curr.next = toDelete.next

	return &toDelete.val
}

func (l *list) RemoveAt(index int) *int {
	if index == 0 {
		curr := l.first

		l.first = curr.next

		return &curr.val
	}

	var curr = l.first

	for i := 1; i < index; i++ {
		curr = curr.next
	}

	toDelete := curr.next
	curr.next = toDelete.next

	return &toDelete.val
}

func (l *list) Append(item int) {
	curr := l.first

	for curr.next != nil {
		curr = curr.next
	}

	n := node{
		val: item,
	}

	curr.next = &n
}

func (l *list) Prepend(item int) {
	n := node{
		val:  item,
		next: l.first,
	}

	l.first = &n
}

func (l *list) Get(index int) *int {
	var curr = l.first

	for i := 1; i <= index; i++ {
		curr = curr.next
	}

	res := curr.val

	return &res
}
