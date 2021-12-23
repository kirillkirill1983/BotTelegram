using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using Telegram.Bot;
using BotTelegram.Service;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BotTelegram.Model;
using Telegram.Bot.Types.Enums;
using System;

namespace BotTelegram.Controllers
{
    [Route("api/message/update")]
    [ApiController]
    public class TelegramBotController : ControllerBase
    {
        private readonly ICommandExecute _commandExecute;

        public TelegramBotController(ICommandExecute commandExecute)
        {
            _commandExecute = commandExecute;
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] object update)
        {
            // /start => register user
            var upd = JsonConvert.DeserializeObject<Update>(update.ToString());
            if (upd?.Message?.Chat == null && upd?.CallbackQuery == null)
            {
                return Ok();
            }

            try
            {
                await _commandExecute.Execute(upd);
            }
            catch (Exception e)
            {
                return Ok();
            }

            return Ok();
        }
    }
}
