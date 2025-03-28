using Codewars.Library;

namespace Codewars.Tests
{
    [TestFixture]
    public class FluentCalculatorTests
    {
        [Test, Order(1)]
        public static void BasicAddition()
        {
            var calculator = new FluentCalculator();

            //Test Result Call
            Assert.That(calculator.One.Plus.Two.Result(), Is.EqualTo(3));
        }

        [Test, Order(2)]
        public static void MultipleInstances()
        {
            var calculatorOne = new FluentCalculator();
            var calculatorTwo = new FluentCalculator();

            Assert.That((double)calculatorOne.Five.Plus.Five, Is.Not.EqualTo((double)calculatorTwo.Seven.Times.Three));
        }

        [Test, Order(3)]
        public static void MultipleCalls()
        {
            //Testing that the expression or reference clears between calls
            var calculator = new FluentCalculator();
            Assert.That(calculator.One.Plus.One.Result() + calculator.One.Plus.One.Result(), Is.EqualTo(4));
        }

        [Test, Order(4)]
        public static void Bedmas()
        {
            //Testing Order of Operations
            var calculator = new FluentCalculator();
            Assert.That((double)calculator.Six.Times.Six.Plus.Eight.DividedBy.Two.Times.Two.Plus.Ten.Times.Four.DividedBy.Two.Minus.Six, Is.EqualTo(58));
            Assert.That((double)calculator.Zero.Minus.Four.Times.Three.Plus.Two.DividedBy.Eight.Times.One.DividedBy.Nine, Is.EqualTo(-11.972).Within(0.01));
        }

        [Test, Order(5)]
        public static void StaticCombinationCalls()
        {
            //Testing Implicit Conversions
            var calculator = new FluentCalculator();
            Assert.That(10 * calculator.Six.Plus.Four.Times.Three.Minus.Two.DividedBy.Eight.Times.One.Minus.Five.Times.Zero, Is.EqualTo(177.5));
        }
    }
}
