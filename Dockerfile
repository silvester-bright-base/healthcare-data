FROM postgres:13.2-alpine

ENV POSTGRES_DB database_brightbase_healthcare
ENV POSTGRES_USER postgres
ENV POSTGRES_PORT 5432
ENV POSTGRES_PASSWORD password

COPY seed.sql docker-entrypoint-initdb.d/seed.sql
CMD ["postgres"]