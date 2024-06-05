

using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory { HostName = "localhost" };
var connection = factory.CreateConnection();
var channel = connection.CreateModel();

channel.QueueDeclare(
        queue: "Hello",
        durable: false,
        exclusive: false,
        autoDelete: false,
        arguments: null
    );

const string message = "Hello World message";
var body = Encoding.UTF8.GetBytes(message);

channel.BasicPublish(
        exchange: string.Empty,
        routingKey: "hello",
        basicProperties: null,
        body: body
    );
