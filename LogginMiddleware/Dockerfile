FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["LogginMiddleware/LogginMiddleware.csproj", "LogginMiddleware/"]
RUN dotnet restore "LogginMiddleware/LogginMiddleware.csproj"
COPY . .
WORKDIR "/src/LogginMiddleware"
RUN dotnet build "LogginMiddleware.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "LogginMiddleware.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LogginMiddleware.dll"]