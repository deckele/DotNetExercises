using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public class HumanPlayer : IPlayer
    {
        public HumanPlayer()
        {
            
        }
        public void Roll(Dice dice)
        {
            throw new NotImplementedException();
        }

        public Move ChooseMove(BoardPosition boardPosition, List<Move> legalMoves)
        {
            throw new NotImplementedException();
        }
    }
}
