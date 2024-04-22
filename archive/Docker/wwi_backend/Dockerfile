# Get the dotnet Build Environment:
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# COPY Project Files:
COPY ./src/WideWorldImporters.Server.sln .
COPY ./src/WideWorldImporters.Server/WideWorldImporters.Server.Api/*.csproj ./WideWorldImporters.Server/WideWorldImporters.Server.Api/
COPY ./src/WideWorldImporters.Server/WideWorldImporters.Server.Database/*.csproj ./WideWorldImporters.Server/WideWorldImporters.Server.Database/

# And restore the NuGet Packages:
RUN dotnet restore

# COPY 
COPY ./src/WideWorldImporters.Server/. ./WideWorldImporters.Server/
COPY ./src/WideWorldImporters.Server/WideWorldImporters.Server.Api/. ./WideWorldImporters.Server/WideWorldImporters.Server.Api/
COPY ./src/WideWorldImporters.Server/WideWorldImporters.Server.Database/. ./WideWorldImporters.Server/WideWorldImporters.Server.Database/

RUN dotnet publish WideWorldImporters.Server/WideWorldImporters.Server.Api/WideWorldImporters.Server.Api.csproj -c release -o /app

# Build the final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Copy Artifacts from Build:
WORKDIR /app
COPY --from=build /app ./

# And kick off the Blazor Client:
ENTRYPOINT ["dotnet", "WideWorldImporters.Server.Api.dll"]