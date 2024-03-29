﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuLogic
{
    public class Board
    {
        public int Size { get; set; }
        List<List<Field>> board;
        public List<Field> AllFields { get; internal set; }

        public Board()
        {
            Size = Settings.BoardSize;
            AllFields = new List<Field>();
            board = new List<List<Field>>();
            for (int rowPosition = 0; rowPosition < Size; rowPosition++)
            {
                board.Add(new List<Field>());
                for (int columnPosition = 0; columnPosition < Size; columnPosition++)
                {
                    var field = new Field()
                    {
                        MasterSquare = GetMasterSquareNumber(rowPosition, columnPosition),
                        Row = rowPosition,
                        Column = columnPosition
                    };
                    board[rowPosition].Add(field);
                    AllFields.Add(field);
                }
            }
        }

        public List<Field> GetMasterSquareFields(int masterSquareValue)
        {
            var result = new List<Field>();
            foreach (var columns in board)
                foreach (var field in columns)
                    if (field.MasterSquare == masterSquareValue)
                        result.Add(field);
            return result;
        }

        public List<Field> GetFieldsFromRow(int index)
        {
            var result = new List<Field>();
            for (int i = 0; i < Size; i++)
                result.Add(board[index][i]);
            return result;
        }

        public List<Field> GetFieldsFromColumn(int index)
        {
            var result = new List<Field>();
            for (int i = 0; i < Size; i++)
                result.Add(board[i][index]);
            return result;
        }

        public List<Field> GetFieldsFromSquare(int masterSquare)
        {
            var result = new List<Field>();
            foreach (var column in board)
                result.AddRange(column.Where(x => x.MasterSquare == masterSquare));
            return result;
        }

        public void Init(List<List<int?>> initList)
        {
            if (initList.Count != Size || initList.Any(x => x.Count != Size))
                throw new FormatException();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (initList[i][j].HasValue)
                        board[i][j].SetValue(initList[i][j].Value);
                }
            }
        }

        public Field GetField(int x, int y)
        {
            return board[x][y];
        }

        public void PrintConsole(string args = null)
        {
            if (string.IsNullOrEmpty(args))
            {
                foreach (var columns in board)
                {
                    foreach (var field in columns)
                    {
                        Console.Write((field.Value.HasValue ? field.Value.Value.ToString() : " ") + " ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                if (args == "MasterSquare")
                {
                    foreach (var columns in board)
                    {
                        foreach (var field in columns)
                        {
                            Console.Write(field.MasterSquare + " ");
                        }
                        Console.WriteLine();
                    }
                }
                if (args == "P1")
                {
                    foreach (var columns in board)
                    {
                        foreach (var field in columns)
                        {
                            Console.Write(field.Possibilities.Where(x => x == 1).Any() ? "p1" : field.HasValue() ? field.Value.ToString() + " " : "  ");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }

        int GetMasterSquareNumber(int x, int y)
        {
            return (x / 3) * 3 + (y / 3);
        }
    }
}
