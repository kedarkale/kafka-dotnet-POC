using System.Text.Json;
using UserService.Models;

namespace UserService.Managers
{
    public class MessageManager
    {
        private static readonly string _messageServiceUrl;
        private static readonly string _getMessagesForUserEndpoint;

        static MessageManager()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            _messageServiceUrl = config["AppSettings:MessageServiceUrl"];
            _getMessagesForUserEndpoint = config["AppSettings:GetMessagesForUserEndpoint"];
        }

        public async Task<List<SendMessageModel>> GetMessagesForUser(int userId)
        {
            using (HttpClient client = new HttpClient())
            {
                try {
                    return await client.GetFromJsonAsync<List<SendMessageModel>>(_messageServiceUrl+_getMessagesForUserEndpoint+userId);
                }
                catch (Exception ex) {
                    return await Task.FromResult(new List<SendMessageModel>());
                }
            }
        }
    }
}