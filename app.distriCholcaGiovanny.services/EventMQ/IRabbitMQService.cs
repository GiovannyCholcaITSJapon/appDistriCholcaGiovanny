namespace app.distriCholcaGiovanny.services.EventMQ
{
    public interface IRabbitMQService
    {
        Task PublishMessage<T>(T message, string queueName);
    }
}
