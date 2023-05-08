FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["iDent.API/iDent.API.csproj", "iDent.API/"]
COPY ["iDent.ModelLibrary/iDent.ModelLibrary.csproj", "iDent.ModelLibrary/"]
RUN dotnet restore "iDent.API/iDent.API.csproj"
COPY . .
WORKDIR "/src/iDent.API"
RUN dotnet build "iDent.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "iDent.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "iDent.API.dll"]