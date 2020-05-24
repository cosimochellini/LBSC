using System.Collections.Generic;
using LattanaService.Interfaces.Contracts;
using Telegram.Bot.Types;

namespace LattanaService.Services.Factory
{
    public class BotCommandsFactory : IBotCommandsFactory
    {
        public IEnumerable<BotCommand> Create()
        {
            return new List<BotCommand>
            {
                new BotCommand
                {
                    Command = "addaudio",
                    Description = "Add a specific audio as a sendable audio"
                },
                new BotCommand
                {
                    Command = "editaudio",
                    Description = "Edit a specific audio already saved remotely"
                },
            };
        }
    }
}
