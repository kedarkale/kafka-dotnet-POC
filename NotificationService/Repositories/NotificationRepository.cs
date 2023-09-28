namespace NotificationService.Repositories
{
    using NotificationService.Models;
    public class NotificationRepository: INotificationRepository
    {
        private static List<NotificationModel> Notifications = new List<NotificationModel>();

        public List<NotificationModel> GetAllNotifications()
        {
            return Notifications;
        }

        public List<NotificationModel> GetNotificationsForUser(int userId)
        {
            return Notifications.Where(m => m.ReceiverId == userId).ToList();
        }

        public List<NotificationModel> GetNotificationsSentByUser(int userId)
        {
            return Notifications.Where(m => m.SenderId == userId).ToList();
        }

        public void SaveNotification(NotificationModel notification)
        {
            Notifications.Add(notification);
        }
    }
}