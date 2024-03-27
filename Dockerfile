FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

COPY . .
RUN dotnet restore

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final-env

WORKDIR /app
COPY --from=build-env /app/out .

EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "moneychamberapi.dll"]