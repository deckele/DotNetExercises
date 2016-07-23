using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public interface IDiceDrawable
    {
        void Display(Dice dice, CheckerColor color);
    }
}
