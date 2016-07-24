using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public class HumanPlayer : IPlayer
    {
        public Dice Roll(CheckerColor currentPlayer, Random randomDieGen)
        {
            return new Dice(currentPlayer, randomDieGen);
        }

        public Move ChooseMove(List<int> diceNumbers, List<Move> legalMoves, CheckerColor currentPlayer, Game backgammon)
        {
            return backgammon.MoveChoiceUserInput(diceNumbers, legalMoves, currentPlayer);
        }
    }
}
