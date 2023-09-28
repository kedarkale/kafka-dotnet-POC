namespace MessageService.Managers
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

        public void ConsumeMessages()
        {
            using (var consumer = new ConsumerBuilder<string, string>(config).Build())
            {
                consumer.Subscribe("messages");
                try {
                    while (true)
                    {
                        var message = consumer.Consume();
                        Console.WriteLine($"Consumed event from topic 'messages' with key {message.Message.Key} and value {message.Message.Value}");
                    }
                }
                finally {
                    consumer.Close();
                }
            }
        }
    }
}