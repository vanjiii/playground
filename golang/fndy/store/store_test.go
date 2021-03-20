package store

import (
	"context"
	"testing"

	"github/vanjiii/golang/fndy"
	"github/vanjiii/golang/fndy/errors"

	"gorm.io/gorm"
)

var ctx = context.Background()

func TestList(t *testing.T) {
	t.Run("list", testList)
	t.Run("get", testGet)
}

func testList(t *testing.T) {
	db, cleanup := newTestDB(t)
	defer cleanup()

	st := NewFile(db)

	total := 10
	for i := 0; i < total; i++ {
		newTestFile(t, db, i)
	}

	cases := []struct {
		name   string
		ctx    context.Context
		filter Filter
		exp    int
	}{
		{
			name: "all",
			ctx:  ctx,
			filter: Filter{
				Limit:  -1,
				Offset: -1,
			},
			exp: total,
		},
		{
			name: "first 3",
			ctx:  ctx,
			filter: Filter{
				Limit:  3,
				Offset: -1,
			},
			exp: 3,
		},
	}

	for _, c := range cases {
		t.Run(c.name, func(t *testing.T) {
			files := st.List(c.ctx, c.filter)

			if len(files) != c.exp {
				t.Fatalf("expecting num of files: %d, got: %d", c.exp, len(files))
			}
		})
	}
}

func testGet(t *testing.T) {
	db, cleanup := newTestDB(t)
	defer cleanup()

	st := NewFile(db)

	newTestFile(t, db, 1)

	cases := []struct {
		name  string
		fname string
		err   error
	}{
		{
			name:  "ok",
			fname: "file-1.txt",
			err:   nil,
		},
		{
			name:  "fnf",
			fname: "file.txt",
			err:   gorm.ErrRecordNotFound,
		},
	}

	for _, c := range cases {
		t.Run(c.name, func(t *testing.T) {
			f, err := st.Get(ctx, c.fname)
			if !errors.Is(err, c.err) {
				t.Fatalf("err got: %v, but exp: %v", err, c.err)
			}

			if c.err != nil {
				// skip additional checks
				return
			}

			if f.(fndy.File).Name != c.fname {
				t.Fatalf("file name is: %s, but exp: %s", f.(fndy.File).Name, c.fname)
			}
		})
	}
}
