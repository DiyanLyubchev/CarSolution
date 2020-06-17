#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CarGasMsSolution/CarGasMsSolution.csproj", "CarGasMsSolution/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["GasCarDataAccess/GasCarDataAccess.csproj", "GasCarDataAccess/"]
COPY ["KafkaService/KafkaService.csproj", "KafkaService/"]
RUN dotnet restore "CarGasMsSolution/CarGasMsSolution.csproj"
COPY . .
WORKDIR "/src/CarGasMsSolution"
RUN dotnet build "CarGasMsSolution.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarGasMsSolution.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarGasMsSolution.dll"]