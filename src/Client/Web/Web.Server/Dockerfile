# Dockerfile для Chat.Client.Web.Server
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Создаем пользователя для безопасности
RUN adduser --disabled-password --gecos '' appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Копируем файлы проектов и восстанавливаем зависимости
COPY ["Web/Web.Server/Chat.Client.Web.Server.csproj", "Web/Web.Server/"]
COPY ["Web/Web.Webassembly/Chat.Client.Web.Webassembly.csproj", "Web/Web.Webassembly/"]
COPY ["Common/Chat.Client.Common.csproj", "Common/"]

RUN dotnet restore "Web/Web.Server/Chat.Client.Web.Server.csproj"

# Копируем весь исходный код
COPY . .

# Переходим в директорию проекта и собираем
WORKDIR "/src/Web/Web.Server"
RUN dotnet build "Chat.Client.Web.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Chat.Client.Web.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Добавляем healthcheck
HEALTHCHECK --interval=30s --timeout=3s --start-period=5s --retries=3 \
  CMD curl -f http://localhost:8080/health || exit 1

ENTRYPOINT ["dotnet", "Chat.Client.Web.Server.dll"]