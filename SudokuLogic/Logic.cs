using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuLogic
{
    public static class Logic
    {
        public static int Size = Settings.BoardSize;
        public static void BasicElimination(Board board)
        {
            for (int rowPosition = 0; rowPosition < Size; rowPosition++)
            {
                for (int columnPosition = 0; columnPosition < Size; columnPosition++)
                {
                    if (board.GetField(rowPosition, columnPosition).HasValue())
                    {
                        EliminateRowsAndColumns(board, rowPosition, columnPosition);
                        EliminateInSquare(board, rowPosition, columnPosition);
                    }
                }
            }

        }

        private static void EliminateRowsAndColumns(Board board, int rowPosition, int columnPosition)
        {
            int value = board.GetField(rowPosition, columnPosition).Value.Value;
            var fieldsToEliminate = new List<Field>();
            fieldsToEliminate.AddRange(board.GetFieldsFromColumn(columnPosition));
            fieldsToEliminate.AddRange(board.GetFieldsFromRow(rowPosition));
            foreach (var field in fieldsToEliminate)
                field.RemovePossibility(value);
        }

        private static void EliminateInSquare(Board board, int rowPosition, int columnPosition)
        {
            int value = board.GetField(rowPosition, columnPosition).Value.Value;
            int masterySquare = board.GetField(rowPosition, columnPosition).MasterSquare;
            var fieldsToEliminate = board.GetMasterSquareFields(masterySquare);
            foreach (var field in fieldsToEliminate)
                field.RemovePossibility(value);
        }
    }
}
