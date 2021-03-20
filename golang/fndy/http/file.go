package http

import (
	"encoding/json"
	"io"
	"net/http"

	"github/vanjiii/golang/fndy/file"
	"github/vanjiii/golang/fndy/service"
	"github/vanjiii/golang/fndy/store"
)

// File is http handler for encapsulating work with files.
type File struct {
	hand file.Filer
}

// NewFile creates new File.
func NewFile(env *service.Env) *File {
	return &File{
		hand: env.FileHandler,
	}
}

func (f *File) download(w http.ResponseWriter, r *http.Request) {
	fl, err := f.hand.Download(r.Context(), extractFileIndent(r))
	if err != nil {
		http.Error(w, err.Error(), http.StatusBadRequest)
	}
	defer fl.Close()

	io.Copy(w, fl)
}

func (f *File) bulkdownload(w http.ResponseWriter, r *http.Request) {
	if err := f.hand.BulkDownload(r.Context(), w, extractFileIndents(r)); err != nil {
		http.Error(w, err.Error(), http.StatusBadRequest)
	}
}

func (f *File) search(w http.ResponseWriter, r *http.Request) {
	files := f.hand.Search(r.Context(), extractSearchQs(r), store.ParseFilter(r))

	json.NewEncoder(w).Encode(&files)
}
