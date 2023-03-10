FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src
COPY . /src/
WORKDIR "/src/budget-app"
RUN dotnet build "budget-app.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "budget-app.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "budget-app.dll"]
