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
        public DiceGraphic()
        {
            Display();
        }

        public void Display()
        {
            Console.SetCursorPosition(0, 16);
            DisplayDie(Dice.Die1Number);
            Console.MoveBufferArea(0,16,9,5,12,16);
            Console.SetCursorPosition(0, 16);
            DisplayDie(Dice.Die2Number);
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
            Console.WriteLine("+-------+");
            switch (dieNumber)
            {
                case 1:
                    Console.WriteLine("|       |");
                    Console.WriteLine("|   *   |");
                    Console.WriteLine("|       |");
                    break;
                case 2:
                    Console.WriteLine("| *     |");
                    Console.WriteLine("|       |");
                    Console.WriteLine("|     * |");
                    break;
                case 3:
                    Console.WriteLine("| *     |");
                    Console.WriteLine("|   *   |");
                    Console.WriteLine("|     * |");
                    break;
                case 4:
                    Console.WriteLine("| *   * |");
                    Console.WriteLine("|       |");
                    Console.WriteLine("| *   * |");
                    break;
                case 5:
                    Console.WriteLine("| *   * |");
                    Console.WriteLine("|   *   |");
                    Console.WriteLine("| *   * |");
                    break;
                case 6:
                    Console.WriteLine("| *   * |");
                    Console.WriteLine("| *   * |");
                    Console.WriteLine("| *   * |");
                    break;
                default:
                    Console.WriteLine("Error: invalid number for die");
                    break;
            }
            Console.WriteLine("+-------+");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;

            if (Dice.IsDouble)
            {
                Console.WriteLine("   Snake Eyes!");
            }
        }
    }
}
