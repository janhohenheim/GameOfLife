namespace GameOfLife.Game
{
    public interface IGrid
    {
        ICell this[int x, int y] { get; set; }
    }
}