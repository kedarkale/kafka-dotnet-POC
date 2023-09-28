using Microsoft.AspNetCore.Mvc;
using UserService.Models;
using UserService.Repositories;
using UserService.Managers;

namespace UserService.Controllers;

[ApiController]
[Route("[controller]")]
public class UserServiceController : ControllerBase
{

    private readonly ILogger<UserServiceController> _logger;
    private readonly IUserRepository _userRepository;

    public UserServiceController(ILogger<UserServiceController> logger, IUserRepository userRepo)
    {
        _logger = logger;
        _userRepository = userRepo;
    }

    [HttpGet("GetAllUsers")]
    public List<UserModel> GetAllUsers()
    {
        return _userRepository.GetAllUsers();
    }

    [HttpPost("PostMessage")]
    public async Task PostMessage(SendMessageModel msg)
    {
        KafkaManager km = new KafkaManager();
        await km.PostMessage(msg);
    }

    [HttpPost("PostNotification")]
    public async Task PostNotification(SendNotificationModel notif)
    {
        KafkaManager km = new KafkaManager();
        await km.PostNotification(notif);
    }

    [HttpGet("GetMessages")]
    public async Task<List<SendMessageModel>> GetMessages(int userId)
    {
        MessageManager messageManager= new MessageManager();
        return await messageManager.GetMessagesForUser(userId);
    }

    [HttpGet("GetNotifications")]
    public async Task<List<SendNotificationModel>> GetNotifications(int userId)
    {
        NotificationManager notificationManager= new NotificationManager();
        return await notificationManager.GetNotificationsForUser(userId);
    }
}
