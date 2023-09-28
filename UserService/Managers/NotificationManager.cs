using System.Text.Json;
using UserService.Models;

namespace UserService.Managers
{
    public class NotificationManager
    {
        private static readonly string _NotificationServiceUrl;
        private static readonly string _getNotificationsForUserEndpoint;

        static NotificationManager()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            _NotificationServiceUrl = config["AppSettings:NotificationServiceUrl"];
            _getNotificationsForUserEndpoint = config["AppSettings:GetNotificationsForUserEndpoint"];
        }

        public async Task<List<SendNotificationModel>> GetNotificationsForUser(int userId)
        {
            using (HttpClient client = new HttpClient())
            {
                try {
                    return await client.GetFromJsonAsync<List<SendNotificationModel>>(_NotificationServiceUrl+_getNotificationsForUserEndpoint+userId);
                }
                catch (Exception ex) {
                    return await Task.FromResult(new List<SendNotificationModel>());
                }
            }
        }
    }
}