namespace ApiGateway.MessageBroker.Rabbit
{
    public interface IRabbitMqClient
    {
        void SendMessage(object message);

        void SendMessage(string message);
    }
}
