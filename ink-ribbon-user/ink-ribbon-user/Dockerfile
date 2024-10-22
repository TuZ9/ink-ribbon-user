FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ink-ribbon-user/ink-ribbon-user.csproj", "ink-ribbon-user/"]
RUN dotnet restore "./ink-ribbon-user/ink-ribbon-user.csproj"
COPY . .
WORKDIR "/src/ink-ribbon-user"
RUN dotnet build "./ink-ribbon-user.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ink-ribbon-user.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ink-ribbon-user.dll"]