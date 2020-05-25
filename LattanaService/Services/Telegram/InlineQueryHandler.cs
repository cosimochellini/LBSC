using System.Linq;
using System.Threading.Tasks;
using LattanaService.Interfaces.Contracts;
using LattanaService.Models;
using LattanaService.Services.FileSystem;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace LattanaService.Services.Telegram
{
    public class InlineQueryHandler : IInlineQueryHandler
    {
        private readonly ITelegramBotClient _botClient;
        private readonly AudioRepository _audioRepository;

        public InlineQueryHandler(ITelegramBotClient botClient, AudioRepository audioRepository)
        {
            _botClient = botClient;
            _audioRepository = audioRepository;
        }

        public async Task Handle(InlineQuery args)
        {
            var keywords = args.Query.Split(",")
                .Where(s => !string.IsNullOrEmpty(s))
                .Select(s => s.ToLower())
                .ToArray();

            var audiosToSent = _audioRepository.GetByKeywords(keywords);

            await _botClient.AnswerInlineQueryAsync(args.Id, audiosToSent.Select(LocalAudio.ToQueryResult));
        }
    }
}