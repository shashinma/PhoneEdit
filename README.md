# PhoneEdit

[![.NET](https://github.com/shashinma/PhoneEdit/actions/workflows/dotnet.yml/badge.svg?branch=dev)](https://github.com/shashinma/PhoneEdit/actions/workflows/dotnet.yml)
[![Docker Image CI](https://github.com/shashinma/PhoneEdit/actions/workflows/docker-image.yml/badge.svg)](https://github.com/shashinma/PhoneEdit/actions/workflows/docker-image.yml)


### Deploying:
>docker-compose.yml
```yml
version: '3.8'
name: rtcservices
services:
  phoneedit:
    container_name: phoneedit
    image: ghcr.io/shashinma/phoneedit:latest
    restart: unless-stopped
    build:
      context: .
      dockerfile: Dockerfile
    ports:
      - <container_port>:8080
    networks:
      phoneedit_net:
        ipv4_address: <ip_address>
    environment:
      ASPNETCORE_ENVIRONMENT: Production
      ConnectionStrings__IdentityContext: DataSource=IdentityContext.db;Cache=Shared
      ConnectionStrings__PhoneBookContext: Server=<mysql_server_ip>;Database=<mysql_db_name>;user=<username>;password=<password>
      DefaultUser__Username: <your_username>
      DefaultUser__Password: <your_password>
networks:
  phoneedit_net:
    driver: bridge
    ipam:
     config:
       - subnet: <subnet_ip>/<subnet_mask>
```      
