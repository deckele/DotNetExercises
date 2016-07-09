using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backgammon;

namespace BGConsoleGraphics
{
    public class DiceGraphic
    {
        private readonly Dice dice = new Dice();

        public DiceGraphic()
        {
            dice.Roll();
        }
        public void Display()
        {
            Console.SetCursorPosition(0, 17);
            DisplayDie(dice.Die1Number);
            Console.SetCursorPosition(15, 17);
            DisplayDie(dice.Die2Number);
        }

        private void DisplayDie(int dieNumber)
        {
            if (BGRuls.Turn == Checker.CheckerColor.Red)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("+---+");
            switch (dieNumber)
            {
                case 1:
                    Console.WriteLine("|   |");
                    Console.WriteLine("| * |");
                    Console.WriteLine("|   |");
                    break;
                case 2:
                    Console.WriteLine("|*  |");
                    Console.WriteLine("|   |");
                    Console.WriteLine("|  *|");
                    break;
                case 3:
                    Console.WriteLine("|*  |");
                    Console.WriteLine("| * |");
                    Console.WriteLine("|  *|");
                    break;
                case 4:
                    Console.WriteLine("|* *|");
                    Console.WriteLine("|   |");
                    Console.WriteLine("|* *|");
                    break;
                case 5:
                    Console.WriteLine("|* *|");
                    Console.WriteLine("| * |");
                    Console.WriteLine("|* *|");
                    break;
                case 6:
                    Console.WriteLine("|* *|");
                    Console.WriteLine("|* *|");
                    Console.WriteLine("|* *|");
                    break;
                default:
                    Console.WriteLine("Error: invalid number for die");
                    break;
            }
            Console.WriteLine("+---+");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
