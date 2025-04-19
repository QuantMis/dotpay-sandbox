#!/bin/bash

# Load environment variables from .env
set -a
source .env
set +a

# Run the Postgres container with the env vars
docker run --name kyc-db \
  -e POSTGRES_USER=$DB_USER \
  -e POSTGRES_PASSWORD=$DB_PASS \
  -e POSTGRES_DB=$DB_NAME \
  -p $DB_PORT:$DB_PORT \
  -d postgres:17

