# PhoneEdit

[![.NET](https://github.com/shashinma/PhoneEdit/actions/workflows/dotnet.yml/badge.svg?branch=dev)](https://github.com/shashinma/PhoneEdit/actions/workflows/dotnet.yml)
[![Docker Image CI](https://github.com/shashinma/PhoneEdit/actions/workflows/docker-image.yml/badge.svg)](https://github.com/shashinma/PhoneEdit/actions/workflows/docker-image.yml)


### Deploying:
>docker-compose.yml
```yml
version: '3.8'
name: compose_name
services:
  phoneedit:
    container_name: container_name
    image: ghcr.io/shashinma/phoneedit:latest
    build:
      context: .
      dockerfile: Dockerfile
    ports:
      - <port>:8080
    environment:
      ASPNETCORE_ENVIRONMENT: Production
      ConnectionStrings__IdentityContext: DataSource=IdentityContext.db;Cache=Shared
      ConnectionStrings__PhoneBookContext: Server=<mysql_server_ip>;Database=<mysql_db_name>;user=<username>;password=<password>
      USERNAME: your_username
      PASSWORD: your_password
```      
