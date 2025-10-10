# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy csproj and restore
COPY ["wolds-hr-api.csproj", "./"]
RUN dotnet restore "wolds-hr-api.csproj"

# Copy all source files
COPY . ./

# Build & publish
RUN dotnet publish "wolds-hr-api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:5000
ENTRYPOINT ["dotnet", "wolds-hr-api.dll"]

