using LattanaService.Services.Telegram;

namespace LattanaService
{
    public class App
    {
        private readonly MessageReceiver _messageReceiver;

        public App(MessageReceiver messageReceiver)
        {
            _messageReceiver = messageReceiver;
        }

        public bool Run() => _messageReceiver.StartReceiving();
    }
}