FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["src/Services/UserManagement/UserManagement.API/UserManagement.API.csproj", "src/Services/UserManagement/UserManagement.API/"]
RUN dotnet restore "src/Services/UserManagement/UserManagement.API/UserManagement.API.csproj"
COPY . .
WORKDIR "/src/src/Services/UserManagement/UserManagement.API"
RUN dotnet build "UserManagement.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "UserManagement.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "UserManagement.API.dll"]