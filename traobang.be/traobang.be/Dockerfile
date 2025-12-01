# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["traobang.be/traobang.be.csproj", "traobang.be/"]
COPY ["traobang.be.application/traobang.be.application.csproj", "traobang.be.application/"]
COPY ["traobang.be.infrastructure.data/traobang.be.infrastructure.data.csproj", "traobang.be.infrastructure.data/"]
COPY ["traobang.be.domain/traobang.be.domain.csproj", "traobang.be.domain/"]
COPY ["traobang.be.shared/traobang.be.shared.csproj", "traobang.be.shared/"]
COPY ["traobang.be.infrastructure.external/traobang.be.infrastructure.external.csproj", "traobang.be.infrastructure.external/"]
RUN dotnet restore "./traobang.be/traobang.be.csproj"
COPY . .
WORKDIR "/src/traobang.be"
RUN dotnet build "./traobang.be.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./traobang.be.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "traobang.be.dll"]