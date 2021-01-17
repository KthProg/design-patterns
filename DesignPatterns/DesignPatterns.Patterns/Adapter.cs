using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Patterns {
    public interface IAddSubtract<AddSubtractType> where AddSubtractType : struct {
        AddSubtractType Add(AddSubtractType a, AddSubtractType b);
        AddSubtractType Subtract(AddSubtractType a, AddSubtractType b);
    }

    public class AdditionSubtraction : IAddSubtract<int> {
        public int Add(int a, int b) => a + b;
        public int Subtract(int a, int b) => a - b;
    }

    public struct DivisionResult<MultiplyDivideType> {
        public MultiplyDivideType WholePart;
        public MultiplyDivideType Remainder;
    }

    public interface IMultiplyDivide<MultiplyDivideType> where MultiplyDivideType : struct {
        MultiplyDivideType Multiply(MultiplyDivideType a, MultiplyDivideType b);
        DivisionResult<int> Divide(MultiplyDivideType a, MultiplyDivideType b);
    }

    public class MultiplyDivideAdapter : IMultiplyDivide<int> {
        private readonly IAddSubtract<int> _addSubtract;

        public MultiplyDivideAdapter(IAddSubtract<int> addSubtract){
            _addSubtract = addSubtract;
        }

        public int Multiply(int a, int b){
            int result = 0;
            for(int iteration = 1; iteration <= b; ++iteration){
                result = _addSubtract.Add(result, a);
            }
            return result;
        }
        public DivisionResult<int> Divide(int a, int b){
            DivisionResult<int> result = new DivisionResult<int> {
                Remainder = a
            };
            while(result.Remainder >= b){
                result.Remainder = _addSubtract.Subtract(result.Remainder, b);
                ++result.WholePart;
            }
            return result;
        }
    }
}