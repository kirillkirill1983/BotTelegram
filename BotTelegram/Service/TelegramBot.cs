using Telegram.Bot;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace BotTelegram.Service
{
    public class TelegramBot
    {
        private readonly IConfiguration _configuration;
        private TelegramBotClient _botClient;

        public TelegramBot(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<TelegramBotClient> GetBot()
        {
            _botClient = new TelegramBotClient(_configuration["Token"]);

            var webhool = $"{_configuration["Url"]}api/message/update";
            await _botClient.SetWebhookAsync(webhool);

            return _botClient;
        }
    }
}
