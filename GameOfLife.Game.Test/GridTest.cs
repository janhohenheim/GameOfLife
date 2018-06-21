using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Game.Test
{
    [TestClass]
    public class GridTest
    {
        [TestMethod]
        public void TestInitializesNotAlive()
        {
            IGrid grid = new Grid(width: 3, height: 3);
            var cell = grid[x: 1, y: 1];
            Assert.IsFalse(cell.IsAlive);
        }

        [TestMethod]
        public void TestCanAccessOrigin()
        {
            IGrid grid = new Grid(width: 3, height: 3);
            var cell = grid[x: 0, y: 0];
            Assert.IsFalse(cell.IsAlive);
        }

        [TestMethod]
        public void TestCanAccessBorder()
        {
            IGrid grid = new Grid(width: 3, height: 3);
            var cell = grid[x: 2, y: 2];
            Assert.IsFalse(cell.IsAlive);
        }

        [TestMethod]
        public void TestCannotAccessOutOfBounds()
        {
            IGrid grid = new Grid(width: 3, height: 3);
            Assert.ThrowsException<IndexOutOfRangeException>(() => grid[x: 3, y: 3]);
        }

        [TestMethod]
        public void TestCanAccessMutation()
        {
            IGrid grid = new Grid(width: 3, height: 3);
            grid[x: 1, y: 1] = new Cell(true);
            var cell = grid[x: 1, y: 1];
            Assert.IsTrue(cell.IsAlive);
        }

        [TestMethod]
        public void TestCanMutateOrigin()
        {
            IGrid grid = new Grid(width: 3, height: 3);
            grid[x: 0, y: 0] = new Cell(true);
            var cell = grid[x: 0, y: 0];
            Assert.IsTrue(cell.IsAlive);
        }

        [TestMethod]
        public void TestCanMutateBorder()
        {
            IGrid grid = new Grid(width: 3, height: 3);
            grid[x: 2, y: 2] = new Cell(true);
            var cell = grid[x: 2, y: 2];
            Assert.IsTrue(cell.IsAlive);
        }

        [TestMethod]
        public void TestCannotMutateOutOfBounds()
        {
            IGrid grid = new Grid(width: 3, height: 3);
            Assert.ThrowsException<IndexOutOfRangeException>(() => grid[x: 3, y: 3] = new Cell(true));
        }
    }
}
