# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy solution and project files
COPY ["Wolds.Hr.Api.Cr.sln", "./"]
COPY ["Wolds.Hr.Api.Cr/Wolds.Hr.Api.Cr.csproj", "Wolds.Hr.Api.Cr/"]
COPY ["Wolds.Hr.Api.Cr.Xunit/Wolds.Hr.Api.Cr.Xunit.csproj", "Wolds.Hr.Api.Cr.Xunit/"]

# Restore dependencies
RUN dotnet restore "Wolds.Hr.Api.Cr/Wolds.Hr.Api.Cr.csproj"

# Copy everything else
COPY . .

# Build and publish the API
RUN dotnet publish "Wolds.Hr.Api.Cr/Wolds.Hr.Api.Cr.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:5000
ENTRYPOINT ["dotnet", "Wolds.Hr.Api.Cr.dll"]
