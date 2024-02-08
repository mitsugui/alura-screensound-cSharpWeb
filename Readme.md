# Screen Sound - sistema de cadastro e artistas e músicas

## 01. Uso do Banco de Dados

Projeto simples criado com intuito de acompanhar as aulas do curso:
- .NET: persistindo dados com Entity Framework Core

Não segue nenhuma das boas práticas de segurança.


## Execução do banco de dados

docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=ScR33n$ound" -e "MSSQL_PID=Evaluation" -p 11433:1433  --name ScreenSoundDatabase --hostname ScreenSoundDatabase -d mcr.microsoft.com/mssql/server:2022-preview-ubuntu-22.04

## O banco de dados é criado utilizando Migrations

Instale os pacotes Microsoft.EntityFrameworkCore.Design e Microsoft.EntityFrameworkCore.Tools.
No Package Manager Console (Tools > NuGet Package Manager) digite Update-Database para executar a migração.
