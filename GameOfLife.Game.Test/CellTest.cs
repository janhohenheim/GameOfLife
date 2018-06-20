using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Game.Test
{
    [TestClass]
    public class CellTest
    {
        [TestMethod]
        public void TestIsAlive()
        {
            ICell alive = new Cell(true);

            Assert.IsTrue(alive.IsAlive);
        }

        [TestMethod]
        public void TestIsNotAlive()
        {
            ICell alive = new Cell(false);

            Assert.IsFalse(alive.IsAlive);
        }
    }
}
