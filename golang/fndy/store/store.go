package store

import (
	"context"
	"fmt"

	"github/vanjiii/golang/fndy"

	"gorm.io/gorm"
)

// Store is simple interface for querying database.
type Store interface {
	// List all the fndy.Entity and returns them.
	//
	// If err is occurred the empty list is returned.
	// ctx is the current context;
	// filter with necessary options;
	// opts is for decorating the query;
	List(ctx context.Context, filter Filter, opts ...opt) []fndy.Entity

	// Get look for and return the fndy.Entity entity with index or
	// returns and error.
	Get(ctx context.Context, name string) (fndy.Entity, error)
}

//go:generate mockgen -package=store -self_package=github/vanjiii/golang/fndy/store -destination=./store_mock.go -write_package_comment=false github/vanjiii/golang/fndy/store Store

type gstore struct {
	db *gorm.DB
}

// NewFile creates and returns instance of a Store.
func NewFile(db *gorm.DB) Store {
	return gstore{
		db: db,
	}
}

type opt func(*gorm.DB) *gorm.DB

func (s gstore) List(ctx context.Context, filter Filter, opts ...opt) []fndy.Entity {
	var files []fndy.File
	db := s.db

	for _, option := range opts {
		db = option(db)
	}

	if filter.Limit >= 1 {
		db = db.Limit(filter.Limit)
	}

	if filter.Offset >= 1 {
		db = db.Offset(filter.Offset)
	}

	db.Order("application_name, version, os").Find(&files)

	var entities = make([]fndy.Entity, len(files))
	for i := range files {
		entities[i] = files[i]
	}

	return entities
}

func (s gstore) Get(ctx context.Context, name string) (fndy.Entity, error) {
	var f fndy.File

	err := s.db.Where("name = ?", name).First(&f).Error
	return f, err
}

// ListWithParams decorates the store.List with appropriate values.
//
// For up-to-date list of possible values, see `pmap`.
func ListWithParams(p map[string]string) opt {
	return func(db *gorm.DB) *gorm.DB {
		for k, v := range p {
			key := pmap[k]

			if v != "" {
				db = db.Where(fmt.Sprintf("%s = ?", key), v)
			}
		}

		return db
	}
}

var pmap = map[string]string{
	"appName": "application_name",
	"os":      "os",
	"version": "version",
}
