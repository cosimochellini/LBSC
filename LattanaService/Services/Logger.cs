using System;
using LattanaService.Interfaces.Contracts;

namespace LattanaService.Services
{
    public class WriteLineLogger : ILogger
    {
        public void Log(string text) => Console.WriteLine(text);
    }
}