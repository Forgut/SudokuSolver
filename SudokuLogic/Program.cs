using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            var initList = new List<List<int?>> {
                new List<int?>{ 1, null, null, null, null, null ,null ,null ,8},
                new List<int?>{ null, null, null, null, 5, null ,null ,null ,null},
                new List<int?>{ null, null, 3, null, null, null ,null ,null ,null},
                new List<int?>{ null, null, null, null, null, null ,null ,1 ,null},
                new List<int?>{ null, null, null, null, null, null ,null ,null ,null},
                new List<int?>{ null, null, null, null, null, null ,null ,null ,null},
                new List<int?>{ null, null, null, null, 7, null ,null ,null ,null},
                new List<int?>{ null, null, null, null, null, null ,null ,null ,null},
                new List<int?>{ null, 4, null, null, null, null ,null ,null ,null},
            };
            board.Init(initList);

            board.PrintConsole();
            board.PrintConsole("P1");
            Logic.BasicElimination(board);
            board.PrintConsole("P1");

        }
    }
}
