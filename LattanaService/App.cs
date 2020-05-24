using System.Threading.Tasks;
using LattanaService.Interfaces.Contracts;

namespace LattanaService
{
    public class App
    {
        private readonly IMessageReceiver _messageReceiver;

        public App(IMessageReceiver messageReceiver)
        {
            _messageReceiver = messageReceiver;
        }

        public async Task Run()
        {
            _messageReceiver.SetEventHandlers();

            await _messageReceiver.SetCommands();

            _messageReceiver.StartReceiving();
        }
    }
}