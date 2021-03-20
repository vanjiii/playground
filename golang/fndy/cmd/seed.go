package cmd

import (
	"fmt"
	"io/ioutil"
	"log"
	"path/filepath"

	"github/vanjiii/golang/fndy"
	"github/vanjiii/golang/fndy/store"

	"github.com/spf13/cobra"
	"gorm.io/gorm"
)

var seedCmd = &cobra.Command{
	Use:   "seed",
	Short: "Setup dummy data for testing purposes",
	Run: func(cmd *cobra.Command, args []string) {
		seed()
	},
}

var text = `
Vivamus sed vehicula odio. Maecenas pretium, purus vitae condimentum
auctor, lorem felis sodales odio, sed sollicitudin massa ligula sed
ante. Donec vehicula diam sit amet ex porttitor dignissim in et
diam. Nulla commodo nisi fermentum scelerisque dictum. Mauris in elit
accumsan, lacinia lorem porttitor, semper neque. Integer dignissim
diam nec aliquet porttitor. Morbi consectetur blandit mattis. Praesent
tincidunt ipsum vel nisl facilisis, interdum ullamcorper nibh
tincidunt. Suspendisse potenti. Cras consequat erat ut tellus
porttitor suscipit. Donec neque ligula, rhoncus rutrum dapibus vel,
ullamcorper eget turpis. Cras ut malesuada velit. Morbi venenatis,
urna vel bibendum faucibus, mauris tortor ultricies lorem, eu
vulputate sapien dolor cursus lorem. Nam lobortis, eros quis sagittis
condimentum, dolor nunc vehicula neque, nec congue velit massa non
dui.`

func init() {
	rootCmd.AddCommand(seedCmd)
}

func seed() {
	db := store.NewDB()
	for i := 0; i < 10; i++ {
		f, err := newFile(db, i)
		if err != nil {
			log.Fatalf("got err: %v", err)
		}

		if err := createFile(f.Name); err != nil {
			log.Fatalf("fail to create a file: %v", err)
		}

		fmt.Printf("file with name %s is created.\n", f.Name)
	}

	fmt.Println("Success!")
}

func newFile(db *gorm.DB, i int) (fndy.File, error) {
	f := fndy.File{
		Name:    fmt.Sprintf("file-%d.txt", i),
		AppName: fndy.AppType((i % 4) + 1),
		OS:      fndy.OS((i % 2) + 1),
		Version: i,
	}

	if err := db.Save(&f).Error; err != nil {
		return fndy.File{}, nil
	}

	return f, nil
}

func createFile(fname string) error {
	body := []byte(text)
	name := filepath.Join("/", "tmp", fname)
	return ioutil.WriteFile(name, body, 0644)
}
