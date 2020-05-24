using System.Threading.Tasks;
using LattanaService.Interfaces.Contracts;
using Telegram.Bot;

namespace LattanaService.Services.Telegram
{
    public class MessageReceiver : IMessageReceiver
    {
        private readonly ITelegramBotClient _client;
        private readonly IMessageHandler _messageHandler;
        private readonly IBotCommandsFactory _botCommandsFactory;

        public MessageReceiver(
            ITelegramBotClient client,
            IMessageHandler messageHandler,
            IBotCommandsFactory botCommandsFactory
        )
        {
            _client = client;
            _messageHandler = messageHandler;
            _botCommandsFactory = botCommandsFactory;
        }

        public void SetEventHandlers()
        {
            _client.OnMessage += (s, e) => _messageHandler.OnMessageReceive(s, e);
            _client.OnInlineQuery += (s, e) => _messageHandler.OnInlineQuery(s, e);
            _client.OnCallbackQuery += (s, e) => _messageHandler.OnCallbackQuery(s, e);
        }

        public async Task SetCommands()
        {
            await _client.SetMyCommandsAsync(_botCommandsFactory.Create());
        }

        public void StartReceiving()
        {
            _client.StartReceiving();
        }
    }
}