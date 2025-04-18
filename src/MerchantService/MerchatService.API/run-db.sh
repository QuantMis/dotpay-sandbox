#!/bin/bash

# Load environment variables from .env
set -a
source .env
set +a

# Run the Postgres container with the env vars
docker run --name merchant-db \
  -e POSTGRES_USER=$DB_USER \
  -e POSTGRES_PASSWORD=$DB_PASS \
  -e POSTGRES_DB=$DB_NAME \
  -p $DB_PORT:5432 \
  -d postgres:17

