using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SudokuInterface
{
    public class Settings
    {
        public static int BoardSize
        {
            get
            {
                int.TryParse(ConfigurationManager.AppSettings["BoardSize"], out int result);
                return result;
            }
        }
    }
}
