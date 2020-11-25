using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Patterns
{
    public interface IPrintsSelf
    {
        void PrintSelf();
    }

    public abstract class CommonHasLogger : IHasLogger
    {
        public CommonHasLogger(ILogger logger)
        {
            Logger = logger;
        }

        public ILogger Logger { get; }

    }

    public abstract class CommonLogsSelf : CommonHasLogger, IPrintsSelf
    {
        public CommonLogsSelf(ILogger logger) : base(logger) { }

        public virtual void PrintSelf() => Logger.Log(GetType().Name);
    }
}
