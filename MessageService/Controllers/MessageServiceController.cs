using Microsoft.AspNetCore.Mvc;
using MessageService.Repositories;
using MessageService.Models;
using MessageService.Managers;

namespace MessageService.Controllers;

[ApiController]
[Route("[controller]")]
public class MessageServiceController : ControllerBase
{

    private readonly ILogger<MessageServiceController> _logger;
    private readonly IMessageRepository _messageRepository;

    public MessageServiceController(ILogger<MessageServiceController> logger, IMessageRepository messageRepository)
    {
        _logger = logger;
        _messageRepository = messageRepository;
    }

    [HttpGet("GetAllMessages")]
    public List<MessageModel> GetAllMessages()
    {
        return _messageRepository.GetAllMessages();
    }

    [HttpGet("GetMessagesForUser")]
    public List<MessageModel> GetMessagesForUser(int userId)
    {
        return _messageRepository.GetMessagesForUser(userId);
    }

    [HttpGet("GetMessagesSentByUser")]
    public List<MessageModel> GetMessagesSentByUser(int userId)
    {
        return _messageRepository.GetMessagesSentByUser(userId);
    }

    // [HttpGet("TestConsumer")]
    // public void TestConsumer()
    // {
    //     KafkaManager kafkaManager = new KafkaManager();
    //     kafkaManager.ConsumeMessages();
    // }
}
