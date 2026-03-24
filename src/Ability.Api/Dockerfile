# Estágio de Runtime (Execução)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Estágio de Build (Construção)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
# Copia o arquivo de projeto e restaura as dependências
COPY ["Ability.Api.csproj", "."]
RUN dotnet restore "./Ability.Api.csproj"

# Copia o restante dos arquivos e compila
COPY . .
RUN dotnet build "Ability.Api.csproj" -c Release -o /app/build

# Publicação do projeto
FROM build AS publish
RUN dotnet publish "Ability.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Junta o runtime com os arquivos publicados
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ability.Api.dll"]