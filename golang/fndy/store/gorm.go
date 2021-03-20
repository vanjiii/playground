package store

import (
	"fmt"
	"log"
	"net/http"
	"os"
	"os/exec"
	"path/filepath"
	"strconv"
	"testing"
	"time"

	"github.com/google/uuid"
	"gorm.io/driver/postgres"
	"gorm.io/gorm"
	"gorm.io/gorm/logger"
)

// Filter is used for setting db limit and offset.
type Filter struct {
	Limit  int
	Offset int
}

// ParseFilter sets filter values directly from http.Request.
func ParseFilter(r *http.Request) Filter {
	v := r.URL.Query()

	l, err := strconv.Atoi(v.Get("limit"))
	if err != nil {
		l = -1
	}

	o, err := strconv.Atoi(v.Get("offset"))
	if err != nil {
		o = -1
	}

	return Filter{
		Limit:  l,
		Offset: o,
	}
}

// NewDB makes new instance of gorm.DB.
func NewDB() *gorm.DB {
	name := "public"
	newLogger := logger.New(
		log.New(os.Stdout, "\r\n", log.LstdFlags), // io writer
		logger.Config{
			SlowThreshold: time.Second,   // Slow SQL threshold
			LogLevel:      logger.Silent, // Log level
			Colorful:      false,         // Disable color
		},
	)
	db, err := gorm.Open(postgres.Open(pgconnect(name)), &gorm.Config{
		Logger: newLogger,
	})
	if err != nil {
		panic("failed to connect database")
	}
	return db
}

func pgconnect(dbname string) string {
	return fmt.Sprintf("host=localhost dbname=fndy port=5432 search_path=%s sslmode=disable", dbname)
}

func newTestDB(t *testing.T) (*gorm.DB, func()) {
	t.Helper()

	name := fmt.Sprintf("fndy-%s", uuid.New().String())
	newLogger := logger.New(
		log.New(os.Stdout, "\r\n", log.LstdFlags), // io writer
		logger.Config{
			SlowThreshold: time.Second,   // Slow SQL threshold
			LogLevel:      logger.Silent, // Log level
			Colorful:      false,         // Disable color
		},
	)
	db, err := gorm.Open(postgres.Open(pgconnect(name)), &gorm.Config{
		Logger: newLogger,
	})
	if err != nil {
		t.Fatal("failed to connect database")
	}

	cleanup := func() {
		_, err := db.Raw(fmt.Sprintf("DROP SCHEMA %q CASCADE", name)).Rows()
		psdb, err := db.DB()
		if err != nil {
			t.Fatal("fail to get sql.PSQL driver")
		}
		psdb.Close()
		if err != nil {
			t.Fatalf("Failed to drop test database: %q! Clean it up manually!!!", err)
		}
	}

	if _, err = db.Raw(fmt.Sprintf("CREATE SCHEMA %q", name)).Rows(); err != nil {
		t.Fatalf("Create schema failed: %s", err)
	}

	mpath := filepath.Join(PathName(t), "migrations")

	goose := exec.Command("goose", "-dir", mpath, "postgres", pgconnect(name), "up")

	if err = goose.Run(); err != nil {
		cleanup()
		t.Fatalf("Running goose failed: %q", err)
	}

	return db, cleanup
}

// PathName returns base project path.
//
// This works reliably because Go guarantees that tests are being run from
// current file's directory.
func PathName(t *testing.T) string {
	var dirname, err = os.Getwd()
	if err != nil {
		t.Fatalf("base: %s", err)
	}

	return filepath.Join(dirname, "..")
}
