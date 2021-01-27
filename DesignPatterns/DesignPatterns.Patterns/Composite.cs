using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Patterns {
    public interface IComposite : IPrintsSelf, IHasLogger {
        void Add(IComposite child);
        void Remove(IComposite child);
        IComposite GetChildAt(int index);
        int ChildrenCount { get; }
    }

    public abstract class CompositeCommon : CommonLogsSelf, IComposite {
        private readonly IList<IComposite> _children;

        public CompositeCommon(ILogger logger) : base(logger){
            _children = new List<IComposite>();
        }
        public virtual void Add(IComposite child) => _children.Add(child);
        public virtual void Remove(IComposite child) => _children.Remove(child);
        public virtual IComposite GetChildAt(int index) => _children[index];
        public int ChildrenCount => _children.Count;
    }

    public class CompositeA : CompositeCommon {
        public CompositeA(ILogger logger) : base(logger){

        }
    }

    public class CompositeB : CompositeCommon {
        public CompositeB(ILogger logger) : base(logger){

        }
    }

    public class CompositeC : CompositeCommon {
        public CompositeC(ILogger logger) : base(logger){

        }
    }
}