#!/bin/bash

# Start the script to create the DB and user
/scripts/configure-db.sh &

# Start SQL Server
/opt/mssql/bin/sqlservr