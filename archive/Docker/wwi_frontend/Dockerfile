# Get the dotnet Build Environment:
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# COPY Project Files:
COPY ./src/WideWorldImporters.Client.sln .
COPY ./src/WideWorldImporters.Client/WideWorldImporters.Client.Blazor/*.csproj ./WideWorldImporters.Client/WideWorldImporters.Client.Blazor/
COPY ./src/WideWorldImporters.Client/WideWorldImporters.Client.Blazor.Shared/*.csproj ./WideWorldImporters.Client/WideWorldImporters.Client.Blazor.Shared/
COPY ./src/WideWorldImporters.Shared/WideWorldImporters.Shared.ApiSdk/*.csproj ./WideWorldImporters.Shared/WideWorldImporters.Shared.ApiSdk/

# And restore the NuGet Packages:
RUN dotnet restore

# COPY 
COPY ./src/WideWorldImporters.Client/. ./WideWorldImporters.Client/
COPY ./src/WideWorldImporters.Client/WideWorldImporters.Client.Blazor/. ./WideWorldImporters.Client/WideWorldImporters.Client.Blazor/
COPY ./src/WideWorldImporters.Client/WideWorldImporters.Client.Blazor.Shared/. ./WideWorldImporters.Client/WideWorldImporters.Client.Blazor.Shared/
COPY ./src/WideWorldImporters.Shared/WideWorldImporters.Shared.ApiSdk/. ./WideWorldImporters.Shared/WideWorldImporters.Shared.ApiSdk/

RUN dotnet publish WideWorldImporters.Client/WideWorldImporters.Client.Blazor/WideWorldImporters.Client.Blazor.csproj -c Release --no-restore -o /app

# Build the final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Copy Artifacts from Build:
WORKDIR /app
COPY --from=build /app ./

# And kick off the Blazor Client:
ENTRYPOINT ["dotnet", "WideWorldImporters.Client.Blazor.dll"]