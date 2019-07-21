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
        Pen pen = new Pen(Color.Black);
        int WindowSize;
        float SingleSquareSize;


        public MainWindow()
        {
            InitializeComponent();

            WindowSize = DrawingPanel.Width;
            SingleSquareSize = WindowSize / (float)Settings.BoardSize - (float)(1.7 / (float)Settings.BoardSize);
            drawArea = DrawingPanel.CreateGraphics();
        }

        public void DrawValuesAndPossibilities(SudokuLogic.Board board)
        {

            foreach (var field in board.AllFields)
            {
                if (field.HasValue())
                    DrawNumber(field);
                else
                    DrawPossibilities(field);
            }
        }

        private void DrawPossibilities(SudokuLogic.Field field)
        {
            var font = new Font("Arial", 9);
            var brush = new SolidBrush(Color.Blue);
            float masterXPosition = field.Row * SingleSquareSize;
            float masterYPosition = field.Column * SingleSquareSize;
            var drawFormat = new StringFormat();
            foreach (var possibility in field.Possibilities)
            {
                float xPosition = GetPossibilityXPosition(possibility);
                float yPosition = GetPossibilityYPosition(possibility);
                var stringToDraw = possibility.ToString();

                drawArea.DrawString(stringToDraw, font, brush, xPosition, yPosition);
            }

            float GetPossibilityXPosition(int possibility)
            {
                return masterXPosition + ((float)((possibility - 1) % 3) / 3 * SingleSquareSize) + SingleSquareSize / 24;
            }
            float GetPossibilityYPosition(int possibility)
            {
                return masterYPosition + ((float)((possibility - 1) / 3) / 3 * SingleSquareSize) + SingleSquareSize / 48;
            }
        }

        private void DrawNumber(SudokuLogic.Field field)
        {
            if (field.Value.HasValue)
            {
                var stringToDraw = field.Value.Value.ToString();
                var font = new Font("Arial", 25);
                var brush = new SolidBrush(Color.Black);
                float xPosition = GetNumberXPosition();
                float yPosition = GetNumberYPosition();
                var drawFormat = new StringFormat();

                drawArea.DrawString(stringToDraw, font, brush, xPosition, yPosition);
            }

            float GetNumberXPosition()
            {
                return field.Row * SingleSquareSize + SingleSquareSize / 6;
            }
            float GetNumberYPosition()
            {
                return field.Column * SingleSquareSize + SingleSquareSize / 12;
            }
        }

        private void DrawValue(SudokuLogic.Field field)
        {
            var x = field.Row * SingleSquareSize;
            var y = field.Column * SingleSquareSize;
            drawArea.DrawEllipse(pen, x, y, SingleSquareSize, SingleSquareSize);
        }

        public void DrawTable()
        {

            var coordinatesToDrawLines = new List<float>();
            for (int i = 0; i <= Settings.BoardSize; i++)
            {
                coordinatesToDrawLines.Add(SingleSquareSize * i);
                if (i % 3 == 0)
                    coordinatesToDrawLines.Add(SingleSquareSize * i + 1);
            }
            foreach (var point in coordinatesToDrawLines)
            {
                drawArea.DrawLine(pen, point, 0, point, WindowSize);
                drawArea.DrawLine(pen, 0, point, WindowSize, point);
            }
        }

        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            DrawTable();
            var board = new SudokuLogic.Board();
            board.GetField(3, 4).SetValue(3);
            board.GetField(8, 8).SetValue(1);
            board.GetField(3, 3).SetValue(4);
            SudokuLogic.Logic.EliminatePossibilities(board);
            SudokuLogic.Logic.FillTheFields(board);
            DrawValuesAndPossibilities(board);
        }
    }
}
