using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Patterns
{
    public interface IHasLogger
    {
        ILogger Logger { get; }
    }

    public interface ILogger
    {
        void Log(string text, ConsoleColor color = ConsoleColor.White);
    }
    public class ConsoleLogger : ILogger
    {
        public void Log(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
