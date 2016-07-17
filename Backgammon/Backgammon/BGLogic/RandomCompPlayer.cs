using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public class RandomCompPlayer : IPlayer
    {
        public void Roll(Dice dice)
        {
            throw new NotImplementedException();
        }

        public Move ChooseMove(List<int> diceNumbers, List<Move> legalMoves)
        {
            throw new NotImplementedException();
        }
    }
}
