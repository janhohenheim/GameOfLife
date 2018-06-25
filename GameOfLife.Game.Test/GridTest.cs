using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Game.Test
{
    [TestClass]
    public class GridTest
    {
        [TestMethod]
        public void TestThrowsAtZeroedWidth()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Grid(width: 0, height: 3));
        }

        [TestMethod]
        public void TestThrowsAtZeroedHeight()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Grid(width: 3, height: 0));
        }

        [TestMethod]
        public void TestThrowsAtNegativeWidth()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Grid(width: -1, height: 3));
        }

        [TestMethod]
        public void TestThrowsAtNegativeHeight()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Grid(width: 3, height: -1));
        }


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

        [TestMethod]
        public void TestReturnsCorrectWidth()
        {
            IGrid grid = new Grid(width: 3, height: 4);
            var width = grid.Width;
            Assert.AreEqual(3, width);
        }
        
        [TestMethod]
        public void TestReturnsCorrectHeight()
        {
            IGrid grid = new Grid(width: 3, height: 4);
            var height = grid.Height;
            Assert.AreEqual(4, height);
        }
    }
}
