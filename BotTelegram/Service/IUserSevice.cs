using BotTelegram.Model;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace BotTelegram.Service
{
    public interface IUserSevice
    {
        Task<AppUser> GetOnCreate(Update update);
    }
}
