# Gestão Biblioteca 

**__Gestão Biblioteca__** é um ASP.NET MVC para estudos.

## Guia

[ASP.NET MVC - Este guia mostra como estruturar uma solução de multiprojetos para um aplicativo da web simples usando o Entity Framework e o padrão de design Model-View-ViewModel (MVVM) junto com o padrão de repositório..


## Solution Projects

| Project | Application Layer |
| :--- | :--- |
| GestaoBiblioteca.Common | Classes Comuns |
| GestaoBiblioteca.Data | Data Context e Repositories |
| GestaoBiblioteca.Entities | Data Entities |
| GestaoBiblioteca.Tests | Não implementado |
| GestaoBiblioteca| Interface do usuário (views) and lógica de negócios  (controllers) |

## 
Tecnologias

| Dependência | Versão*
| :--- | ---:
| .NET Framework | 4.7.2
| ASP.NET MVC | 5.2.7
| Bootstrap | 3.4.1
| C# | 6
| Entity Framework | 6.4.4
| jQuery | 3.5.1
| jQuery Validation | 1.19.3
| Microsoft Identity | 2.2.1
| Microsoft jQuery Unobtrusive Validation | 3.2.12
| Newtonsoft.Json | 12.0.3

&ast; A partir do último commit.

## Começando

1. Baixe ou clone este repositório.
1. Abra a solução no Visual Studio 2019 ou superior.
1. Selecione o projeto ** GestaoBiblioteca.Data **.
1. Abra uma janela do console do gerenciador de pacotes.
1. Selecione "GestaoBiblioteca.Data" para ** Projeto padrão **.
1. Execute: `Update-Database`.

Isso criará o banco de dados, aplicará as migrações do Entity Framework 

## Configuração

* Dois projetos contêm strings de configuração que podem exigir modificações para o ambiente específico do desenvolvedor:

    | Projeto | Arquivo
    | :--- | :---
    | GestaoBiblioteca.Data | App.config
    | GestaoBiblioteca | Web.config

* As strings de configuração especificam a instância do SQL Server LocalDB como o servidor de banco de dados de destino: `Data Source=(localdb)\MSSQLLocalDB`. Os desenvolvedores que usam um banco de dados de destino diferente terão que alterar as cadeias de conexão em ambos os projetos.

## TODO

Dados para contato no cadastro de pessoas não implementado ainda.
