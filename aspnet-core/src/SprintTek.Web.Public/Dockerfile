#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/SprintTek.Web.Public/SprintTek.Web.Public.csproj", "src/SprintTek.Web.Public/"]
COPY ["src/SprintTek.Web.Core/SprintTek.Web.Core.csproj", "src/SprintTek.Web.Core/"]
COPY ["src/SprintTek.Application/SprintTek.Application.csproj", "src/SprintTek.Application/"]
COPY ["src/SprintTek.Application.Shared/SprintTek.Application.Shared.csproj", "src/SprintTek.Application.Shared/"]
COPY ["src/SprintTek.Core.Shared/SprintTek.Core.Shared.csproj", "src/SprintTek.Core.Shared/"]
COPY ["src/SprintTek.Core/SprintTek.Core.csproj", "src/SprintTek.Core/"]
COPY ["src/SprintTek.EntityFrameworkCore/SprintTek.EntityFrameworkCore.csproj", "src/SprintTek.EntityFrameworkCore/"]
COPY ["src/SprintTek.GraphQL/SprintTek.GraphQL.csproj", "src/SprintTek.GraphQL/"]
RUN dotnet restore "src/SprintTek.Web.Public/SprintTek.Web.Public.csproj"
COPY . .
WORKDIR "/src/src/SprintTek.Web.Public"
RUN dotnet build "SprintTek.Web.Public.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SprintTek.Web.Public.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SprintTek.Web.Public.dll"]
