using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public class HumanPlayer : IPlayer
    {
        public Dice Roll(Checker.CheckerColor currentPlayer, Random randomDieGen)
        {
            return new Dice(currentPlayer, randomDieGen);
        }

        public Move ChooseMove(List<int> diceNumbers, List<Move> legalMoves, Checker.CheckerColor currentPlayer)
        {
            int userInput = 0;
            bool checkUserInput = false;

            //Checking whether user input is valid.
            while (!(checkUserInput && (userInput > 0) && (userInput <= legalMoves.Count)))
            {
                Console.SetCursorPosition(0, 22);

                checkUserInput = int.TryParse(Console.ReadLine(), out userInput);
                if (checkUserInput && (userInput > 0) && (userInput <= legalMoves.Count))
                {
                    //removing used die number from list
                    if (currentPlayer == Checker.CheckerColor.Red)
                    {
                        diceNumbers.Remove(legalMoves[userInput - 1].Distance);
                    }
                    else if (currentPlayer == Checker.CheckerColor.Black)
                    {
                        diceNumbers.Remove((-1) * legalMoves[userInput -1 ].Distance);
                    }
                    return legalMoves[userInput - 1];
                }
                else
                {
                    Console.Write("Illegal Move. Please try again...");
                }
            }
            throw new Exception("Loop Error: This shouldn't have happened...");
        }
    }
}
