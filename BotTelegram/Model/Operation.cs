namespace BotTelegram.Model
{
    public class Operation : BaseUsers
    {
        public string Name { get; set; }

        public AppUser User { get; set; }
        public long? UserId { get; set; }
    }
}
