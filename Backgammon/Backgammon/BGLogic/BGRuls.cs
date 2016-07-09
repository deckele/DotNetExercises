using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public class BGRuls
    {
        public BGRuls()
        {
            Turn = Checker.CheckerColor.Red;
        }

        public static Checker.CheckerColor Turn { get; private set; }
    }
}
