namespace NotificationService.Models
{
    public class NotificationModel
    {
        public int SenderId {get; set;}

        public int ReceiverId {get; set;}

        public string NotificationTitle {get; set;} = "";

        public string NotificationBody {get; set;} = "";
    }
}