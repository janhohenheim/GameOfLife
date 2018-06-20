namespace GameOfLife.Game
{
    public interface IGame
    {
        IGrid NextGeneration(IGrid current);
    }
}