package store

import (
	"fmt"
	"math/rand"
	"testing"

	"github/vanjiii/golang/fndy"

	"gorm.io/gorm"
)

func newTestFile(t *testing.T, db *gorm.DB, nums ...int) fndy.File {
	i := rand.Intn(100)

	if len(nums) != 0 {
		i = nums[0]

	}
	f := fndy.File{
		Name:    fmt.Sprintf("file-%d.txt", i),
		AppName: fndy.AppMobile,
		OS:      fndy.OSLinux,
		Version: i,
	}

	if err := db.Save(&f).Error; err != nil {
		t.Fatalf("fail to create file: %v", err)
	}

	return f
}
