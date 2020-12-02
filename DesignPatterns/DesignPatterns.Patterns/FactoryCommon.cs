using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Patterns.FactoryCommon
{
    public interface IFactoryObject : IHasLogger, IPrintsSelf
    {
        string Name { get; }
    }

    public abstract class CommonFactoryObject : CommonLogsSelf, IFactoryObject
    {
        public CommonFactoryObject(string name, ILogger logger) : base(logger)
        {
            Name = name;
        }
        public string Name { get; }

        public override void PrintSelf()
        {
            Logger.Log(Name);
        }
    }

    public class SomeFactoryObject : CommonFactoryObject
    {
        public SomeFactoryObject(string name, ILogger logger) : base(name, logger) { }
    }

    public class SomeOtherFactoryObject : CommonFactoryObject
    {
        public SomeOtherFactoryObject(string name, ILogger logger) : base(name, logger) { }
    }
}
