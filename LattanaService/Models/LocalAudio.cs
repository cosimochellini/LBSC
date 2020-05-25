using System;
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
            //if (IsNativeAudio(audio.Url))

            //return new InlineQueryResultVoice(Guid.NewGuid().ToString(), audio.Url, audio.Title);

            return new InlineQueryResultAudio(Guid.NewGuid().ToString(), audio.Url, audio.Title);
        }

        private static bool IsNativeAudio(string file) => file.EndsWith("ogg");
    }
}