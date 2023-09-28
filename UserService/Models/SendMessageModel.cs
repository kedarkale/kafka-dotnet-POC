namespace UserService.Models
{
    public  class SendMessageModel
    {
        public int SenderId {get; set;}

        public int ReceiverId {get; set;}

        public string MessageTitle {get; set;} = "";

        public string MessageBody {get; set;} = "";
    }
}