using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public interface IMessageDrawable
    {
        void Display(object obj, StateChangedEventArgs args);
        void DisplayWinner(object obj, StateChangedEventArgs args);
        bool PlayAgainUserInput();
        Move ChooseMoveUserInput(List<int> diceNumbers, List<Move> legalMoves, CheckerColor currentPlayer);
    }
}
