FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["budget-app/budget-app.csproj", "budget-app/"]
RUN dotnet restore "budget-app/budget-app.csproj"
COPY . .
WORKDIR "/src/budget-app"
RUN dotnet build "budget-app.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "budget-app.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "budget-app.dll"]
