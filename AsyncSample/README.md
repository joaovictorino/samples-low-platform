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