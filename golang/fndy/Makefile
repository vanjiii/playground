export GO111MODULE=on

all: dep migrate build

migrate: ## Run migrations against fndy
	goose -dir ./migrations postgres "dbname=fndy sslmode=disable" up

dep: ## Fetch all needed requirements
	which goose > /dev/null || go get github.com/pressly/goose/cmd/goose@v2.6.0
	which enumer > /dev/null || go get github.com/dmarkham/enumer@v1.5.1
	which mockgen > /dev/null || go get github.com/golang/mock/mockgen@@v1.4.4

build: ## Install the app
	go generate ./...
	go install ./...

test: ## Simply run tests
	go test ./... -v -count 1

clean: ## Clean redundant stuff
	find . -name "*_gen.go" | xargs -r rm
	find . -name "*_enumer.go" | xargs -r rm


help:  ## Display this help screen
	@grep -h -E '^[\.a-zA-Z_-]+:.*?## .*$$' $(MAKEFILE_LIST) | awk 'BEGIN {FS = ":.*?## "}; {printf "\033[36m%-30s\033[0m %s\n", $$1, $$2}'
