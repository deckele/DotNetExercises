using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backgammon;

namespace BGConsoleGraphics
{
    public class DiceGraphic : IDiceDrawable
    {
        public void Display(Dice dice, Checker.CheckerColor color)
        {
            Console.SetCursorPosition(0, 16);
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("                                                  ");
            }

            for (int i = dice.CurrentDiceNumbers.Count; i > 0; i--)
            {
                Console.SetCursorPosition(0, 16);
                DisplayDie(dice.CurrentDiceNumbers[i - 1], dice, color);
                Console.MoveBufferArea(0, 16, 9, 5, (i - 1) * 12, 16);
            }
            //Console.SetCursorPosition(0, 16);
            //DisplayDie(dice.CurrentDiceNumbers[0], dice, color);
            //Console.MoveBufferArea(0,16,9,5,12,16);
            //Console.SetCursorPosition(0, 16);
            //DisplayDie(dice.CurrentDiceNumbers[1], dice, color);
        }

        private void DisplayDie(int dieNumber, Dice dice, Checker.CheckerColor color)
        {
            if (color == Checker.CheckerColor.Red)
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

            if (dice.IsDouble && dice.CurrentDice[0].DieNumber == 1)
            {
                Console.WriteLine("   Snake Eyes!");
            }
            else if (dice.IsDouble)
            {
                Console.WriteLine("   Lucky Double!");
            }
            else if ((dice.CurrentDice[0].DieNumber == 5 && dice.CurrentDice[1].DieNumber == 6) || 
                (dice.CurrentDice[0].DieNumber == 6 && dice.CurrentDice[1].DieNumber == 5))
            {
                Console.WriteLine("   Shesh Besh!");
            }
        }
    }
}
