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
        void Log(string text);
    }
    public class ConsoleLogger : ILogger
    {
        public void Log(string text) => Console.WriteLine(text);
    }
}
