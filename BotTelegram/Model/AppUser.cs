namespace BotTelegram.Model
{
    public class AppUser : BaseUsers
    {
        public long ChatID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
    }
}
