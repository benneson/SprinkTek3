#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/SprintTek.Migrator/SprintTek.Migrator.csproj", "src/SprintTek.Migrator/"]
COPY ["src/SprintTek.EntityFrameworkCore/SprintTek.EntityFrameworkCore.csproj", "src/SprintTek.EntityFrameworkCore/"]
COPY ["src/SprintTek.Core/SprintTek.Core.csproj", "src/SprintTek.Core/"]
COPY ["src/SprintTek.Core.Shared/SprintTek.Core.Shared.csproj", "src/SprintTek.Core.Shared/"]
RUN dotnet restore "src/SprintTek.Migrator/SprintTek.Migrator.csproj"
COPY . .
WORKDIR "/src/src/SprintTek.Migrator"
RUN dotnet build "SprintTek.Migrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SprintTek.Migrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SprintTek.Migrator.dll"]
