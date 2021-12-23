using BotTelegram.Model;
using BotTelegram.Service;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotTelegram.Commands
{
    public class AddOperationComands : BaseCommands
    {
        private readonly TelegramBotClient _telegramBotClient;
        private readonly IUserSevice _userSevice;
        private readonly IOperationServise _operationServise;
        private readonly DataContex _dataContex;

        public AddOperationComands(TelegramBot telegramBot, IUserSevice userSevice,
            IOperationServise operationServise, DataContex dataContex)
        {
            _telegramBotClient = telegramBot.GetBot().Result;
            _userSevice = userSevice;
            _dataContex = dataContex;
            _operationServise = operationServise;
        }
        public override string Name => CommandName.AddOperationCommand;

        public override async Task ExecuteAsync(Update update)
        {
            var user = await _userSevice.GetOnCreate(update);
            var userOperation = new Operation
            {
                Name = user.UserName,
                UserId = user.Id
            };
            await _dataContex.Operations.AddAsync(userOperation);
            await _dataContex.SaveChangesAsync();
            await _telegramBotClient.SendTextMessageAsync(user.ChatID, "Операция добавлена",
                Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}
