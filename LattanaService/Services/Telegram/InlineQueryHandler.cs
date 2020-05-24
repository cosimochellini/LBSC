using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LattanaService.Interfaces.Contracts;
using LattanaService.Models;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace LattanaService.Services.Telegram
{
    public class InlineQueryHandler : IInlineQueryHandler
    {
        private readonly ITelegramBotClient _botClient;
        private readonly List<LocalAudio> _localAudios = new List<LocalAudio>();

        public InlineQueryHandler(ITelegramBotClient botClient)
        {
            _botClient = botClient;
        }

        public async Task Handle(InlineQuery args)
        {
            var keyword = args.Query;

            var audiosToSent = _localAudios
                .Take(5)
                .Where(a => a.Keywords.Any(k => k.StartsWith(keyword)))
                .ToList();

            await _botClient.AnswerInlineQueryAsync(args.Id, audiosToSent.Select(LocalAudio.ToQueryResult));
        }
    }
}