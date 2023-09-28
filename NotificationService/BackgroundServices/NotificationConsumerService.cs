
using System.Text.Json;
using Confluent.Kafka;
using NotificationService.Models;
using NotificationService.Repositories;

namespace NotificationService.BackgroundServices
{
    public class NotificationConsumerService : BackgroundService
    {
        private static readonly ConsumerConfig _config = new ConsumerConfig
        {
            BootstrapServers = "localhost:9092",
            GroupId = "one",
            AutoOffsetReset = AutoOffsetReset.Earliest,
            SecurityProtocol = SecurityProtocol.Plaintext
        };
        private static readonly NotificationRepository _notificationRepository = new NotificationRepository();
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(() => {
                using (var consumer = new ConsumerBuilder<string, string>(_config).Build())
                {
                    consumer.Subscribe("notifications");
                    try {
                        while (!stoppingToken.IsCancellationRequested)
                        {
                            var mEvent = consumer.Consume();
                            Console.WriteLine($"Consumed event from topic 'notifications' with key {mEvent.Message.Key} and value {mEvent.Message.Value}");
                            if (mEvent.Message.Value is not null) _notificationRepository.SaveNotification(JsonSerializer.Deserialize<NotificationModel>(mEvent.Message.Value));
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