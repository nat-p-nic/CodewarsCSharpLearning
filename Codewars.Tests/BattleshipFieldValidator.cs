using Codewars.Library;

namespace Codewars.Tests
{
    [TestFixture]
    public class BattleshipFieldValidatorTests
    {
        [Test]
        public void TestCase()
        {
            int[,] field = new int[10, 10]
                             {{1, 0, 0, 0, 0, 1, 1, 0, 0, 0},
                              {1, 0, 1, 0, 0, 0, 0, 0, 1, 0},
                              {1, 0, 1, 0, 1, 1, 1, 0, 1, 0},
                              {1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                              {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                              {0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
                              {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                              {0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                              {0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                              {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};

            Assert.That(BattleshipField.ValidateBattlefield(field), Is.True);
        }
    }
}