﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backgammon;

namespace BGConsoleGraphics
{
    public class BoardGraphic : IBoardDrawable
    {
        public void Display(object obj, StateChangedEventArgs args)
        {
            Console.SetCursorPosition(0,0);
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("    Outer Board          Red's Home Board  ");
            Console.WriteLine("+13-14-15-16-17-18------19-20-21-22-23-24-+");
            for (int i = 0; i < 5; i++)
            {
                Console.Write("|");
                for (int j = 13; j <= 18; j++)
                {
                    CheckerStackDisplay(args.BoardPosition.CurrentPosition[j], i);
                }
                //Drawing center bar with Black's taken pieces if any are out
                Console.Write("|");
                if (args.BoardPosition.BlackIsInJail())
                {
                    CheckerStackDisplay(args.BoardPosition.CurrentPosition[25], i);
                }
                else
                {
                    Console.Write("   ");
                }
                Console.Write("|");
                for (int j = 19; j <= 24; j++)
                {
                    CheckerStackDisplay(args.BoardPosition.CurrentPosition[j], i);
                }
                Console.Write("|");
                //Drawing red pieces that are out of the game (in goal)
                CheckerStackDisplay(args.BoardPosition.CurrentPosition[26], i);
                Console.WriteLine();
            }
            Console.WriteLine("|                  |BAR|                  |");
            for (int i = 4; i >= 0; i--)
            {
                Console.Write("|");
                for (int j = 12; j >= 7; j--)
                {
                    CheckerStackDisplay(args.BoardPosition.CurrentPosition[j], i);
                }
                //Drawing center bar with red's taken pieces if any are out
                Console.Write("|");
                if (args.BoardPosition.RedIsInJail())
                {
                    CheckerStackDisplay(args.BoardPosition.CurrentPosition[0], i);
                }
                else
                {
                    Console.Write("   ");
                }
                Console.Write("|");
                for (int j = 6; j >= 1; j--)
                {
                    CheckerStackDisplay(args.BoardPosition.CurrentPosition[j], i);
                }
                Console.Write("|");
                //Drawing black pieces that are out of the game (in goal)
                CheckerStackDisplay(args.BoardPosition.CurrentPosition[27], i);
                Console.WriteLine();
            }
            Console.WriteLine("+12-11-10--9--8--7-------6--5--4--3--2--1-+");
            Console.WriteLine("    Outer Board         Black's Home Board ");

            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void CheckerStackDisplay(Stack<Checker> checkerStack, int row)
        {
            if (checkerStack.Count <= 5)
            {
                if (checkerStack.Count > row)
                {
                    Console.Write($" {checkerStack.Peek()} ");
                }
                else
                {
                    Console.Write("   ");
                }
            }
            else if (checkerStack.Count <= 10)
            {
                if (checkerStack.Count > row + 5)
                {
                    Console.Write($"{checkerStack.Peek()}{checkerStack.Peek()} ");
                }
                else
                {
                    Console.Write($" {checkerStack.Peek()} ");
                }
            }
            else if (checkerStack.Count <= 15)
            {
                if (checkerStack.Count > row + 10)
                {
                    Console.Write($"{checkerStack.Peek()}{checkerStack.Peek()}{checkerStack.Peek()}");
                }
                else
                {
                    Console.Write($" {checkerStack.Peek()}{checkerStack.Peek()}");
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
