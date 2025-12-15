# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BMTH Application (back end)/BMTH Application (back end)/BMTH Application (back end).csproj", "BMTH Application (back end)/BMTH Application (back end)/"]
COPY ["BMTH Application (back end)/BMTH Application (back end)/appsettings.json", "BMTH Application (back end)/BMTH Application (back end)/"]
COPY ["BMTH Application (back end)/BMTH Application (back end)/appsettings.Development.json", "BMTH Application (back end)/BMTH Application (back end)/"]
COPY ["BMTH Application (back end)/BusinessLayer/BusinessLayer.csproj", "BMTH Application (back end)/BusinessLayer/"]
COPY ["BMTH Application (back end)/Contracts/Contracts.csproj", "BMTH Application (back end)/Contracts/"]
COPY ["BMTH Application (back end)/DataLayer/DataLayer.csproj", "BMTH Application (back end)/DataLayer/"]
COPY ["BMTH Application (back end)/BMTH Application (back end)/wwwroot", "BMTH Application (back end)/BMTH Application (back end)/wwwroot"]
RUN dotnet restore "BMTH Application (back end)/BMTH Application (back end)/BMTH Application (back end).csproj"
COPY . .
WORKDIR "/src/BMTH Application (back end)/BMTH Application (back end)"
RUN dotnet build "BMTH Application (back end).csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "BMTH Application (back end).csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
EXPOSE 8080
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Development
ENTRYPOINT ["dotnet", "BMTH Application (back end).dll"]
