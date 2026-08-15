FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY src/DanceOClock.Api/DanceOClock.Api.csproj src/DanceOClock.Api/
COPY src/DanceOClock.Data/DanceOClock.Data.csproj src/DanceOClock.Data/
RUN dotnet restore src/DanceOClock.Api/DanceOClock.Api.csproj
COPY src/ src/
RUN dotnet publish src/DanceOClock.Api/DanceOClock.Api.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "DanceOClock.Api.dll"]
