# Consulte https://aka.ms/customizecontainer para aprender a personalizar su contenedor de depuración y cómo Visual Studio usa este Dockerfile para compilar sus imágenes para una depuración más rápida.

# Esta fase se usa cuando se ejecuta desde VS en modo rápido (valor predeterminado para la configuración de depuración)
FROM mcr.microsoft.com/dotnet/aspnet:7.0-jammy AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


# Esta fase se usa para compilar el proyecto de servicio
FROM mcr.microsoft.com/dotnet/sdk:7.0-jammy AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Matricula.UI/Matricula.UI.csproj", "Matricula.UI/"]
COPY ["Matricula.BL/Matricula.BL.csproj", "Matricula.BL/"]
COPY ["Matricula.DA/Matricula.DA.csproj", "Matricula.DA/"]
COPY ["Matricula.Modelo/Matricula.Model.csproj", "Matricula.Modelo/"]
RUN dotnet restore "./Matricula.UI/Matricula.UI.csproj"
COPY . .
WORKDIR "/src/Matricula.UI"
RUN dotnet build "./Matricula.UI.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase se usa para publicar el proyecto de servicio que se copiará en la fase final.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Matricula.UI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Matricula.UI.dll"]