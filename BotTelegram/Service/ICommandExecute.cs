using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace BotTelegram.Service
{
    public interface ICommandExecute
    {
        Task Execute(Update update);
    }
}
