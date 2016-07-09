using System;

namespace Backgammon
{
    public class Checker
    {
        public enum CheckerColor
        {
            Black,
            Red
        }

        public CheckerColor Color {get; set;}

        public Checker(CheckerColor checkerColor)
        {
            Color = checkerColor;
        }

        public override string ToString()
        {
            if (Color == CheckerColor.Red)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }
            return "O";

        }
    }
}