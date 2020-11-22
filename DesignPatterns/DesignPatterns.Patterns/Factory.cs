using System;

namespace DesignPatterns.Patterns
{
    public interface IFactoryObject : IHasLogger
    {
        string Name { get; }
        void PrintSelf();
    }

    public abstract class CommonFactoryObject : IFactoryObject
    {
        public CommonFactoryObject(string name, ILogger logger)
        {
            Name = name;
            Logger = logger;
        }
        public string Name { get; }
        public ILogger Logger { get; }

        public virtual void PrintSelf() => Logger.Log(Name);
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

    public abstract class CommonFactory : IFactory
    {
        public CommonFactory(ILogger logger)
        {
            Logger = logger;
        }
        public ILogger Logger { get; }

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
