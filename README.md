# RabbitMQ .NET Samples

This repository contains minimal C# console applications that show how to publish and consume messages with [RabbitMQ](https://www.rabbitmq.com/).

## Projects

- **Producer** (`src/Producer`) – reads lines from standard input and publishes them to a queue.
- **Consumer** (`src/Consumer`) – listens to the same queue and prints the messages it receives.

Both projects target .NET 8.0 and rely on the [`RabbitMQ.Client`](https://www.nuget.org/packages/RabbitMQ.Client) package.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download) (for building and running the console apps)
- A RabbitMQ broker. You can start one quickly with Docker:

  ```bash
  docker run -it --rm -p 5672:5672 -p 15672:15672 rabbitmq:3-management
  ```

  The default username and password are both `guest`.

## Running the sample

1. Restore the dependencies:

   ```bash
   dotnet restore RabbitMqSamples.sln
   ```

2. Start the consumer in one terminal:

   ```bash
   dotnet run --project src/Consumer
   ```

3. Start the producer in another terminal and send a few messages:

   ```bash
   dotnet run --project src/Producer
   ```

   Type some text and press <kbd>Enter</kbd> to publish each message. Submit an empty line to stop the producer.

Environment variables are available for overriding the RabbitMQ connection settings:

- `RABBITMQ_HOST` (default `localhost`)
- `RABBITMQ_PORT` (default `5672`)
- `RABBITMQ_USERNAME` (default `guest`)
- `RABBITMQ_PASSWORD` (default `guest`)

Set the same variables for both producer and consumer if your RabbitMQ broker uses custom credentials.
=======
# C# REST API CRUD Example with Swagger

This sample demonstrates a simple ASP.NET Core Web API that exposes CRUD operations for a collection of books. It uses an in-memory repository and comes preconfigured with Swagger/OpenAPI support.

## Project Structure

```
CrudSample/
├── Contracts/
│   ├── CreateBookRequest.cs
│   └── UpdateBookRequest.cs
├── Controllers/
│   └── BooksController.cs
├── Models/
│   └── Book.cs
├── Program.cs
├── Repositories/
│   ├── IBookRepository.cs
│   └── InMemoryBookRepository.cs
├── Services/
│   └── BookService.cs
└── CrudSample.csproj
```

## Running the API

Make sure you have the .NET 8.0 SDK installed, then run:

```bash
cd CrudSample
dotnet restore
dotnet run
```

Navigate to `https://localhost:5001/swagger` (or the URL shown in the console) to explore and test the API endpoints with Swagger UI.

## API Overview

| Method | Endpoint          | Description         |
| ------ | ----------------- | ------------------- |
| GET    | `/api/books`      | Retrieve all books. |
| GET    | `/api/books/{id}` | Retrieve a book by ID. |
| POST   | `/api/books`      | Create a new book. |
| PUT    | `/api/books/{id}` | Update an existing book. |
| DELETE | `/api/books/{id}` | Delete a book. |

The sample starts with two predefined books in the in-memory repository, which makes it easy to experiment with the CRUD endpoints immediately.