using System;
using System.Threading.Tasks;
using LattanaService.Interfaces.Contracts;
using Telegram.Bot.Args;

namespace LattanaService.Services.Telegram
{
    public class MessageHandler : IMessageHandler
    {
        private readonly ILogger _logger;
        private readonly IInlineQueryHandler _inlineQueryHandler;

        public MessageHandler(ILogger logger, IInlineQueryHandler inlineQueryHandler)
        {
            _logger = logger;
            _inlineQueryHandler = inlineQueryHandler;
        }

        public Task OnMessageReceive(object sender, MessageEventArgs e)
        {
            return new Task(() => { });
        }

        public Task OnCallbackQuery(object sender, CallbackQueryEventArgs e)
        {
            return new Task(() => { });
        }

        public async Task OnInlineQuery(object sender, InlineQueryEventArgs e)
        {
            try
            {
                await _inlineQueryHandler.Handle(e.InlineQuery);
            }
            catch (Exception exception)
            {
                _logger.Log(exception.Message);
            }
        }
    }
}