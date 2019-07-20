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
                new List<int?>{ 1, null, null, null, null, null ,6 ,7 ,8},
                new List<int?>{ null, null, null, null, 5, null ,4 ,3 ,2},
                new List<int?>{ null, null, 3, null, null, null ,null ,5 ,1},

                new List<int?>{ null, null, null, null, null, null ,null ,1 ,null},
                new List<int?>{ null, null, null, null, null, null ,null ,null ,null},
                new List<int?>{ null, null, null, null, null, null ,null ,null ,null},

                new List<int?>{ null, null, null, null, 7, null ,null ,null ,null},
                new List<int?>{ null, null, null, null, null, null ,null ,null ,null},
                new List<int?>{ null, 4, null, null, null, null ,null ,null ,null},
            };
            board.Init(initList);

            board.PrintConsole();
            Logic.EliminatePossibilities(board);
            Logic.FillTheFields(board);
            board.PrintConsole();

        }
    }
}
