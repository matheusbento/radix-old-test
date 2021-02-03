#!/bin/bash

sleep 10

export PATH="$PATH:/root/.dotnet/tools";

curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add -;
curl https://packages.microsoft.com/config/ubuntu/16.04/prod.list | tee /etc/apt/sources.list.d/msprod.list;
apt-get update;
apt-get install -y mssql-tools;

set -e
run_cmd="dotnet run --server.urls http://0.0.0.0:5000;http://0.0.0.0:5001 -p /src/RadixTest.API/RadixTest.API.csproj"

cd /src/RadixTest.Infra;

until dotnet ef database update --startup-project ../RadixTest.API/RadixTest.API.csproj; do
>&2 echo "SQL Server is starting up"
sleep 1
done

/opt/mssql-tools/bin/sqlcmd -S radix-mssql -l 60 -U SA -P 'YourStrong!Passw0rd' -i /app/example-data.sql;

cd /app;

>&2 echo "SQL Server is up - executing command"
exec $run_cmd