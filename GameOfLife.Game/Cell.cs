using System;

namespace GameOfLife.Game
{
    public struct Cell : ICell
    {
        public Cell(bool isAlive)
        {
            IsAlive = isAlive;
        }

        public bool IsAlive { get; }

        public override string ToString()
        {
            return $"{(IsAlive ? "Living Cell" : "Dead Cell")}";
        }
    }
}