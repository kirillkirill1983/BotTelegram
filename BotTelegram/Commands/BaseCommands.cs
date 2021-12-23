using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace BotTelegram.Commands
{
    public abstract class BaseCommands
    {
        public abstract string Name { get; }
        public abstract Task ExecuteAsync(Update update);
    }
}
