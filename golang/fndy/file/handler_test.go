package file

import (
	"context"
	"io/ioutil"
	"os"
	"testing"

	"github/vanjiii/golang/fndy"
	"github/vanjiii/golang/fndy/errors"
	"github/vanjiii/golang/fndy/store"

	"github.com/gofrs/uuid"
	gomock "github.com/golang/mock/gomock"
)

var (
	ctx = context.Background()
	any = gomock.Any()
)

func TestFilter(t *testing.T) {
	t.Run("download", testDownload)
	t.Run("buldownload", testBulkDownload)
}

func testDownload(t *testing.T) {
	mockCtrl := gomock.NewController(t)
	defer mockCtrl.Finish()
	st := store.NewMockStore(mockCtrl)

	st.EXPECT().Get(any, any).Return(fndy.File{ID: uuid.Nil, Name: "file-1.txt"}, nil).MaxTimes(1)
	st.EXPECT().Get(any, any).Return(fndy.File{}, errors.ErrBadRequest).AnyTimes().AnyTimes()

	h := New(st, "testdata")

	cases := []struct {
		name  string
		ctx   context.Context
		fname string
		err   error
		file  fndy.File
	}{
		{
			name:  "ok",
			ctx:   ctx,
			fname: "file-1.txt",
			err:   nil,
		},
		{
			name:  "fnf",
			ctx:   ctx,
			fname: "file.txt",
			err:   errors.ErrBadRequest,
		},
	}

	for _, tc := range cases {
		t.Run(tc.name, func(t *testing.T) {

			f, err := h.Download(tc.ctx, tc.fname)
			if !isError(err, tc.err) {
				t.Fatalf("got err: %v, but exp: %v", err, tc.err)
			}

			if tc.err != nil {
				// skip additional checks if error is
				// expected
				return
			}

			fi, err := f.Stat()
			if err != nil {
				t.Fatalf("fail to get file info: %v", err)
			}

			if fi.Size() == 0 {
				t.Fatal("fail to get non-empty file")
			}

			// TODO: read and check lines/content of file
		})
	}
}

func testBulkDownload(t *testing.T) {
	mockCtrl := gomock.NewController(t)
	defer mockCtrl.Finish()
	st := store.NewMockStore(mockCtrl)

	st.EXPECT().Get(any, any).Return(fndy.File{ID: uuid.Nil, Name: "file-1.txt"}, nil).MaxTimes(1)
	st.EXPECT().Get(any, any).Return(fndy.File{}, errors.ErrBadRequest).AnyTimes().AnyTimes()

	h := New(st, "testdata")

	cases := []struct {
		name   string
		ctx    context.Context
		fnames []string
		err    error
	}{
		{
			name:   "two files",
			err:    nil,
			ctx:    ctx,
			fnames: []string{"file-1.txt"},
		},
		{
			name:   "fnf",
			err:    errors.ErrBadRequest,
			ctx:    ctx,
			fnames: []string{"file.txt"},
		},
	}

	for _, c := range cases {
		t.Run(c.name, func(t *testing.T) {
			f, err := ioutil.TempFile("", "tmp.zip")
			if err != nil {
				t.Fatalf("fail to create temporary file: %v", err)
			}

			err = h.BulkDownload(c.ctx, f, c.fnames)
			if !isError(err, c.err) {
				t.Fatalf("got err: %v, but exp: %v", err, c.err)
			}

			if c.err != nil {
				// skip additional checks if error is
				// expected
				return
			}

			fi, err := f.Stat()
			if err != nil {
				t.Fatalf("fail to get file info: %v", err)
			}

			if fi.Size() == 0 {
				t.Fatal("fail to get non-empty file")
			}

			os.Remove(f.Name())

			// TODO unzip and check num of files
		})
	}
}

func isError(err, target error) bool {
	if err == target {
		return true
	}

	return errors.Is(err, target)
}
