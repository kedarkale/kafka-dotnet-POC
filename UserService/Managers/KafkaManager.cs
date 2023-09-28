namespace UserService.Managers
{
    using Confluent.Kafka;
    using System.Text.Json;
    using UserService.Models;

    public class KafkaManager
    {
        private static Queue<SendMessageModel> erroredMessages = new Queue<SendMessageModel>();
        private ProducerConfig config = new ProducerConfig
        {
            BootstrapServers = "localhost:9092",
            SecurityProtocol = SecurityProtocol.Plaintext,
            MessageTimeoutMs = 2000            
        };

        public async Task PostMessage(SendMessageModel msg)
        {
            try {
                using (var producer = new ProducerBuilder<Null, string>(config).Build())
                {
                    // retry sending previously failed messages
                    while (erroredMessages.Any())
                    {
                        var eMsg = erroredMessages.Peek();
                        await producer.ProduceAsync("messages", new Message<Null, string> { Value=JsonSerializer.Serialize(eMsg) });
                        erroredMessages.Dequeue();
                        Console.WriteLine("Sent message to Queue", eMsg);
                    }

                    var result = await producer.ProduceAsync("messages", new Message<Null, string> { Value=JsonSerializer.Serialize(msg) });
                    Console.WriteLine("Sent message to Queue", msg);
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Error sending message to Queue", msg, ex);
                erroredMessages.Enqueue(msg);
                return;
            }
    
        }

        public async Task PostNotification(SendNotificationModel notif)
        {
            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                var result = await producer.ProduceAsync("notifications", new Message<Null, string> { Value=JsonSerializer.Serialize(notif) });            
            }
    
        }
    }
}