using System;

namespace Backgammon
{
    public enum CheckerColor
    {
        Black,
        Red,
        None
    }

    public class Checker
    {
        public Checker(CheckerColor checkerColor)
        {
            Color = checkerColor;
        }

        public CheckerColor Color { get; }

        public override string ToString()
        {
            if (Color == CheckerColor.Red)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "O";
            }
            else if (Color == CheckerColor.Black)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                return "O";
            }
            return " ";
        }
    }
}