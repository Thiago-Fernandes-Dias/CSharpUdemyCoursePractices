FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WhereLINQTest/WhereLINQTest.csproj", "WhereLINQTest/"]
RUN dotnet restore "WhereLINQTest/WhereLINQTest.csproj"
COPY . .
WORKDIR "/src/WhereLINQTest"
RUN dotnet build "WhereLINQTest.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "WhereLINQTest.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WhereLINQTest.dll"]
