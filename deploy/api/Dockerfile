#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base

ARG BUILD_CONFIGURATION=Debug
ENV ASPNETCORE_ENVIRONMENT=Development
ENV DOTNET_USE_POLLING_FILE_WATCHER=true
ENV ASPNETCORE_URLS=http://+:5000;http://+:5001
ENV ACCEPT_EULA y

EXPOSE 5000
EXPOSE 5001

WORKDIR /src
COPY ["server/RadixTest.API/RadixTest.API.csproj", "RadixTest.API/"]
COPY ["server/RadixTest.Infra/RadixTest.Infra.csproj", "RadixTest.Infra/"]
COPY ["server/RadixTest.Domain/RadixTest.Domain.csproj", "RadixTest.Domain/"]

RUN dotnet restore "RadixTest.API/RadixTest.API.csproj" -r linux-arm64

COPY server .

WORKDIR "/src/RadixTest.API"

RUN dotnet build "RadixTest.API.csproj" -c Release -o /app/build

FROM base AS publish
RUN dotnet publish "RadixTest.API.csproj" -c Release -o /app/publish

FROM base AS final

WORKDIR "/app"
COPY mssql/example-data.sql .
COPY --from=publish /app/publish .
COPY server/entrypoint.sh entrypoint

RUN chmod 0777 entrypoint

RUN dotnet tool install --global dotnet-ef --version 3.1.10

ENTRYPOINT ["sh", "entrypoint"]