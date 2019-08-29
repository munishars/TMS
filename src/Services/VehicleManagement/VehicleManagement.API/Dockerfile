FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["src/Services/VehicleManagement/VehicleManagement.API/VehicleManagement.API.csproj", "src/Services/VehicleManagement/VehicleManagement.API/"]
RUN dotnet restore "src/Services/VehicleManagement/VehicleManagement.API/VehicleManagement.API.csproj"
COPY . .
WORKDIR "/src/src/Services/VehicleManagement/VehicleManagement.API"
RUN dotnet build "VehicleManagement.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "VehicleManagement.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "VehicleManagement.API.dll"]