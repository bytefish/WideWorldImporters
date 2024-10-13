FROM mcr.microsoft.com/mssql/server:2022-latest

WORKDIR /tmp/backup

# Install Packages, because built-in sqlcmd has a bug ...
USER root

RUN apt-get update \
    && ACCEPT_EULA=Y apt-get install mssql-tools18 unixodbc-dev -y \
    && wget -q  https://github.com/Microsoft/sql-server-samples/releases/download/wide-world-importers-v1.0/WideWorldImporters-Full.bak
    
COPY ../docker/wwi-db/restore.sql ./restore.sql
COPY ../docker/wwi-db/security.sql ./security.sql
COPY ../docker/wwi-db/users.sql ./users.sql
COPY ../docker/wwi-db/create-db.sh ./create-db.sh
COPY ../docker/wwi-db/entrypoint.sh ./entrypoint.sh

ENTRYPOINT ["/bin/bash", "/tmp/backup/entrypoint.sh"]