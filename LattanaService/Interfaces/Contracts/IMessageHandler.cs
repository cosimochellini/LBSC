using System.Threading.Tasks;
using Telegram.Bot.Args;

namespace LattanaService.Interfaces.Contracts
{
    public interface IMessageHandler
    {
        public Task OnMessageReceive(object sender, MessageEventArgs e);
        public Task OnCallbackQuery(object sender, CallbackQueryEventArgs e);
        public Task OnInlineQuery(object sender, InlineQueryEventArgs e);
    }
}