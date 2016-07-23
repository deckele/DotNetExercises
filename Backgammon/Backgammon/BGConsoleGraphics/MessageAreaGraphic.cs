using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Backgammon;

namespace BGConsoleGraphics
{
    public class MessageAreaGraphic : IMessageDrawable
    {
        public void Display(Logic logic, BoardPosition boardPosition, Dice dice, CheckerColor currentPlayer)
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

            if (listPossibleMoves.Count != 0)
            {
                foreach (var move in listPossibleMoves)
                {
                    Console.Write($"{moveCounter++,2}) ");
                    Console.WriteLine(move);
                }
            }
            else
            {
                Console.Write("No Legal Moves!");
                Thread.Sleep(4000);
            }
        }

        public bool DisplayWinner(CheckerColor currentPlayer)
        {
            Console.SetCursorPosition(0, 22);
            Console.WriteLine($"{currentPlayer} Wins!!! :)                        ");
            Console.WriteLine("Play again?                                        ");
            Console.WriteLine("choose: y/n                                        ");

            bool checkUserInput = false;

            while (!checkUserInput)
            {
                Console.SetCursorPosition(0, 21);
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "y":
                    {
                        checkUserInput = true;
                        return true;
                    }
                    case "n":
                    {
                        checkUserInput = true;
                        return false;
                    }
                    default:
                    {
                        Console.WriteLine("Invalid input. Please choose y/n"              );
                        break;
                    }
                }
            }
            return true;
        }
    }
}
