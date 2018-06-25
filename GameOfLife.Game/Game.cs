using System;

namespace GameOfLife.Game
{
    public class Game : IGame
    {
        public IGrid NextGeneration(IGrid current)
        {
            return current;
        }

        private int CountAliveNeighbours(IGrid grid, int x, int y)
        {
            if (x < 0 || y < 0 || x > grid.Width || y > grid.Height)
            {
                throw new ArgumentOutOfRangeException();
            }

            var isLeft = x == 0;
            var isRight = x == grid.Width;
            var isTop = y == 0;
            var isDown = y == grid.Height;
            
            var aliveNeighbourCount = 0;
            throw new NotImplementedException();
        }
        
    }
}