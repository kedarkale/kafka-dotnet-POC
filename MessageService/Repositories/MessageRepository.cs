namespace MessageService.Repositories
{
    using MessageService.Models;
    public class MessageRepository: IMessageRepository
    {
        private static List<MessageModel> Messages = new List<MessageModel>();

        public List<MessageModel> GetAllMessages()
        {
            return Messages;
        }

        public List<MessageModel> GetMessagesForUser(int userId)
        {
            return Messages.Where(m => m.ReceiverId == userId).ToList();
        }

        public List<MessageModel> GetMessagesSentByUser(int userId)
        {
            return Messages.Where(m => m.SenderId == userId).ToList();
        }

        public void SaveMessage(MessageModel message)
        {
            Messages.Add(message);
        }
    }
}