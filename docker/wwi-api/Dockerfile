# Get the dotnet Build Environment:
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# COPY Project Files
COPY ../src/WideWorldImporters.Server.Api/*.csproj ./SqliteFulltextSearch.Api/
COPY ../src/WideWorldImporters.Server.Database/*.csproj ./WideWorldImporters.Server.Database/

# Restore NuGet Packages
RUN dotnet restore "WideWorldImporters.Server.Api/WideWorldImporters.Server.Api.csproj"

# COPY Projects
COPY ../src/WideWorldImporters.Server.Api/. ./src/WideWorldImporters.Server.Api/
COPY ../src/WideWorldImporters.Server.Database/. ./src/WideWorldImporters.Server.Database/

RUN dotnet publish ./src/WideWorldImporters.Server.Api/WideWorldImporters.Server.Api.csproj -c Release -o /app

# Build the final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Copy Artifacts from Build:
WORKDIR /app
COPY --from=build /app ./

# Start the Kestrel Server:
ENTRYPOINT ["dotnet", "WideWorldImporters.Server.Api.dll"]