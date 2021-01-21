FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["observableapp.csproj", "./"]
RUN dotnet restore "observableapp.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "observableapp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "observableapp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "observableapp.dll"]
