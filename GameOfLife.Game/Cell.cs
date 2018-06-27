using System;

namespace GameOfLife.Game
{
    public struct Cell : ICell, IEquatable<Cell>
    {
        public Cell(bool isAlive)
        {
            IsAlive = isAlive;
        }

        public bool IsAlive { get; }

        public override bool Equals(object obj)
        {
            return obj is Cell cell && Equals(cell);
        }

        public bool Equals(Cell other)
        {
            return IsAlive == other.IsAlive;
        }

        public override int GetHashCode()
        {
            return -1167581050 + IsAlive.GetHashCode();
        }

        public override string ToString()
        {
            return $"{(IsAlive ? "Living Cell" : "Dead Cell")}";
        }

        public static bool operator ==(Cell cell1, Cell cell2)
        {
            return cell1.Equals(cell2);
        }

        public static bool operator !=(Cell cell1, Cell cell2)
        {
            return !(cell1 == cell2);
        }
    }
}