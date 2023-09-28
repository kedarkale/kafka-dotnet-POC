namespace MessageService.Repositories
{
    using MessageService.Models;
    public interface IMessageRepository
    {
        public List<MessageModel> GetAllMessages();
        public List<MessageModel> GetMessagesForUser(int userId);
        public List<MessageModel> GetMessagesSentByUser(int userId);
    }
    
}