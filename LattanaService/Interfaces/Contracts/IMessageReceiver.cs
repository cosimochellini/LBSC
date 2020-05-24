using System.Threading.Tasks;

namespace LattanaService.Interfaces.Contracts
{
    public interface IMessageReceiver
    {
        public void SetEventHandlers();

        public Task SetCommands();

        public void StartReceiving();
    }
}