using System;

namespace GameOfLife.Game
{
    public delegate ICell CellFactory();

    public delegate IGrid GridFactory(int width, int height);

    public class Game : IGame
    {
        private readonly GridFactory _gridFactory;
        private readonly CellFactory _livingCellFactory;
        private readonly CellFactory _deadCellFactory;

        public Game(GridFactory gridFactory, CellFactory livingCellFactory, CellFactory deadCellFactory)
        {
            _gridFactory = gridFactory;
            _livingCellFactory = livingCellFactory;
            _deadCellFactory = deadCellFactory;
        }
        
        public IGrid NextGeneration(IGrid current)
        {
            var nextGen = _gridFactory(current.Width, current.Height);

            for (var x = 0; x < current.Width; x++)
            {
                for (var y = 0; y < current.Height; y++)
                {
                    var aliveNeighbourCount = CountAliveNeighbours(current, x, y);

                    switch (aliveNeighbourCount)
                    {
                        case 2 when current[x, y].IsAlive:
                        case 3:
                            nextGen[x, y] = _livingCellFactory();
                            break;
                        default:
                            nextGen[x, y] = _deadCellFactory();
                            break;
                    }
                }
            }

            return nextGen;
        }

        private static int CountAliveNeighbours(IGrid grid, int x, int y)
        {
            if (x < 0 || y < 0 || x >= grid.Width || y >= grid.Height)
            {
                throw new ArgumentOutOfRangeException();
            }

            var isLeft = x == 0;
            var isRight = x == grid.Width - 1;
            var isTop = y == 0;
            var isDown = y == grid.Height - 1;

            var aliveNeighbourCount = 0;

            if (!isLeft && !isTop && grid[x - 1, y - 1].IsAlive)
            {
                aliveNeighbourCount++;
            }

            if (!isTop && grid[x, y - 1].IsAlive)
            {
                aliveNeighbourCount++;
            }

            if (!isTop && !isRight && grid[x + 1, y - 1].IsAlive)
            {
                aliveNeighbourCount++;
            }

            if (!isRight && grid[x + 1, y].IsAlive)
            {
                aliveNeighbourCount++;
            }

            if (!isRight && !isDown && grid[x + 1, y + 1].IsAlive)
            {
                aliveNeighbourCount++;
            }

            if (!isDown && grid[x, y + 1].IsAlive)
            {
                aliveNeighbourCount++;
            }

            if (!isLeft && !isDown && grid[x - 1, y + 1].IsAlive)
            {
                aliveNeighbourCount++;
            }

            if (!isLeft && grid[x - 1, y].IsAlive)
            {
                aliveNeighbourCount++;
            }

            return aliveNeighbourCount;
        }
    }
}