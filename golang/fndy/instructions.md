# Fndy Download service

## Requirements
- Go 1.15+
- PostgreSQL 13
- mockgen
- enumer
- goose

## Install instruction
- Create database with name `fndy`;
- Locate in the root dir of the project and use Makefile by typing: `make`, or:
1. `go generate ./...`;
2. `go install ./...`;
3. `goose -dir ./migrations postgres "dbname=fndy sslmode=disable" up`;

Run server with `fndy serve`.

To run tests: `go test ./...`

To create some dummy data use `fndy seed`

Profit!

TODO
- config
- migrate command
- make gstore more generic
