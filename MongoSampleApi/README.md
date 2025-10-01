# MongoSampleApi

Exemplo de API minimalista em **.NET 9** utilizando **MongoDB** como banco de dados. O projeto expõe endpoints REST para cadastro de tarefas (todos) e ilustra como configurar a injeção de `IMongoClient`, opções tipadas e um pequeno serviço de domínio.

## Pré-requisitos

- SDK do .NET 9 (pode ser substituído por .NET 8 apenas para experimentar o código)
- Instância do MongoDB disponível (ex.: `docker run --name mongo -p 27017:27017 -d mongo`)

## Configuração

Os detalhes de conexão ficam na seção `MongoDb` do `appsettings.json`:

```json
"MongoDb": {
  "ConnectionString": "mongodb://localhost:27017",
  "DatabaseName": "TodoSampleDb",
  "CollectionName": "todos"
}
```

Ajuste os valores conforme seu ambiente. No modo Development as mesmas configurações já são replicadas em `appsettings.Development.json`.

## Executando

Dentro da pasta `MongoSampleApi`:

```bash
DOTNET_CLI_HOME=$(pwd)/.dotnet dotnet restore
DOTNET_CLI_HOME=$(pwd)/.dotnet dotnet run
```

A aplicação sobe em `https://localhost:5001` (ou `http://localhost:5000`). A interface interativa do Swagger/OpenAPI fica disponível em `/swagger` quando executada em ambiente de desenvolvimento.

## Endpoints principais

- `GET /api/todos` – lista todas as tarefas
- `GET /api/todos/{id}` – obtém uma tarefa específica
- `POST /api/todos` – cria uma nova tarefa (`{ "title": "Comprar leite" }`)
- `PUT /api/todos/{id}` – atualiza título e status da tarefa (`{ "title": "Comprar leite", "isCompleted": true }`)
- `DELETE /api/todos/{id}` – remove uma tarefa

Os objetos retornados possuem o formato:

```json
{
  "id": "650ec9b27c9d6e274a6f5f1b",
  "title": "Comprar leite",
  "isCompleted": false,
  "createdAt": "2024-04-01T12:34:56Z"
}
```

## Estrutura do código

- `Program.cs` registra as opções do MongoDB, o `MongoClient` e o serviço de tarefas.
- `Configuration/MongoOptions.cs` contém a classe de configuração tipada.
- `Models/TodoItem.cs` define o documento armazenado na coleção.
- `Services/TodoService.cs` encapsula as operações de banco.
- `Endpoints/TodoEndpoints.cs` concentra o mapeamento dos endpoints minimal API.
- `Contracts/Requests` traz os DTOs de entrada para criação e atualização de tarefas.

Este projeto serve como ponto de partida para aplicações maiores; basta expandir o serviço, aplicar validações adicionais e configurar autenticação conforme necessário.
