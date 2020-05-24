using System.Collections.Generic;
using Telegram.Bot.Types;

namespace LattanaService.Interfaces.Contracts
{
    public interface IBotCommandsFactory
    {
        public IEnumerable<BotCommand> Create();
    }

}