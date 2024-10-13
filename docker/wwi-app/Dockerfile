# Get the dotnet Build Environment:
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# COPY Project Files
COPY ../src/WideWorldImporters.Web.Client/*.csproj ./WideWorldImporters.Web.Client/
COPY ../src/WideWorldImporters.Web.Server/*.csproj ./WideWorldImporters.Web.Server/
COPY ../src/WideWorldImporters.Shared/*.csproj ./WideWorldImporters.Shared/
COPY ../src/WideWorldImporters.Shared.ApiSdk/*.csproj ./WideWorldImporters.Shared.ApiSdk/

# And restore the NuGet Packages:
RUN dotnet restore "WideWorldImporters.Web.Server/WideWorldImporters.Web.Server.csproj"

# COPY Projects
COPY ../src/WideWorldImporters.Web.Client/. ./src/WideWorldImporters.Web.Client/
COPY ../src/WideWorldImporters.Web.Server/. ./src/WideWorldImporters.Web.Server/
COPY ../src/WideWorldImporters.Shared/. ./src/WideWorldImporters.Shared/
COPY ../src/WideWorldImporters.Shared.ApiSdk/. ./src/WideWorldImporters.Shared.ApiSdk/

RUN dotnet publish ./src/WideWorldImporters.Web.Server/WideWorldImporters.Web.Server.csproj -c Release -o /app

# Build the final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Copy Artifacts from Build:
WORKDIR /app
COPY --from=build /app ./

# Start the Kestrel Server:
ENTRYPOINT ["dotnet", "WideWorldImporters.Web.Server.dll"]