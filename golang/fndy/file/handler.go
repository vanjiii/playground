package file

import (
	"archive/zip"
	"context"
	"fmt"
	"io"
	"os"
	"path/filepath"

	"github/vanjiii/golang/fndy"
	"github/vanjiii/golang/fndy/errors"
	"github/vanjiii/golang/fndy/store"
)

// Filer is simple interface for working with files. It defines all
// the necessary methods.
type Filer interface {
	// Download single file base on the filename
	Download(ctx context.Context, filename string) (*os.File, error)

	// BulkDownload zip all files listed in filenames and return
	// write the zip to the wr.
	BulkDownload(ctx context.Context, wr io.Writer, filenames []string) error

	// Search for files with predifined params (see store#pmap) and filter.
	Search(context.Context, map[string]string, store.Filter) []fndy.File
}

//go:generate mockgen -package=file -self_package=github/vanjiii/golang/fndy/file -destination=./store_mock.go -write_package_comment=false github/vanjiii/golang/fndy/file Filer

type handler struct {
	st   store.Store
	path string
}

func New(st store.Store, downloadpath string) Filer {
	return &handler{
		st:   st,
		path: downloadpath,
	}
}

func (h *handler) Download(ctx context.Context, filename string) (*os.File, error) {
	foundf, err := h.st.Get(ctx, filename)
	if err != nil {
		return nil, err
	}

	fullname := filepath.Join(h.path, foundf.(fndy.File).Name)
	f, err := os.Open(fullname)
	if err != nil {
		err = fmt.Errorf("%w: %s", errors.ErrBadRequest, err.Error())
	}

	return f, err
}

func (h *handler) BulkDownload(ctx context.Context, wr io.Writer, filenames []string) error {
	zw := zip.NewWriter(wr)
	defer zw.Close()

	fullnames := make([]string, len(filenames))
	// TODO: make this with one `like` query
	for i := range filenames {
		foundf, err := h.st.Get(ctx, filenames[i])
		if err != nil {
			return err
		}
		fullnames[i] = filepath.Join(h.path, foundf.(fndy.File).Name)
	}

	for i := range fullnames {
		if err := zipfile(zw, fullnames[i]); err != nil {
			return err
		}
	}

	return nil
}

func (h *handler) Search(ctx context.Context, params map[string]string, filter store.Filter) []fndy.File {
	entities := h.st.List(ctx,
		filter,
		store.ListWithParams(params),
	)

	files := make([]fndy.File, len(entities))
	for i := range entities {
		files[i] = entities[i].(fndy.File)
	}

	return files
}

func zipfile(zw *zip.Writer, fname string) error {
	f, err := os.Open(fname)
	if err != nil {
		return fmt.Errorf("%w: %s", errors.ErrBadRequest, err.Error())
	}
	defer f.Close()

	info, err := f.Stat()
	if err != nil {
		return err
	}

	header, err := zip.FileInfoHeader(info)
	if err != nil {
		return err
	}

	// change compression type
	header.Method = zip.Deflate

	w, err := zw.CreateHeader(header)
	if err != nil {
		return err
	}
	_, err = io.Copy(w, f)
	return err
}
