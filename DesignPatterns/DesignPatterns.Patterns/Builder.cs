using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Patterns
{
    [Flags]
    public enum BuiltObjectProperties
    {
        None = 0,
        Annoying = 1, // if 0 then not annoying
        Quiet = 2, // if 0 then loud is assumed to be true
    }
    public interface IBuiltObject : IPrintsSelf, IHasLogger
    {
        BuiltObjectProperties Properties { get; set; }
        ConsoleColor Color { get; set; }
    }

    public class BuiltObject : CommonLogsSelf, IBuiltObject
    {
        public BuiltObject(ILogger logger): base(logger) { }
        public ConsoleColor Color { get; set; } = ConsoleColor.White;

        public BuiltObjectProperties Properties { get; set; }

        public override void PrintSelf()
        {
            Logger.Log($@"Object description:
Annoying? {Properties.HasFlag(BuiltObjectProperties.Annoying)}
Quiet? {Properties.HasFlag(BuiltObjectProperties.Quiet)}
Loud? {!Properties.HasFlag(BuiltObjectProperties.Quiet)}", Color);
        }
    }

    public interface IBuilder
    {
        IBuilder Start();
        IBuilder Annoying();
        IBuilder Quiet();
        IBuilder Loud();
        IBuilder WithColor(ConsoleColor color);
        IBuiltObject Build();
    }
    public class Builder : CommonHasLogger, IBuilder
    {
        public Builder(ILogger logger) : base(logger) { }

        private IBuiltObject _object;
        public IBuilder Annoying()
        {
            _object.Properties |= BuiltObjectProperties.Annoying;
            return this;
        }

        public IBuiltObject Build()
        {
            return _object;
        }

        public IBuilder Loud()
        {
            _object.Properties &= ~BuiltObjectProperties.Quiet;
            return this;
        }

        public IBuilder Quiet()
        {
            _object.Properties |= BuiltObjectProperties.Quiet;
            return this;
        }

        public IBuilder Start()
        {
            _object = new BuiltObject(Logger);
            return this;
        }

        public IBuilder WithColor(ConsoleColor color)
        {
            _object.Color = color;
            return this;
        }
    }
}
