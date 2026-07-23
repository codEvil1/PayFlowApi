# =========================
# Build
# =========================

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

COPY . .

RUN dotnet restore ./PayFlow.Api/PayFlow.Api.csproj

RUN dotnet publish ./PayFlow.Api/PayFlow.Api.csproj \
    -c Release \
    -o /app/publish \
    --no-restore

# =========================
# Runtime
# =========================

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "PayFlow.Api.dll"]
