using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace ApiGateway.MessageBroker.Rabbit
{
    public class RabbitMqClient : IRabbitMqClient
    {
        public void SendMessage(object message)
        {
            var json = JsonSerializer.Serialize(message);

            this.SendMessage(json);
        }

        public void SendMessage(string message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "user",
                Password = "password"
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "MyTestExchange", 
                           routingKey: "test",
                           basicProperties: null,
                           body: body);
        }
    }
}
