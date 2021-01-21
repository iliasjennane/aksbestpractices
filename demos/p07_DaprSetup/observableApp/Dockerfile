FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["observableApp.csproj", "./"]
RUN dotnet restore "observableApp.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "observableApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "observableApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT Development
ENTRYPOINT ["dotnet", "observableApp.dll"]
