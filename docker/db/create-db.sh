#!/bin/bash

# Wait for SQL Server to complete
sleep 30s

# Run the setup script to create the DB and the schema in the DB
/opt/mssql-tools18/bin/sqlcmd -S localhost -C -U sa -P $MSSQL_SA_PASSWORD -d master -i restore.sql
/opt/mssql-tools18/bin/sqlcmd -S localhost -C -U sa -P $MSSQL_SA_PASSWORD -d master -i users.sql