using System;
using LattanaService.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace LattanaService
{
    public class Program
    {
        private static void Main()
        {
            var serviceProvider = new ServiceCollection()
                .ConfigureServices()
                .BuildServiceProvider();

            // calls the Run method in App, which is replacing Main
            _ = serviceProvider.GetService<App>().Run();

            Console.ReadLine();
        }
    }
}