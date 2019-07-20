using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuLogic
{
    public class Field
    {
        public List<int> Possibilities { get; set; }
        public int MasterSquare { get; set; }
        public int? Value { get; set; }

        public Field()
        {
            Possibilities = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        }

        public bool HasValue()
        {
            return Value.HasValue;
        }

        public bool HasPossible(int value)
        {
            return Possibilities.Contains(value);
        }

        public bool IsValid()
        {
            return Possibilities.Any() || Value.HasValue;
        }

        public void RemovePossibility(int value)
        {
            Possibilities.Remove(value);
        }

        public void SetValue(int value)
        {
            Value = value;
            Possibilities = new List<int>();
        }

    }
}
