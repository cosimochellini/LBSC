using LattanaService.Interfaces.Contracts;
using Telegram.Bot;

namespace LattanaService.Services.Telegram
{
    public class MessageReceiver
    {
        private readonly ITelegramBotClient _client;
        private readonly IMessageHandler _messageHandler;

        public MessageReceiver(ITelegramBotClient client, IMessageHandler messageHandler)
        {
            _client = client;
            _messageHandler = messageHandler;
        }

        public bool StartReceiving()
        {
            _client.StartReceiving();
            _client.OnMessage += _messageHandler.OnMessageReceive;
            return true;
        }
    }
}