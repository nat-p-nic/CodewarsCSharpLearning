namespace Codewars.Library
{
    public class FluentCalculator
    {
        public CalculatorValue Zero => new(0);
        public CalculatorValue One => new(1);
        public CalculatorValue Two => new(2);
        public CalculatorValue Three => new(3);
        public CalculatorValue Four => new(4);
        public CalculatorValue Five => new(5);
        public CalculatorValue Six => new(6);
        public CalculatorValue Seven => new(7);
        public CalculatorValue Eight => new(8);
        public CalculatorValue Nine => new(9);
        public CalculatorValue Ten => new(10);

        public class CalculatorValue
        {
            private readonly double _value;

            public CalculatorValue(double value) => _value = value;

            public CalculatorOperation Plus => new(_value, OperatorType.Add);
            public CalculatorOperation Minus => new(_value, OperatorType.Subtract);
            public CalculatorOperation Times => new(_value, OperatorType.Multiply);
            public CalculatorOperation DividedBy => new(_value, OperatorType.Divide);

            public double Result() => Evaluate();

            public static implicit operator double(CalculatorValue cv) => cv.Result();

            private double Evaluate()
            {
                return _value;
            }

            internal CalculatorValue Append(OperatorType op, double nextValue)
            {
                return new CalculatorValue(0); // placeholder
            }
        }

        public enum OperatorType { Add, Subtract, Multiply, Divide }

        public class CalculatorOperation
        {
            private readonly double _left;
            private readonly OperatorType _operator;

            public CalculatorOperation(double left, OperatorType op)
            {
                _left = left;
                _operator = op;
            }

            // Only allow a value to follow an operation.
            // You will have properties for each allowed value (Zero to Ten).
            public CalculatorValue Zero => new CalculatorValue(_left).Append(_operator, 0);
            public CalculatorValue One => new CalculatorValue(_left).Append(_operator, 1);
            public CalculatorValue Two => new CalculatorValue(_left).Append(_operator, 2);
            public CalculatorValue Three => new CalculatorValue(_left).Append(_operator, 3);
            public CalculatorValue Four => new CalculatorValue(_left).Append(_operator, 4);
            public CalculatorValue Five => new CalculatorValue(_left).Append(_operator, 5);
            public CalculatorValue Six => new CalculatorValue(_left).Append(_operator, 6);
            public CalculatorValue Seven => new CalculatorValue(_left).Append(_operator, 7);
            public CalculatorValue Eight => new CalculatorValue(_left).Append(_operator, 8);
            public CalculatorValue Nine => new CalculatorValue(_left).Append(_operator, 9);
            public CalculatorValue Ten => new CalculatorValue(_left).Append(_operator, 10);
        }

    }
}