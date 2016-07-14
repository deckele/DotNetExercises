using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backgammon;

namespace Backgammon
{
    public interface IPlayer
    {
        void Roll(Dice dice);
        Move ChooseMove(BoardPosition boardPosition, List<Move> legalMoves);
    }
}
