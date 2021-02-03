#!/bin/bash
# Run init-script with long timeout - and make it run in the background
/opt/mssql-tools/bin/sqlcmd -S radix-mssql -l 60 -U SA -P "YourStrong!Passw0rd" -i init.sql & 
# Start SQL server
/opt/mssql/bin/sqlservr