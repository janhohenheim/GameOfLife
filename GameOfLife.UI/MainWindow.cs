using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace GameOfLife.UI
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void pnlHost_Click(object sender, EventArgs e)
        {
            Debugger.Break();
        }

        private void pnlHost_Paint(object sender, PaintEventArgs e)
        {
            var panel = (Panel)sender;
            var graphics = e.Graphics;

            using (var brush = new SolidBrush(Color.Maroon))
            using (var pen = new Pen(brush))
            {
                graphics.DrawLine(pen, new Point(15, 15), new Point(199, 123) );
            }
        }
    }
}
