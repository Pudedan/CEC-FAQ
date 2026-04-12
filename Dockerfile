FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY . ./
WORKDIR /app/CAPSTONE/CAPSTONE

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/CAPSTONE/CAPSTONE/out ./

EXPOSE 10000
ENTRYPOINT ["dotnet", "CAPSTONE.dll"]