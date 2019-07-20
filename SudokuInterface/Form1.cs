using SudokuInterface.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuInterface
{
    public partial class MainWindow : Form
    {
        Graphics drawArea;

        public MainWindow()
        {
            InitializeComponent();

            drawArea = panel1.CreateGraphics();
        }

        public void DrawTable()
        {
            var windowSize = panel1.Width;
            float singleSquareSize = windowSize / (float)Settings.BoardSize - (float)(1.7/(float)Settings.BoardSize);
            var coordinatesToDrawLines = new List<float>();
            var pen = new Pen(Color.Black);
            for (int i = 0; i <= Settings.BoardSize; i++)
            {
                coordinatesToDrawLines.Add(singleSquareSize * i);
                if (i % 3 == 0)
                    coordinatesToDrawLines.Add(singleSquareSize * i + 1);
            }
            foreach(var point in coordinatesToDrawLines)
            {
                drawArea.DrawLine(pen, point, 0, point, windowSize);
                drawArea.DrawLine(pen, 0, point, windowSize, point);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            DrawTable();
        }
    }
}
