using System;

namespace GameOfLife.Game
{
    public class Cell : ICell
    {
        public Cell(bool isAlive)
        {
            IsAlive = isAlive;
        }

        public bool IsAlive { get; }
    }
}