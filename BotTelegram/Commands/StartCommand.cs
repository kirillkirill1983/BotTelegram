using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using BotTelegram.Service;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;

namespace BotTelegram.Commands
{
    public class StartCommand : BaseCommands
    {
        private readonly IUserSevice _userService;
        private readonly TelegramBotClient _telehramBotClient;

        public StartCommand(IUserSevice userSevice, TelegramBot telegramBot)
        {
            _userService = userSevice;
            _telehramBotClient = telegramBot.GetBot().Result;
        }
        public override string Name => CommandName.StartCommand;

        public override async Task ExecuteAsync(Update update)
        {
            var user = await _userService.GetOnCreate(update);
            var inlineKeyboard = new ReplyKeyboardMarkup(new[]
            {
                new[]
                {
                    new KeyboardButton
                    {
                        Text = "Создать операцию"
                    },
                    new KeyboardButton
                    {
                        Text = "Получить операции"
                    },

                }
            });

            await _telehramBotClient.SendTextMessageAsync(user.ChatID, "Добро пожаловать! Я буду вести учёт ваших доходов и расходов! ",
                ParseMode.Markdown, replyMarkup: inlineKeyboard);
        }
    }
}
