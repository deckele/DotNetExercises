using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backgammon
{
    public class RandomCompPlayer : IPlayer
    {
        public RandomCompPlayer(Random randomMoveGen)
        {
            RandomMoveGen = randomMoveGen;
        }

        public Random RandomMoveGen { get; private set; }

        public Dice Roll(CheckerColor currentPlayer, Random randomDieGen)
        {
            return new Dice(currentPlayer, randomDieGen);
        }

        public Move ChooseMove(List<int> diceNumbers, List<Move> legalMoves, CheckerColor currentPlayer)
        {
            Thread.Sleep(2500);
            int userInput = RandomMoveGen.Next(0, legalMoves.Count);
            //removing used die number from list
            if (currentPlayer == CheckerColor.Red)
            {
                diceNumbers.Remove(legalMoves[userInput].Distance);
            }
            else if (currentPlayer == CheckerColor.Black)
            {
                diceNumbers.Remove((-1) * legalMoves[userInput].Distance);
            }

            return legalMoves[userInput];
        }
    }
}
