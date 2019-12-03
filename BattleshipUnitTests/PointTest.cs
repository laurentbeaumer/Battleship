using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleshipUnitTests
{
    using Battleship;

    [TestClass]
    public class PointTest
    {
        [TestMethod]
        public void TestToString()
        {
            Assert.AreEqual(new Point { Row = 2, Column = 4 }.ToString(), "{2, 4}");
        }
    }
}
