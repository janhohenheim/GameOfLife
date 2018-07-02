using GameOfLife.Game;

namespace GameOfLife.UI
{
    public interface IGridDrawer<in TDrawingTarget>
    {
        void Draw(IGrid grid, TDrawingTarget target);
    }
}