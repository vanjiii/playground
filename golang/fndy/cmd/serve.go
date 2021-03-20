package cmd

import (
	"context"
	"net"
	"net/http"
	"os"
	"os/signal"
	"syscall"

	httph "github/vanjiii/golang/fndy/http"
	"github/vanjiii/golang/fndy/service"

	log "github.com/sirupsen/logrus"
	"github.com/spf13/cobra"
)

func init() {
	rootCmd.AddCommand(serveCmd)

	log.SetFormatter(&log.JSONFormatter{})
}

var serveCmd = &cobra.Command{
	Use:   "serve",
	Short: "start backed service",
	Run: func(cmd *cobra.Command, args []string) {
		serve()
	},
}

func serve() {
	env, err := service.NewEnv()
	if err != nil {
		log.Fatal("creating new environment failed: ", err)
	}

	l, err := net.Listen("tcp", ":8080")
	if err != nil {
		log.Panicf("cannot listen: %s", err)
	}

	s := http.Server{
		Addr:    "localhost:8080",
		Handler: httph.ServeMux(env),
	}

	done := make(chan struct{})
	go func() {
		var c = make(chan os.Signal, 1)
		signal.Notify(c, syscall.SIGINT, syscall.SIGTERM)
		<-c

		log.Println("Got shutdown request.")
		if err := s.Shutdown(context.Background()); err != nil {
			log.Printf("HTTP server Shutdown: %v", err)
		}

		close(done)
	}()

	url := "http://127.0.0.1:8080"

	log.Printf("Listening on %s", url)
	if err := s.Serve(l); err != http.ErrServerClosed {
		// Error starting or closing listener:
		log.Printf("HTTP server Serve: %v", err)
	}
	<-done
}
