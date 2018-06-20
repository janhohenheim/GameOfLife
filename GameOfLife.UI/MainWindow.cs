using System;
using System.Diagnostics;
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
    }
}
