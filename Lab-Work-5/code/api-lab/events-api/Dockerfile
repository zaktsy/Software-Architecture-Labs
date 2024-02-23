FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5400

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["events-api/events-api.csproj", "events-api/"]
RUN dotnet restore "events-api/events-api.csproj"
COPY . .
WORKDIR "/src/events-api"
RUN dotnet build "events-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "events-api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "events-api.dll"]
