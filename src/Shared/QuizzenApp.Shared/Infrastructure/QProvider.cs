using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace QuizzenApp.Shared.Infrastructure;

public static class QProvider
{
    public static void SendMessage(string exchangeName, string exchangeType, string queueName, object obj)
    {
        //create channel
        var channel = CreateBasicConsumer().SetExchange(exchangeName, exchangeType: exchangeType)
                                           .SetQueue(queueName: queueName, exchangeName: exchangeName)
                                           .Model;

        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(obj));

        //publish message on channel
        channel.BasicPublish(exchange: exchangeName,
                             routingKey: queueName,
                             basicProperties: null,
                             body: body);


    }

    public static EventingBasicConsumer CreateBasicConsumer()
    {
        //create connection and channel
        var factory = new ConnectionFactory() { HostName = QConstants.RMQ_HOST };
        var conn = factory.CreateConnection();
        var channel = conn.CreateModel();

        return new(channel);
    }

    public static EventingBasicConsumer SetExchange(this EventingBasicConsumer consumer, string exchangeName, string exchangeType = QConstants.DEFAULT_EXCHANGE_TYPE)
    {
        consumer.Model.ExchangeDeclare(exchange: exchangeName, type: exchangeType, durable: false, autoDelete: false);

        return consumer;
    }

    public static EventingBasicConsumer SetQueue(this EventingBasicConsumer consumer, string queueName, string exchangeName)
    {
        consumer.Model.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, null);

        consumer.Model.QueueBind(queue: queueName, exchange: exchangeName, routingKey: queueName);

        return consumer;
    }

    public static EventingBasicConsumer Receive<T>(this EventingBasicConsumer consumer, Action<T> action)
    {
        consumer.Received += (m, EventArgs) =>
        {
            var body = EventArgs.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            var model = JsonSerializer.Deserialize<T>(message);

            action(model);

            consumer.Model.BasicAck(EventArgs.DeliveryTag, false);
        };

        return consumer;
    }

    public static EventingBasicConsumer StartConsuming(this EventingBasicConsumer consumer, string queueName)
    {
        consumer.Model.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);

        return consumer;
    }

}
