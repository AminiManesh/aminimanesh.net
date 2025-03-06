FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src

COPY ["Aminimanesh.Web/Aminimanesh.Web.csproj", "Aminimanesh.Web/"]
COPY ["Aminimanesh.Core/Aminimanesh.Core.csproj", "Aminimanesh.Core/"]
COPY ["Aminimanesh.DataLayer/Aminimanesh.DataLayer.csproj", "Aminimanesh.DataLayer/"]

RUN dotnet restore "Aminimanesh.Web/Aminimanesh.Web.csproj"

COPY . .
WORKDIR "/src/Aminimanesh.Web"
RUN dotnet build "Aminimanesh.Web.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Aminimanesh.Web.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aminimanesh.Web.dll"]
