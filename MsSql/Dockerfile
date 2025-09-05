FROM mcr.microsoft.com/mssql/server:2022-latest
EXPOSE 1433

ENV ACCEPT_EULA Y
ENV MSSQL_SA_PASSWORD Test1234=
ENV MSSQL_DATA_DIR /var/opt/mssql/data
ENV MSSQL_PID Developer 
ENV MSSQL_TCP_PORT 1433 

WORKDIR /scripts
COPY /MsSql/scripts .
ENTRYPOINT [ "/scripts/entrypoint.sh" ]

