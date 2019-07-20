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

        public static void EliminatePossibilities(Board board)
        {
            BasicElimination(board);
        }

        public static void FillTheFields(Board board)
        {
            FillSinglePossibilityFields(board);
        }

        static void BasicElimination(Board board)
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

        static void FillSinglePossibilityFields(Board board)
        {
            for (int rowPosition = 0; rowPosition < Size; rowPosition++)
                for (int columnPosition = 0; columnPosition < Size; columnPosition++)
                {
                    FillOnePossibilityFields(board, rowPosition, columnPosition);
                    FillLastMissingInRowColumnOrSquare(board, rowPosition, columnPosition);
                }
        }

        #region Elimination

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

        #endregion

        #region Fill

        private static void FillOnePossibilityFields(Board board, int rowPosition, int columnPosition)
        {
            var field = board.GetField(rowPosition, columnPosition);
            if (!field.IsValid())
                throw new Exception("Invalid field");
                
            if (field.Possibilities.Count == 1)
                field.Value = field.Possibilities.First();
        }

        private static void FillLastMissingInRowColumnOrSquare(Board board, int rowPosition, int columnPosition)
        {
            var field = board.GetField(rowPosition, columnPosition);
            var row = board.GetFieldsFromRow(rowPosition);
            var column = board.GetFieldsFromColumn(columnPosition);
            var square = board.GetFieldsFromSquare(field.MasterSquare);

            for (int possibleNumber = 1; possibleNumber <= Size; possibleNumber++)
            {
                FillWithValueIfOneValueIsMissing(row, possibleNumber);
                FillWithValueIfOneValueIsMissing(column, possibleNumber);
                FillWithValueIfOneValueIsMissing(square, possibleNumber);
            }
        }

        private static void FillWithValueIfOneValueIsMissing(List<Field> fields, int possibleNumber)
        {
            int countOfPossibilities = 0;
            Field oneAndOnlyPossibilityField = null;
            bool shouldFillWithValue = false;
            foreach (var field in fields)
                if (field.Possibilities.Contains(possibleNumber))
                {
                    if (countOfPossibilities < 2)
                    {
                        countOfPossibilities++;
                        oneAndOnlyPossibilityField = field;
                    }
                    else
                        break;
                }

            shouldFillWithValue = countOfPossibilities == 1;

            if (shouldFillWithValue)
            {
                oneAndOnlyPossibilityField.SetValue(possibleNumber);
            }
        }

        #endregion
    }
}
