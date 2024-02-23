FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5500

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["tickets-api/tickets-api.csproj", "tickets-api/"]
RUN dotnet restore "tickets-api/tickets-api.csproj"
COPY . .
WORKDIR "/src/tickets-api"
RUN dotnet build "tickets-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "tickets-api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "tickets-api.dll"]
