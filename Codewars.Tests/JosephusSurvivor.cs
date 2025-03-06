
using Kata.Library;

namespace Codewars.Tests
{
    [TestFixture]
    public static class JosephusSurvivorTests
    {
        private static void Testing(int actual, int expected)
        {
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public static void BasicTests1()
        {
            Testing(JosephusSurvivor.JosSurvivor(7, 3), 4);
        }

        [Test]
        public static void BasicTests2()
        {
            Testing(JosephusSurvivor.JosSurvivor(11, 19), 10);
        }

        [Test]
        public static void BasicTests3()
        {
            Testing(JosephusSurvivor.JosSurvivor(40, 3), 28);
        }

        [Test]
        public static void BasicTests4()
        {
            Testing(JosephusSurvivor.JosSurvivor(14, 2), 13);
        }

        [Test]
        public static void BasicTests5()
        {
            Testing(JosephusSurvivor.JosSurvivor(100, 1), 100);
        }

        [Test]
        public static void BasicTests6()
        {
            Testing(JosephusSurvivor.JosSurvivor(1, 300), 1);
        }

        [Test]
        public static void BasicTests7()
        {
            Testing(JosephusSurvivor.JosSurvivor(2, 300), 1);
        }

        [Test]
        public static void BasicTests8()
        {
            Testing(JosephusSurvivor.JosSurvivor(5, 300), 1);
        }

        [Test]
        public static void BasicTests9()
        {
            Testing(JosephusSurvivor.JosSurvivor(7, 300), 7);
        }

        [Test]
        public static void BasicTests10()
        {
            Testing(JosephusSurvivor.JosSurvivor(300, 300), 265);
        }
    }
}