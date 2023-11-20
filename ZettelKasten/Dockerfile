FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
EXPOSE 8080
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 8080

WORKDIR /app
COPY --from=build-env /app/publish .
ENTRYPOINT ["dotnet", "ZettelKasten.dll"]