using DesignPatterns.Patterns.FactoryCommon;
using System;

namespace DesignPatterns.Patterns
{
    public interface IFactory : IHasLogger
    {
        IFactoryObject MakeObject();
    }
    public abstract class CommonFactory : CommonHasLogger, IFactory
    {
        public CommonFactory(ILogger logger) : base(logger) { }
        public abstract IFactoryObject MakeObject();
    }

    public class SomeObjectFactory : CommonFactory
    {
        public SomeObjectFactory(ILogger logger) : base(logger) { }
        public override IFactoryObject MakeObject() => new SomeFactoryObject("Object", Logger);
    }

    public class SomeOtherObjectFactory : CommonFactory
    {
        public SomeOtherObjectFactory(ILogger logger) : base(logger) { }
        public override IFactoryObject MakeObject() => new SomeOtherFactoryObject("Other object", Logger);
    }
}
