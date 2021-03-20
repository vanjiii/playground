package fndy

import (
	"github.com/gofrs/uuid"
)

// File entity.
type File struct {
	// ID of the file.
	ID uuid.UUID `gorm:"type:uuid; primary_key; default:PUBLIC.gen_random_uuid()"`

	// Location where is saved the file.
	Name string

	// AppName the name of the application requested for download.
	AppName AppType `gorm:"column:application_name"`

	// OS is the OS required by the client, searching for the
	// file.
	OS OS

	// Version is the version of the application requested.
	Version int
}

// TableName is implementing Tablerer
func (File) TableName() string {
	return "files"
}

//go:generate enumer -type=OS -trimprefix=OS -json -sql -transform=snake
type OS int

const (
	_ OS = iota
	OSLinux
	OSMac
	OSWindows
)

//go:generate enumer -type=AppType -trimprefix=App -json -sql -transform=snake
type AppType int

const (
	// mobile, desktop, shift_planner, service
	_ AppType = iota
	AppMobile
	AppDesktop
	AppShiftPlanner
	AppService
)

// Entity is general purpose interface which is useful for
// communicating between layers.
type Entity interface {
	IsEntity()
}

func (File) IsEntity() {}
