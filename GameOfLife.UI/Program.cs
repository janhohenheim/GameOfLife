using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameOfLife.Game;

namespace GameOfLife.UI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IGrid GridFactory(int width, int height) => new Grid(width, height);
            ICell LivingCellFactory() => new Cell(true);
            ICell DeadCellFactory() => new Cell(false);
            IGame game = new Game.Game(GridFactory, LivingCellFactory, DeadCellFactory);
            
            Application.Run(new MainWindow(game, GridFactory, null));
        }
    }
}
