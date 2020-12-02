using DesignPatterns.Patterns.FactoryCommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Patterns
{
    public interface IFactoryMethod : IHasLogger
    {
        IFactoryObject CreateObject();
    }
    public abstract class FactoryMethodCommon : CommonHasLogger, IFactoryMethod
    {
        public FactoryMethodCommon(ILogger logger) : base(logger) { }
        public abstract IFactoryObject CreateObject();
    }

    public class SomeFactoryMethod : FactoryMethodCommon
    {
        public SomeFactoryMethod(ILogger logger): base(logger) { }
        public override IFactoryObject CreateObject() => new SomeFactoryObject("Some object", Logger);
    }

    public class SomeOtherFactoryMethod : FactoryMethodCommon
    {
        public SomeOtherFactoryMethod(ILogger logger) : base(logger) { }
        public override IFactoryObject CreateObject() => new SomeOtherFactoryObject("Some other object", Logger);
    }
}
