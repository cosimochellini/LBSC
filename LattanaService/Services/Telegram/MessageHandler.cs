using System;
using LattanaService.Interfaces.Contracts;
using Telegram.Bot.Args;

namespace LattanaService.Services.Telegram
{
    public class MessageHandler: IMessageHandler
    {
        public void OnMessageReceive(object sender, MessageEventArgs e)
        {
            Console.WriteLine(e.Message.Text);
        }
    }
}