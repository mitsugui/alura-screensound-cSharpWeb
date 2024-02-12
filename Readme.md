# Screen Sound - sistema de cadastro e artistas e músicas

Projeto simples criado com intuito de acompanhar as aulas dos cursos:
- .NET: persistindo dados com Entity Framework Core.
- .NET: criando uma API Web com ASPNET Core.

## Descrição

Projeto composto por:
- API Web que permite o cadastro de artistas e músicas
- Um projeto Console que consome mesmo banco de dados.
- Um projeto de banco de dados com Migrations.
- Bibliotecas auxiliares para compatilhamento de código.


O projeto foi criado utilizando .NET 8.0 e Entity Framework Core.


## Execução do banco de dados

docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=ScR33n$ound" -e "MSSQL_PID=Evaluation" -p 11433:1433  --name ScreenSoundDatabase --hostname ScreenSoundDatabase -d mcr.microsoft.com/mssql/server:2022-preview-ubuntu-22.04

## O banco de dados é criado utilizando Migrations

Instale os pacotes Microsoft.EntityFrameworkCore.Design e Microsoft.EntityFrameworkCore.Tools.
No Package Manager Console (Tools > NuGet Package Manager) digite Update-Database para executar a migração.
