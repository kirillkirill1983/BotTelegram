using System.Threading.Tasks;
using Telegram.Bot.Types;
using BotTelegram.Commands;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Telegram.Bot.Types.Enums;
using BotTelegram.Service;

namespace BotTelegram.Service
{
    public class CommandExecute : ICommandExecute
    {
        private readonly List<BaseCommands> _commands;
        private BaseCommands _lastCommands;

        public CommandExecute(IServiceProvider serviceProvider)
        {
            _commands = serviceProvider.GetServices<BaseCommands>().ToList();
        }

        public async Task Execute(Update update)
        {
            if (update?.Message?.Chat == null && update?.CallbackQuery == null)
                return;

            if (update.Type == UpdateType.Message)
            {
                switch (update.Message?.Text)
                {
                    case "Создать операцию":
                        await ExecuteCommand(CommandName.AddOperationCommand, update);
                        return;
                    case "Получить операции":
                        await ExecuteCommand(CommandName.GetOperationsCommand, update);
                        return;
                        //case "Аналитика":
                        //    await ExecuteCommand(CommandName.SelectAnalyticDaysCommand, update);
                        //    return;
                }
            }

            if (update.Message != null && update.Message.Text.Contains(CommandName.StartCommand))
            {
                await ExecuteCommand(CommandName.StartCommand, update);
                return;
            }


        }

        private async Task ExecuteCommand(string commandName, Update update)
        {
            _lastCommands = _commands.First(x => x.Name == commandName);
            await _lastCommands.ExecuteAsync(update);
        }
    }
}
