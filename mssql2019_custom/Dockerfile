FROM mcr.microsoft.com/mssql/server:2019-latest

ENV ACCEPT_EULA=Y
ENV MSSQL_SA_PASSWORD=P@ssw0rd
ENV MSSQL_DB=CustomDB
ENV MSSQL_USER=customuser
ENV MSSQL_PASSWORD=P@ssw0rd

USER root

RUN mkdir -p /usr/config
RUN mkdir -p /var/log/config
WORKDIR /usr/config
COPY ./entrypoint.sh /usr/config
COPY ./configure_db.sh /usr/config
COPY ./setup.sql /usr/config

RUN apt-get update && apt-get install -y vim

RUN chmod u+x /usr/config/entrypoint.sh
RUN chmod u+x /usr/config/configure_db.sh
RUN chown mssql /var/log/config
RUN vim /usr/config/entrypoint.sh -c "set ff=unix" -c ":wq" 
RUN vim /usr/config/configure_db.sh -c "set ff=unix" -c ":wq" 

USER mssql 

ENTRYPOINT ["/usr/config/entrypoint.sh"]

CMD ["tail -f /dev/null"]

HEALTHCHECK --interval=15s CMD /opt/mssql-tools/bin/sqlcmd -U sa -P $MSSQL_SA_PASSWORD -Q "select 1" && grep -q "MSSQL CONFIG COMPLETE" ./config.log