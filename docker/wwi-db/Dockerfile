FROM mcr.microsoft.com/mssql/server:2022-latest

WORKDIR /tmp/backup

# Install Packages, because built-in sqlcmd has a bug ...
USER root

RUN apt-get update \
    && ACCEPT_EULA=Y apt-get install mssql-tools18 unixodbc-dev -y \
    && wget -q  https://github.com/Microsoft/sql-server-samples/releases/download/wide-world-importers-v1.0/WideWorldImporters-Full.bak
    
COPY ./restore.sql .
COPY ./security.sql .
COPY ./users.sql .
COPY ./create-db.sh .
COPY ./entrypoint.sh .

ENTRYPOINT ["/bin/bash", "/tmp/backup/entrypoint.sh"]