SHELL = /bin/bash
.SHELLFLAGS = -euo pipefail -c
SO := $(shell uname -s)

start:
	docker-compose up -d

start-with-log:
	docker-compose up

setup:
	COMPOSE_DOCKER_CLI_BUILD=1 DOCKER_BUILDKIT=1 docker-compose up --build
	sleep 10

shell-api:
	docker exec -it radix-api bash

shell-app:
	docker exec -it radix-app bash

shell-mssql:
	docker exec -it radix-mssql bash

destroy:
	docker-compose down -v

stop:
	docker-compose stop

restart:
	docker restart $(container)