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
        public void Display(object obj, StateChangedEventArgs args)
        {
            //Clear previouse moves or messages.
            Console.SetCursorPosition(0, 22);
            for (int i = 0; i < 19; i++)
            {
                Console.WriteLine("                                   ");
            }

            var listPossibleMoves = args.Logic.ListPossibleMoves(args.BoardPosition, args.Dice, args.CheckerColor);
            int moveCounter = 1;

            Console.SetCursorPosition(0, 23);
            Console.WriteLine($"Current player: {args.CheckerColor.ToString()}");
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

        public void DisplayWinner(object obj, StateChangedEventArgs args)
        {
            //Clear previouse moves or messages.
            Console.SetCursorPosition(0, 22);
            for (int i = 0; i < 19; i++)
            {
                Console.WriteLine("                                   ");
            }

            Console.SetCursorPosition(0, 22);
            if (args.CheckerColor == CheckerColor.Red)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (args.CheckerColor == CheckerColor.Black)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }

            Console.WriteLine($"{args.CheckerColor} Wins!!! :)                        ");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public bool PlayAgainUserInput()
        {
            Console.SetCursorPosition(0, 23);
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

        public Move ChooseMoveUserInput(List<int> diceNumbers, List<Move> legalMoves, CheckerColor currentPlayer)
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
                    if (currentPlayer == CheckerColor.Red)
                    {
                        diceNumbers.Remove(legalMoves[userInput - 1].Distance);
                    }
                    else if (currentPlayer == CheckerColor.Black)
                    {
                        diceNumbers.Remove((-1) * legalMoves[userInput - 1].Distance);
                    }
                    return legalMoves[userInput - 1];
                }
                else
                {
                    Console.Write("Illegal Move. Please try again...");
                }
            }
            return legalMoves[0];
        }
    }
}
