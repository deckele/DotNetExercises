﻿using System;
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
            DisplayDie(dice.CurrentDiceNumbers[0], dice, color);
            Console.MoveBufferArea(0,16,9,5,12,16);
            Console.SetCursorPosition(0, 16);
            DisplayDie(dice.CurrentDiceNumbers[1], dice, color);
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

            if (dice.IsDouble && dice.CurrentDiceNumbers[0] == 1)
            {
                Console.WriteLine("   Snake Eyes!");
            }
            else if (dice.IsDouble)
            {
                Console.WriteLine("   Lucky Double!");
            }
            else if ((dice.CurrentDiceNumbers[0] == 5 && dice.CurrentDiceNumbers[1] == 6) || 
                (dice.CurrentDiceNumbers[0] == 6 && dice.CurrentDiceNumbers[1] == 5))
            {
                Console.WriteLine("   Shesh Besh!");
            }
        }
    }
}
