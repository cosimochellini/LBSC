using System;
using LattanaService.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace LattanaService
{
    public class Program
    {
        private static ServiceProvider ServiceProvider => new ServiceCollection()
            .ConfigureServices()
            .BuildServiceProvider();

        private static void Main()
        {
            try
            {
                ServiceProvider.GetService<App>().Run().Wait();

                Console.WriteLine("Lattana Bot Service Core started.");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}