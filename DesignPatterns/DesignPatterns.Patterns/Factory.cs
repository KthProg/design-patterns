using System;

namespace DesignPatterns.Patterns
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
