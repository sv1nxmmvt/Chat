# Убедитесь, что развертываемый кластер Service Fabric поддерживает используемый образ контейнера. Сведения о совместимости версий контейнеров Windows см. на странице https://aka.ms/containerimagehelp.
FROM mcr.microsoft.com/dotnet/aspnet:9.0-nanoserver-1809
ARG source
WORKDIR /app
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "Chat.Client.Web.Webassembly.dll"]
