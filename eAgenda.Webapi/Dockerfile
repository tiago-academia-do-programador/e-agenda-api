#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["eAgenda.Webapi/eAgenda.Webapi.csproj", "eAgenda.Webapi/"]
COPY ["eAgenda.Aplicacao/eAgenda.Aplicacao.csproj", "eAgenda.Aplicacao/"]
COPY ["eAgenda.Dominio/eAgenda.Dominio.csproj", "eAgenda.Dominio/"]
COPY ["eAgenda.Infra.Logging/eAgenda.Infra.Logging.csproj", "eAgenda.Infra.Logging/"]
COPY ["eAgenda.Infra.Configs/eAgenda.Infra.Configs.csproj", "eAgenda.Infra.Configs/"]
COPY ["eAgenda.Infra.Orm/eAgenda.Infra.Orm.csproj", "eAgenda.Infra.Orm/"]
RUN dotnet restore "eAgenda.Webapi/eAgenda.Webapi.csproj"
COPY . .
WORKDIR "/src/eAgenda.Webapi"
RUN dotnet build "eAgenda.Webapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eAgenda.Webapi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eAgenda.Webapi.dll"]