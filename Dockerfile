FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY . ./
WORKDIR /app/CAPSTONE   # 👈 IMPORTANT (go inside project folder)

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/CAPSTONE/out ./

EXPOSE 10000
ENTRYPOINT ["dotnet", "CAPSTONE.dll"]