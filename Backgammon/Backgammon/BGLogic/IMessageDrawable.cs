using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public interface IMessageDrawable
    {
        void Display(Logic logic, BoardPosition boardPosition, Dice dice, CheckerColor currentPlayer);
        bool DisplayWinner(CheckerColor currentPlayer);
    }
}
