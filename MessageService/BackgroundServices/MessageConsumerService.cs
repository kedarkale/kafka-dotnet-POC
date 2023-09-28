
using System.Text.Json;
using Confluent.Kafka;
using MessageService.Models;
using MessageService.Repositories;

namespace MessageService.BackgroundServices
{
    public class MessageConsumerService : BackgroundService
    {
        private static readonly ConsumerConfig _config = new ConsumerConfig
        {
            BootstrapServers = "localhost:9092",
            GroupId = "one",
            AutoOffsetReset = AutoOffsetReset.Earliest,
            SecurityProtocol = SecurityProtocol.Plaintext
        };
        private static readonly MessageRepository _messageRepository = new MessageRepository();
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(() => {
                using (var consumer = new ConsumerBuilder<string, string>(_config).Build())
                {
                    consumer.Subscribe("messages");
                    try {
                        while (!stoppingToken.IsCancellationRequested)
                        {
                            var mEvent = consumer.Consume();
                            Console.WriteLine($"Consumed event from topic 'messages' with key {mEvent.Message.Key} and value {mEvent.Message.Value}");
                            if (mEvent.Message.Value is not null) _messageRepository.SaveMessage(JsonSerializer.Deserialize<MessageModel>(mEvent.Message.Value));
                        }
                    }
                    finally {
                        consumer.Close();
                    }
                }
            });
        }
    }
}