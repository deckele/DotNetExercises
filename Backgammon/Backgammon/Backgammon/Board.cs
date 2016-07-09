using System;
using System.Collections.Generic;

namespace Backgammon
{
    public class Board
    {
        private Position position = new Position();

        public Board()
        {
            Display();
        }

        public void Display()
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("    Outer Board          Red's Home Board  ");
            Console.WriteLine("+13-14-15-16-17-18------19-20-21-22-23-24-+");
            for(int i = 0; i<5; i++)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("|");
                for (int j = 13; j<=18; j++)
                {
                    if (position.CurrentPosition[j].Count <= 5)
                    {
                        if (position.CurrentPosition[j].Count > i)
                        {
                            Console.Write($" {position.CurrentPosition[j].Peek().ToString()} ");
                        }
                        else
                        {
                            Console.Write("   ");
                        }
                    }
                    else if (position.CurrentPosition[j].Count <= 10)
                    {
                        if (position.CurrentPosition[j].Count > i + 5)
                        {
                            Console.Write($"{position.CurrentPosition[j].Peek().ToString()}{position.CurrentPosition[j].Peek().ToString()} ");
                        }
                        else
                        {
                            Console.Write($" {position.CurrentPosition[j].Peek().ToString()} ");
                        }
                    }
                    else if (position.CurrentPosition[j].Count <= 15)
                    {
                        if (position.CurrentPosition[j].Count > i + 5)
                        {
                            Console.Write($"{position.CurrentPosition[j].Peek().ToString()}{position.CurrentPosition[j].Peek().ToString()}{position.CurrentPosition[j].Peek().ToString()}");
                        }
                        else
                        {
                            Console.Write($"{position.CurrentPosition[j].Peek().ToString()}{position.CurrentPosition[j].Peek().ToString()} ");
                        }
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("|   |");
                for (int j = 19; j <= 24; j++)
                {
                    if (position.CurrentPosition[j].Count <= 5)
                    {
                        if (position.CurrentPosition[j].Count > i)
                        {
                            Console.Write($" {position.CurrentPosition[j].Peek().ToString()} ");
                        }
                        else
                        {
                            Console.Write("   ");
                        }
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("|                  |BAR|                  |");

            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void CheckerStackDisplay(Stack<Checker> checkerStack, int row)
        {
            if (checkerStack.Count <= 5)
            {
                if (checkerStack.Count > row)
                {
                    Console.Write($" {checkerStack.Peek().ToString()} ");
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
                    Console.Write($"{checkerStack.Peek().ToString()}{checkerStack.Peek().ToString()} ");
                }
                else
                {
                    Console.Write($" {checkerStack.Peek().ToString()} ");
                }
            }
            else if (checkerStack.Count <= 15)
            {
                if (checkerStack.Count > row + 5)
                {
                    Console.Write($"{checkerStack.Peek().ToString()}{checkerStack.Peek().ToString()}{checkerStack.Peek().ToString()}");
                }
                else
                {
                    Console.Write($"{checkerStack.Peek().ToString()}{checkerStack.Peek().ToString()} ");
                }
            }
            else
            {
                Console.Write("   ");
            }
        }
    }
}