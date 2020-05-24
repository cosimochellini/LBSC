using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace LattanaService.Interfaces.Contracts
{
    public interface IInlineQueryHandler
    {
        public Task Handle(InlineQuery args);
    }
}