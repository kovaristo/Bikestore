FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BikeStores.API/BikeStores.API.csproj", "BikeStores.API/"]
RUN dotnet restore "BikeStores.API/BikeStores.API.csproj"
COPY . .
WORKDIR "/src/BikeStores.API"
RUN dotnet build "BikeStores.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BikeStores.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BikeStores.API.dll"]