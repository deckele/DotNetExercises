using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backgammon;

namespace BGConsoleGraphics
{
    public class MessageAreaGraphic : IMessageDrawable
    {
        public void Display(Logic logic, BoardPosition boardPosition, Dice dice, Checker.CheckerColor currentPlayer)
        {
            //Clear previouse moves or messages.
            Console.SetCursorPosition(0, 22);
            for (int i = 0; i < 19; i++)
            {
                Console.WriteLine("                                   ");
            }

            var listPossibleMoves = logic.ListPossibleMoves(boardPosition, dice, currentPlayer);
            int moveCounter = 1;

            Console.SetCursorPosition(0, 23);
            Console.WriteLine($"Current player: {currentPlayer.ToString()}");
            Console.WriteLine("Choose your move:");
            Console.WriteLine();
            foreach (var move in listPossibleMoves)
            {
                Console.Write($"({moveCounter++})");
                Console.WriteLine(move);
            }
        }
    }
}
