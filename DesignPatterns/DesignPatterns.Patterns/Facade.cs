using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Patterns {
    // technically not necessary to define the child types but I like it
    public interface IFacade<ChildTypeA, ChildTypeB, ChildTypeC> {
        double GetRandomNumbersAndDivideThem();
        double GetRandomNumbersAndMultiplyThem();

        ChildTypeA ChildA { get; }
        ChildTypeB ChildB { get; }
        ChildTypeC ChildC { get; }
    }

    public class FacadeChildA {
        public int RandomSeed => (int)(DateTime.Now.Ticks % Int32.MaxValue);
    }

    public class FacadeChildB {
        public double GetRandomNumber(int seed) => new Random(seed).NextDouble() * 1000D;
    }

    public class FacadeChildC {
        public double Multiply(double a, double b) => a * b;
        public double Divide(double a, double b) => a / b;
    }

    public class Facade : IFacade<FacadeChildA, FacadeChildB, FacadeChildC> {
        private readonly FacadeChildA _facadeChildA;
        private readonly FacadeChildB _facadeChildB; 
        private readonly FacadeChildC _facadeChildC;
        public Facade(FacadeChildA facadeChildA, FacadeChildB facadeChildB, FacadeChildC facadeChildC) {
            _facadeChildA = facadeChildA;
            _facadeChildB = facadeChildB;
            _facadeChildC = facadeChildC;
        }

        // technically these would be hidden in a facade
        public FacadeChildA ChildA => _facadeChildA;
        public FacadeChildB ChildB => _facadeChildB;
        public FacadeChildC ChildC => _facadeChildC;

        public double GetRandomNumbersAndDivideThem() => ChildB.GetRandomNumber(ChildA.RandomSeed) / ChildB.GetRandomNumber(ChildA.RandomSeed);
        public double GetRandomNumbersAndMultiplyThem() => ChildB.GetRandomNumber(ChildA.RandomSeed) * ChildB.GetRandomNumber(ChildA.RandomSeed);
    }
}