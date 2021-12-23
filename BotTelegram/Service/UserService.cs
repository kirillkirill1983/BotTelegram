using BotTelegram.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BotTelegram.Service
{
    public class UserService : IUserSevice
    {
        private readonly DataContex _dataContex;

        public UserService(DataContex dataContex)
        {
            _dataContex = dataContex;
        }
        public async Task<AppUser> GetOnCreate(Update update)
        {
            var newUser = update.Type switch
            {
                UpdateType.CallbackQuery => new AppUser
                {
                    UserName = update.CallbackQuery.From.Username,
                    ChatID = update.CallbackQuery.Message.Chat.Id,
                    FirstName = update.CallbackQuery.Message.From.FirstName,

                },
                UpdateType.Message => new AppUser
                {
                    UserName = update.Message.Chat.Username,
                    ChatID = update.Message.Chat.Id,
                    FirstName = update.Message.Chat.FirstName,

                }
            };

            var user = await _dataContex.Users.FirstOrDefaultAsync(x => x.ChatID == newUser.ChatID);

            if (user != null) return user;

            var result = await _dataContex.Users.AddAsync(newUser);
            await _dataContex.SaveChangesAsync();

            return result.Entity;
        }
    }
}
