using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Patterns {
    public interface IWrapper<WrappedComponentType> {
        // technically a wrapper doesn't need to expose this,
        // but it's just so we have an interface to base these off of
        WrappedComponentType Component { get; }
    }

    public abstract class WrapperCommon<WrappedComponentType> : IWrapper<WrappedComponentType> {
        protected readonly WrappedComponentType _component;
        public WrapperCommon(WrappedComponentType component){
            _component = component;
        }

        public WrappedComponentType Component => _component;
    }

    public class Gift {
        public Gift(string name){
            Name = name;
        }
        public string Name { get; }
    }

    public class GiftBox : WrapperCommon<Gift> {
        public GiftBox(Gift gift) : base(gift){

        }

        public Gift Open() => Component;
        public string OpenAndGetName() => Open().Name;
    }

    public class WrappingPaper : WrapperCommon<GiftBox> {
        public WrappingPaper(GiftBox giftBox) : base(giftBox){

        }

        public GiftBox Unwrap() => Component;
        public Gift UnwrapAndOpen() => Unwrap().Open();
    }
}