namespace Codewars.Tests
{
    public class SolutionTest
    {
        [Test]
        public void FixedTests1()
        {
            Assert.That(Parser.ParseInt("one"), Is.EqualTo(1));
        }

        [Test]
        public void FixedTests2()
        {
            Assert.That(Parser.ParseInt("twenty"), Is.EqualTo(20));
        }

        [Test]
        public void FixedTests3()
        {
            Assert.That(Parser.ParseInt("two hundred forty-six"), Is.EqualTo(246));
        }
    }
}