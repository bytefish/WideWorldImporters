# Wait for SQL Server to start and be ready to accept connections
sleep 35s
echo sa_password is $MSSQL_SA_PASSWORD
/opt/mssql-tools/bin/sqlcmd -S . -U sa -P $MSSQL_SA_PASSWORD -i /tmp/backup/restore.sql