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
        void Log(string text, ConsoleColor color = ConsoleColor.White, bool isInline = false);
        
    }
    public class ConsoleLogger : ILogger
    {
        public void Log(string text, ConsoleColor color = ConsoleColor.White, bool isInline = false)
        {
            Console.ForegroundColor = color;
            if(isInline){
                Console.Write(text);
            }else{
                Console.WriteLine(text);
            }
            Console.ResetColor();
        }
    }
}
