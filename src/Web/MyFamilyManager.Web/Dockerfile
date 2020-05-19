#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_10.x | bash \
    && apt-get install nodejs -yq
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build

RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_10.x | bash \
    && apt-get install nodejs -yq

WORKDIR /src
COPY ["MyFamilyManager.Web.csproj", "Web/MyFamilyManager.Web/"]
RUN dotnet restore "Web/MyFamilyManager.Web/MyFamilyManager.Web.csproj"
COPY . .
WORKDIR "/src/Web/MyFamilyManager.Web"

RUN dotnet build "MyFamilyManager.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyFamilyManager.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyFamilyManager.Web.dll"]
