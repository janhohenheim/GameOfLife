namespace GameOfLife.UI
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHost = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlHost
            // 
            this.pnlHost.BackColor = System.Drawing.Color.Azure;
            this.pnlHost.Location = new System.Drawing.Point(12, 12);
            this.pnlHost.Name = "pnlHost";
            this.pnlHost.Size = new System.Drawing.Size(776, 426);
            this.pnlHost.TabIndex = 0;
            this.pnlHost.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHost_Paint);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlHost);
            this.Name = "MainWindow";
            this.Text = "Game of Life";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHost;
    }
}

