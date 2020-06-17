#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CarDieseMsSolution/CarDieseMsSolution.csproj", "CarDieseMsSolution/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["DieselCarDataAccess/DieselCarDataAccess.csproj", "DieselCarDataAccess/"]
COPY ["KafkaService/KafkaService.csproj", "KafkaService/"]
RUN dotnet restore "CarDieseMsSolution/CarDieseMsSolution.csproj"
COPY . .
WORKDIR "/src/CarDieseMsSolution"
RUN dotnet build "CarDieseMsSolution.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarDieseMsSolution.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarDieseMsSolution.dll"]