using System;
using System.Linq;

namespace GameOfLife.Game
{
    public class Grid : IGrid
    {
        private readonly ICell[,] _grid;

        public Grid(int width, int height)
        {
            _grid = new ICell[width, height];
            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    _grid[x, y] = new Cell(false);
                }
            }
        }

        public ICell this[int x, int y]
        {
            get => _grid[x, y];
            set => _grid[x, y] = value;
        }
    }
}