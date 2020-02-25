# App para Agendamento de Reuniões

## Objetivo

Sistema simples de agendamento de horário nas salas de reuniões presentes na empresa

## Recursos necessários que foram utilizados no projeto

- SQL Server
- NPM e Yarn (necessário para rodar o FrontEnd)
- .NET Core 3.1

## Como rodar projeto

- Abrir o arquivo arquivo localizado em Data/StoreDataContext.cs
  \*\*Editar o parametro do método optionsBuilder.UseSqlServer, inserindo as informações referente ao seu Banco de Dados
- Para popular a base de dados, via terminal, rode os seguintes comandos dentro da pasta do projeto:
  ```
  dotnet restore
  dotnet ef database update
  dotnet run
  ```
- Para instalar as dependencias do frontend, vá até a pasta **Web** e rode o seguinte comando:
  ```
  yarn install
  yarn serve
  ```
- Por padrão a aplicação sobe em http://localhost:8080 e a API fica em http://localhost:5000
- **Observação: Se a API alterar de endereço. editar o arquivo localizado em "Web/src/helpers/services.js" e alterar a baseURL da variavel axiosInstance (linha 4)**

## Documentação API

Documentação da API fica localizada por padrão no seguinte endereço: http://localhost:5000/swagger/
