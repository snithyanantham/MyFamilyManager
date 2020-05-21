#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src

COPY "./MyFamilyManager.sln" "MyFamilyManager.sln"
COPY "Services/Core/MyFamilyManager.API/MyFamilyManager.API.csproj", "Services/Core/MyFamilyManager.API/"
COPY ["Services/Core/MyFamilyManager.API.Repositories/MyFamilyManager.API.Repositories.csproj", "Services/Core/MyFamilyManager.API.Repositories/"]
COPY ["Services/Core/MyFamilyManager.API.Core/MyFamilyManager.API.Core.csproj", "Services/Core/MyFamilyManager.API.Core/"]
RUN dotnet restore "Services/Core/MyFamilyManager.API/MyFamilyManager.API.csproj"
COPY . .
WORKDIR "/src/Services/Core/MyFamilyManager.API"
RUN dotnet build "MyFamilyManager.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyFamilyManager.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyFamilyManager.API.dll"]
