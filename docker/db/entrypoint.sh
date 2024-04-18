#!/bin/bash

# Start the script to restore the DB and user
/tmp/backup/create-db.sh &

/opt/mssql/bin/sqlservr