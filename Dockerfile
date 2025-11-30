# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy solution file and project file
COPY ["Io Built.sln", "."]
COPY ["IoBuilt.API/IoBuilt.API.csproj", "IoBuilt.API/"]

# Restore dependencies
RUN dotnet restore "Io Built.sln"

# Copy all source code
COPY . .

# Build the project
WORKDIR "/src/IoBuilt.API"
RUN dotnet build "IoBuilt.API.csproj" -c Release -o /app/build

# Publish the project
RUN dotnet publish "IoBuilt.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

# Copy published files from build stage
COPY --from=build /app/publish .

# Configure port (Railway will override this with its own PORT variable)
ENV PORT=8080
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT}
EXPOSE ${PORT}

# Configure globalization
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1

# Entry point
ENTRYPOINT ["dotnet", "IoBuilt.API.dll"]
