using RabbitMQ.Client;
using System.Text;

Console.WriteLine("RabbitMQ Producer");

var factory = new ConnectionFactory
{
    HostName = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "localhost",
    Port = int.TryParse(Environment.GetEnvironmentVariable("RABBITMQ_PORT"), out var port) ? port : 5672,
    UserName = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? "guest",
    Password = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? "guest",
};

const string queueName = "demo-queue";

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(
    queue: queueName,
    durable: false,
    exclusive: false,
    autoDelete: false,
    arguments: null);

Console.WriteLine("Enter messages to send. Submit an empty line to exit.");

string? message;
while (!string.IsNullOrWhiteSpace(message = Console.ReadLine()))
{
    var body = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish(
        exchange: string.Empty,
        routingKey: queueName,
        basicProperties: null,
        body: body);

    Console.WriteLine($"[x] Sent: {message}");
}

Console.WriteLine("Producer finished. Goodbye!");
