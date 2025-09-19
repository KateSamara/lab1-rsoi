FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY ./src/Person ./Person

RUN dotnet restore ./Person/Person.sln

RUN dotnet build ./Person/Person.sln -c Release

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS release

WORKDIR /app

COPY --from=build /app/Person/Person.Web.Api/bin/Release/net8.0 ./Person