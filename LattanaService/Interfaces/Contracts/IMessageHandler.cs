using Telegram.Bot.Args;

namespace LattanaService.Interfaces.Contracts
{
    public interface IMessageHandler
    {
        public void OnMessageReceive(object sender, MessageEventArgs e);
    }
}