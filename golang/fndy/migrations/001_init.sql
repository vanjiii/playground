-- +goose Up
CREATE EXTENSION IF NOT EXISTS pgcrypto;

CREATE TYPE os AS ENUM ('linux', 'mac', 'windows');
CREATE TYPE app_name AS ENUM ('mobile', 'desktop', 'shift_planner', 'service');

CREATE TABLE files (
	id UUID PRIMARY KEY DEFAULT PUBLIC.gen_random_uuid(),
        name TEXT NOT NULL,
	application_name app_name,
	os os,
	version integer,

        UNIQUE(name)
);

-- +goose Down
DROP TABLE files;
DROP TYPE os;
DROP TYPE app_name
