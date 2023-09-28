namespace NotificationService.Managers
{
    using Confluent.Kafka;
    public class KafkaManager
    {
        private static readonly ConsumerConfig config = new ConsumerConfig
        {
            BootstrapServers = "localhost:9092",
            GroupId = "one",
            AutoOffsetReset = AutoOffsetReset.Earliest,
            SecurityProtocol = SecurityProtocol.Plaintext
        };

        public void ConsumeNotifications()
        {
            using (var consumer = new ConsumerBuilder<string, string>(config).Build())
            {
                consumer.Subscribe("notifications");
                try {
                    while (true)
                    {
                        var notification = consumer.Consume();
                        Console.WriteLine($"Consumed event from topic 'notifications' with key {notification.Message.Key} and value {notification.Message.Value}");
                    }
                }
                finally {
                    consumer.Close();
                }
            }
        }
    }
}