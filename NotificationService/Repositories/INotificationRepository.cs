namespace NotificationService.Repositories
{
    using NotificationService.Models;
    public interface INotificationRepository
    {
        public List<NotificationModel> GetAllNotifications();
        public List<NotificationModel> GetNotificationsForUser(int userId);
        public List<NotificationModel> GetNotificationsSentByUser(int userId);
    }
    
}