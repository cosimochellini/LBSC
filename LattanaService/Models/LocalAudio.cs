using Telegram.Bot.Types.InlineQueryResults;

namespace LattanaService.Models
{
    public class LocalAudio
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string[] Keywords { get; set; } = { };

        public static InlineQueryResultBase ToQueryResult(LocalAudio audio)
        {
            throw new System.NotImplementedException();
        }
    }
}