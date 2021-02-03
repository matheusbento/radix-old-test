FROM mcr.microsoft.com/mssql/server:2019-latest
ENV ACCEPT_EULA y
ENV SA_PASSWORD YourStrong!Passw0rd
COPY ./mssql/init.sql .
COPY ./mssql/entrypoint.sh .
EXPOSE 1433
USER root
CMD /bin/bash ./entrypoint.sh