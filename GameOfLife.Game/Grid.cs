using System;
using System.Linq;

namespace GameOfLife.Game
{
    public class Grid : IGrid
    {
        private readonly ICell[,] _grid;

        public Grid(int width, int height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
             
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

        public int Width => _grid.GetLength(0);

        public int Height => _grid.GetLength(1);

        public override bool Equals(object obj)
        {
            if (obj is Grid grid)
            {
                return _grid == grid._grid;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (_grid != null ? _grid.GetHashCode() : 0);
        }
    }
}