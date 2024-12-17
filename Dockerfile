#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8081
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Atividade03.API/Atividade03.API.csproj", "Atividade03.API/"]
COPY ["API.Aplicacao/API.Aplicacao.csproj","API.Aplicacao/"]
COPY ["API.Dominio/API.Dominio.csproj","API.Dominio/"]
COPY ["API.Repositorio/API.Repositorio.csproj","API.Repositorio/"]
COPY ["API.CrossCutting/API.CrossCutting.csproj","API.CrossCutting/"]
COPY ["API.Testes/API.Testes.csproj","API.Testes/"] 
RUN dotnet restore "Atividade03.API/Atividade03.API.csproj"
COPY . .
WORKDIR "/src/Atividade03.API"
RUN dotnet build "Atividade03.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Atividade03.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Atividade03.API.dll"]

# We then get the base image for Nginx and set the 
# work directory 
# FROM nginx:alpine
# WORKDIR /usr/share/nginx/html

# # # We'll copy all the contents from wwwroot in the publish
# # # folder into nginx/html for nginx to serve. The destination
# # # should be the same as what you set in the nginx.conf.
# COPY --from=publish /app/publish /usr/local/webapp/nginx/html
# COPY nginx.conf /etc/nginx/nginx.conf
# EXPOSE 8080