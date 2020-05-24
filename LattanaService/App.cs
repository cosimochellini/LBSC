using System;
using System.Threading.Tasks;
using Telegram.Bot;

namespace LattanaService
{
    public class App
    {
        private readonly ITelegramBotClient _client;

        public App(ITelegramBotClient client)
        {
            _client = client;
        }
        public async Task<int> Run()
        {
            var me = await _client.GetMeAsync();
            Console.WriteLine(
                $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
            );

            return 1;
        }
    }
}
