FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["src/Services/TripManagement/TripManagement.API/TripManagement.API.csproj", "src/Services/TripManagement/TripManagement.API/"]
RUN dotnet restore "src/Services/TripManagement/TripManagement.API/TripManagement.API.csproj"
COPY . .
WORKDIR "/src/src/Services/TripManagement/TripManagement.API"
RUN dotnet build "TripManagement.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TripManagement.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TripManagement.API.dll"]