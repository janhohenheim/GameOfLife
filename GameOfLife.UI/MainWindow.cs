using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using GameOfLife.Game;
using GameOfLife.UI.Properties;

namespace GameOfLife.UI
{
    public delegate IGrid GridFactory(int width, int height);

    public partial class MainWindow : Form
    {
        private readonly IGame _game;
        private readonly GridFactory _gridFactory;
        private readonly IGraphicsGridDrawer _gridDrawer;
        private IGrid _grid;

        public MainWindow(IGame game, GridFactory gridFactory, IGraphicsGridDrawer gridDrawer)
        {
            _game = game;
            _gridFactory = gridFactory;
            _gridDrawer = gridDrawer;
            _grid = gridFactory(Settings.Default.DefaultWidth, Settings.Default.DefaultHeight);
            
            InitializeComponent();
        }

        private void pnlHost_Paint(object sender, PaintEventArgs e)
        {
            var panel = (Panel)sender;
            var graphics = e.Graphics;

            using (var brush = new SolidBrush(Color.Black))
            using (var pen = new Pen(brush))
            {
                const int cellSize = 10;
                var rect = new Rectangle(10, 10, cellSize, cellSize);
                
            }
        }
    }
}
