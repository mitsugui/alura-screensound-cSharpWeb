# .NET: persistindo dados com Entity Framework Core

## 01. Uso do Banco de Dados

Projeto simples criado com intuito de acompanhar as aulas.
Não segue nenhuma das boas práticas de segurança.


## Execução do banco de dados

docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=ScR33n$ound" -e "MSSQL_PID=Evaluation" -p 1433:1433  --name ScreenSoundDatabase --hostname ScreenSoundDatabase -d mcr.microsoft.com/mssql/server:2022-preview-ubuntu-22.04

## Consultas para criação do banco de dados SQL
```sql
CREATE TABLE Artistas(
        Id INT PRIMARY KEY IDENTITY(1,1),
        Nome NVARCHAR(255) NOT NULL,
        Bio NVARCHAR(255) NOT NULL,
        FotoPerfil NVARCHAR(255) NOT NULL
);

CREATE TABLE [dbo].[Musicas] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Nome] NVARCHAR (255) NOT NULL
);
```
