using System;

namespace BotTelegram.Model
{
    public class BaseUsers
    {
        public long Id { get; set; }
        public DateTime dateTime { get; set; } = DateTime.UtcNow;
    }
}
