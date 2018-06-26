using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Game.Test
{
    [TestClass]
    public class GameTest
    {
        private IGame _game = new Game(
            (width, height) => new Grid(width, height),
            () => new Cell(true),
            () => new Cell(false));

        [TestMethod]
        public void TestDeadGridStaysDead()
        {
            IGrid deadGrid = new Grid(3, 3);
            IGrid nextGen = _game.NextGeneration(deadGrid);
            Assert.AreEqual(deadGrid, nextGen);
        }

        [TestMethod]
        public void TestLoneAliveCellDies()
        {
            IGrid grid = new Grid(3, 3);
            grid[1, 1] = new Cell(true);
            var nextGen = _game.NextGeneration(grid);

            IGrid deadGrid = new Grid(3, 3);
            Assert.AreEqual(deadGrid, nextGen);
        }


        [TestMethod]
        public void TestAliveCellInCornerDies()
        {
            IGrid grid = new Grid(3, 3);
            grid[0, 0] = new Cell(true);
            var nextGen = _game.NextGeneration(grid);

            IGrid deadGrid = new Grid(3, 3);
            Assert.AreEqual(deadGrid, nextGen);
        }

        [TestMethod]
        public void TestAliveCellInCornerWithNeighbourDies()
        {
            IGrid grid = new Grid(3, 3);
            grid[0, 0] = new Cell(true);
            grid[1, 1] = new Cell(true);
            var nextGen = _game.NextGeneration(grid);

            IGrid deadGrid = new Grid(3, 3);
            Assert.AreEqual(deadGrid, nextGen);
        }

        [TestMethod]
        public void TestAliveCellWithTwoNeighboursSurvives()
        {
            IGrid grid = new Grid(3, 3);
            grid[0, 0] = new Cell(true);
            grid[0, 1] = new Cell(true);
            grid[1, 1] = new Cell(true);
            var nextGen = _game.NextGeneration(grid);

            Assert.AreEqual(grid, nextGen);
        }


        [TestMethod]
        public void TestAliveCellWithFourNeighboursDies()
        {
            IGrid grid = new Grid(3, 3);
            /*
             * O | . | O
             * O | O | .
             * O | . | .
             */
            grid[0, 0] = new Cell(true);
            grid[0, 1] = new Cell(true);
            grid[0, 2] = new Cell(true);
            grid[2, 0] = new Cell(true);
            grid[1, 1] = new Cell(true);
            var nextGen = _game.NextGeneration(grid);

            Assert.IsFalse(nextGen[1, 1].IsAlive);
        }

        [TestMethod]
        public void TestDeadCellWithThreeNeighboursResurects()
        {
            IGrid grid = new Grid(3, 3);
            /*
             * O | . | O
             * O | O | .
             * O | . | .
             */
            grid[0, 0] = new Cell(true);
            grid[0, 1] = new Cell(true);
            grid[0, 2] = new Cell(true);
            grid[2, 0] = new Cell(true);
            grid[1, 1] = new Cell(true);
            var nextGen = _game.NextGeneration(grid);

            Assert.IsTrue(nextGen[1, 2].IsAlive);
        }

        [TestMethod]
        public void TestDeadCellWithFourNeighboursStaysdead()
        {
            IGrid grid = new Grid(3, 3);
            /*
             * O | . | O
             * O | O | .
             * O | . | .
             */
            grid[0, 0] = new Cell(true);
            grid[0, 1] = new Cell(true);
            grid[0, 2] = new Cell(true);
            grid[2, 0] = new Cell(true);
            grid[1, 1] = new Cell(true);
            var nextGen = _game.NextGeneration(grid);

            Assert.IsFalse(nextGen[1, 0].IsAlive);
        }

        [TestMethod]
        public void TestBlockStaysBlock()
        {
            IGrid grid = new Grid(4, 4);
            /*
             * . | . | . | .
             * . | O | O | .
             * . | O | O | .
             * . | . | . | .
             */
            grid[1, 1] = new Cell(true);
            grid[1, 2] = new Cell(true);
            grid[2, 1] = new Cell(true);
            grid[2, 2] = new Cell(true);
            var nextGen = _game.NextGeneration(grid);

            Assert.AreEqual(grid, nextGen);
        }

        [TestMethod]
        public void TestBlinkerPeriodOne()
        {
            IGrid grid = new Grid(3, 3);
            /*
             * . | . | .
             * O | O | O
             * . | . | .
             */
            grid[0, 1] = new Cell(true);
            grid[1, 1] = new Cell(true);
            grid[2, 1] = new Cell(true);
            var nextGen = _game.NextGeneration(grid);

            IGrid expected = new Grid(3, 3);
            /*
             * . | O | .
             * . | O | .
             * . | O | .
             */
            expected[1, 0] = new Cell(true);
            expected[1, 1] = new Cell(true);
            expected[1, 2] = new Cell(true);
            Assert.AreEqual(expected, nextGen);
        }

        [TestMethod]
        public void TestBlinkerPeriodTwo()
        {
            IGrid grid = new Grid(3, 3);
            /*
            * . | O | .
            * . | O | .
            * . | O | .
            */
            grid[1, 0] = new Cell(true);
            grid[1, 1] = new Cell(true);
            grid[1, 2] = new Cell(true);
            var nextGen = _game.NextGeneration(grid);

            IGrid expected = new Grid(3, 3);
            /*
             * . | . | .
             * O | O | O
             * . | . | .
             */
            expected[0, 1] = new Cell(true);
            expected[1, 1] = new Cell(true);
            expected[2, 1] = new Cell(true);
            Assert.AreEqual(expected, nextGen);
        }

    }
}
