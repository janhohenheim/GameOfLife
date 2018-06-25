using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Game.Test
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void TestDeadGridStaysDead()
        {
            IGame game = new Game();
            IGrid deadGrid = new Grid(3, 3);
            IGrid nextGen = game.NextGeneration(deadGrid);
            Assert.AreEqual(deadGrid, nextGen);
        }

        [TestMethod]
        public void TestLoneAliveCellDies()
        {
            IGame game = new Game();
            IGrid grid = new Grid(3, 3);
            grid[1, 1] = new Cell(true);
            var nextGen = game.NextGeneration(grid);

            IGrid deadGrid = new Grid(3, 3);
            Assert.AreEqual(deadGrid, nextGen);
        }


        [TestMethod]
        public void TestAliveCellInCornerDies()
        {
            IGame game = new Game();
            IGrid grid = new Grid(3, 3);
            grid[0, 0] = new Cell(true);
            var nextGen = game.NextGeneration(grid);

            IGrid deadGrid = new Grid(3, 3);
            Assert.AreEqual(deadGrid, nextGen);
        }

        [TestMethod]
        public void TestAliveCellInCornerWithNeighbourDies()
        {
            IGame game = new Game();
            IGrid grid = new Grid(3, 3);
            grid[0, 0] = new Cell(true);
            grid[1, 1] = new Cell(true);
            var nextGen = game.NextGeneration(grid);

            IGrid deadGrid = new Grid(3, 3);
            Assert.AreEqual(deadGrid, nextGen);
        }

        [TestMethod]
        public void TestAliveCellWithTwoNeighboursSurvives()
        {
            IGame game = new Game();
            IGrid grid = new Grid(3, 3);
            grid[0, 0] = new Cell(true);
            grid[0, 1] = new Cell(true);
            grid[1, 1] = new Cell(true);
            var nextGen = game.NextGeneration(grid);
            
            Assert.AreEqual(grid, nextGen);
        }


        [TestMethod]
        public void TestAliveCellWithFourNeighboursDies()
        {
            IGame game = new Game();
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
            var nextGen = game.NextGeneration(grid);

            Assert.IsFalse(nextGen[1, 1].IsAlive);
        }

        [TestMethod]
        public void TestDeadCellWithThreeNeighboursResurects()
        {
            IGame game = new Game();
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
            var nextGen = game.NextGeneration(grid);

            Assert.IsTrue(nextGen[1, 2].IsAlive);
        }

        [TestMethod]
        public void TestDeadCellWithFourNeighboursStaysdead()
        {
            IGame game = new Game();
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
            var nextGen = game.NextGeneration(grid);

            Assert.IsFalse(nextGen[1, 0].IsAlive);
        }

        [TestMethod]
        public void TestBlockStaysBlock()
        {
            IGame game = new Game();
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
            var nextGen = game.NextGeneration(grid);

            Assert.AreEqual(grid, nextGen);
        }

        [TestMethod]
        public void TestBlinkerPeriodOne()
        {
            IGame game = new Game();
            IGrid grid = new Grid(3, 3);
            /*
             * . | . | .
             * O | O | O
             * . | . | .
             */
            grid[0, 1] = new Cell(true);
            grid[1, 1] = new Cell(true);
            grid[2, 1] = new Cell(true);
            var nextGen = game.NextGeneration(grid);

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
            IGame game = new Game();
            IGrid grid = new Grid(3, 3);
            /*
            * . | O | .
            * . | O | .
            * . | O | .
            */
            grid[1, 0] = new Cell(true);
            grid[1, 1] = new Cell(true);
            grid[1, 2] = new Cell(true);
            var nextGen = game.NextGeneration(grid);

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
