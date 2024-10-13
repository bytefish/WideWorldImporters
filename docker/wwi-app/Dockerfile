# Get the dotnet Build Environment:
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# COPY Project Files
COPY ../src/SqliteFulltextSearch.Web.Client/*.csproj ./SqliteFulltextSearch.Web.Client/
COPY ../src/SqliteFulltextSearch.Web.Server/*.csproj ./SqliteFulltextSearch.Web.Server/
COPY ../src/SqliteFulltextSearch.Shared/*.csproj ./SqliteFulltextSearch.Shared/

# And restore the NuGet Packages:
RUN dotnet restore "SqliteFulltextSearch.Web.Server/SqliteFulltextSearch.Web.Server.csproj"

# COPY Projects
COPY ../src/SqliteFulltextSearch.Web.Client/. ./src/SqliteFulltextSearch.Web.Client/
COPY ../src/SqliteFulltextSearch.Web.Server/. ./src/SqliteFulltextSearch.Web.Server/
COPY ../src/SqliteFulltextSearch.Shared/. ./src/SqliteFulltextSearch.Shared/

RUN dotnet publish ./src/SqliteFulltextSearch.Web.Server/SqliteFulltextSearch.Web.Server.csproj -c Release -o /app

# Build the final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Copy Artifacts from Build:
WORKDIR /app
COPY --from=build /app ./

# Start the Kestrel Server:
ENTRYPOINT ["dotnet", "SqliteFulltextSearch.Web.Server.dll"]