FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY src/LoyaltyService/LoyaltyService.csproj LoyaltyService/
RUN dotnet restore LoyaltyService/LoyaltyService.csproj
COPY src/LoyaltyService/ LoyaltyService/
RUN dotnet publish LoyaltyService/LoyaltyService.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "LoyaltyService.dll"]
