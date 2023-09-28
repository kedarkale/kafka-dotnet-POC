using Microsoft.AspNetCore.Mvc;
using NotificationService.Repositories;
using NotificationService.Models;
using NotificationService.Managers;

namespace NotificationService.Controllers;

[ApiController]
[Route("[controller]")]
public class NotificationServiceController : ControllerBase
{

    private readonly ILogger<NotificationServiceController> _logger;
    private readonly INotificationRepository _notificationRepository;

    public NotificationServiceController(ILogger<NotificationServiceController> logger, INotificationRepository notificationRepository)
    {
        _logger = logger;
        _notificationRepository = notificationRepository;
    }

    [HttpGet("GetAllNotifications")]
    public List<NotificationModel> GetAllNotifications()
    {
        return _notificationRepository.GetAllNotifications();
    }

    [HttpGet("GetNotificationsForUser")]
    public List<NotificationModel> GetNotificationsForUser(int userId)
    {
        return _notificationRepository.GetNotificationsForUser(userId);
    }

    [HttpGet("GetNotificationsSentByUser")]
    public List<NotificationModel> GetNotificationsSentByUser(int userId)
    {
        return _notificationRepository.GetNotificationsSentByUser(userId);
    }

    // [HttpGet("TestConsumer")]
    // public void TestConsumer()
    // {
    //     KafkaManager kafkaManager = new KafkaManager();
    //     kafkaManager.ConsumeNotifications();
    // }
}
