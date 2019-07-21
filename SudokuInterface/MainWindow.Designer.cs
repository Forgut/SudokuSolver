namespace SudokuInterface
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
            this.DrawingPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // DrawingPanel
            // 
            this.DrawingPanel.Location = new System.Drawing.Point(9, 9);
            this.DrawingPanel.Margin = new System.Windows.Forms.Padding(0);
            this.DrawingPanel.Name = "DrawingPanel";
            this.DrawingPanel.Size = new System.Drawing.Size(494, 465);
            this.DrawingPanel.TabIndex = 0;
            this.DrawingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawingPanel_Paint);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 483);
            this.Controls.Add(this.DrawingPanel);
            this.Name = "MainWindow";
            this.Text = "Sudoku";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel DrawingPanel;
    }
}

