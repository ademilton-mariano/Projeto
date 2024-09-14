# Usar uma imagem base para o SDK do .NET 8
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar o arquivo .csproj e restaurar as dependências
COPY *.csproj ./
RUN dotnet restore

# Copiar o resto do código e compilar a aplicação
COPY . ./
RUN dotnet publish -c Release -o /out

# Usar uma imagem mais leve do runtime para executar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out .

# Expor a porta que a aplicação vai utilizar
EXPOSE 80

# Definir o ponto de entrada da aplicação
ENTRYPOINT ["dotnet", "Projeto.dll"]
