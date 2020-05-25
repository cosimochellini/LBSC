using System.IO;
using LattanaService.Interfaces.Contracts;
using LattanaService.Services;
using LattanaService.Services.Factory;
using LattanaService.Services.FileSystem;
using LattanaService.Services.Telegram;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;

namespace LattanaService.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            var config = LoadConfiguration();

            services.AddSingleton(config);

            services.AddSingleton(typeof(ITelegramBotClient), _ => new TelegramBotClient(config["botApiKey"]));

            services.AddSingleton<IMessageReceiver, MessageReceiver>();

            services.AddSingleton<IMessageHandler, MessageHandler>();

            services.AddSingleton<IBotCommandsFactory, BotCommandsFactory>();

            services.AddSingleton<ILogger, WriteLineLogger>();

            services.AddSingleton<IInlineQueryHandler, InlineQueryHandler>();

            services.AddSingleton<AudioRepository>();

            // required to run the application
            services.AddTransient<App>();

            return services;
        }

        private static IConfiguration LoadConfiguration() =>
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
    }
}