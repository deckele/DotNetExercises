﻿using System;

namespace Backgammon
{
    public class Checker
    {
        public enum CheckerColor
        {
            Black,
            Red,
            None
        }

        public Checker(CheckerColor checkerColor, int positionIndex)
        {
            Color = checkerColor;
            PositionIndex = positionIndex;
        }

        public CheckerColor Color { get; }
        public int PositionIndex { get; private set; }

        public void Move(BoardPosition boardPosition, int diceNumber)
        {
            if (Color == CheckerColor.Red)
            {
                if ((PositionIndex + diceNumber) < 25)
                {
                    if (boardPosition.CountAtPosition(PositionIndex + diceNumber)==0)
                    {
                        boardPosition.CurrentPosition[PositionIndex].Pop();
                        boardPosition.PushChecker(Color, PositionIndex + diceNumber);
                    }
                    else if (Color == boardPosition.CurrentPosition[PositionIndex + diceNumber].Peek().Color)
                    {
                        boardPosition.CurrentPosition[PositionIndex].Pop();
                        boardPosition.PushChecker(Color, PositionIndex + diceNumber);
                    }
                    else if ((Color != boardPosition.CurrentPosition[PositionIndex + diceNumber].Peek().Color) &&
                             boardPosition.CurrentPosition[PositionIndex + diceNumber].Count == 1)
                    {
                        boardPosition.CurrentPosition[PositionIndex].Pop();
                        boardPosition.CurrentPosition[PositionIndex + diceNumber].Pop();
                        boardPosition.PushChecker(Color, PositionIndex + diceNumber);
                        boardPosition.PushChecker(CheckerColor.Black, 26);
                    }
                    else
                    {
                        Console.WriteLine("Error: position taken!");
                    }
                }
                else if (((PositionIndex + diceNumber) >= 25) && boardPosition.RedIsInGoal())
                {
                    boardPosition.CurrentPosition[PositionIndex].Pop();
                    boardPosition.PushChecker(Color, 25);
                }
                else
                {
                    Console.WriteLine("Error: move out of bounds!");
                }
            }
            else if (Color == CheckerColor.Black)
            {
                if ((PositionIndex - diceNumber) > 0)
                {
                    if (boardPosition.CountAtPosition(PositionIndex - diceNumber)==0)
                    {
                        boardPosition.CurrentPosition[PositionIndex].Pop();
                        boardPosition.PushChecker(Color, PositionIndex - diceNumber);
                    }
                    else if (Color == boardPosition.CurrentPosition[PositionIndex - diceNumber].Peek().Color)
                    {
                        boardPosition.CurrentPosition[PositionIndex].Pop();
                        boardPosition.PushChecker(Color, PositionIndex - diceNumber);
                    }
                    else if ((Color != boardPosition.CurrentPosition[PositionIndex - diceNumber].Peek().Color) &&
                             boardPosition.CurrentPosition[PositionIndex - diceNumber].Count == 1)
                    {
                        boardPosition.CurrentPosition[PositionIndex].Pop();
                        boardPosition.CurrentPosition[PositionIndex - diceNumber].Pop();
                        boardPosition.PushChecker(Color, PositionIndex - diceNumber);
                        boardPosition.PushChecker(CheckerColor.Red, 27);
                    }
                    else
                    {
                        Console.WriteLine("Error: position taken!");
                    }
                }
                else if (((PositionIndex - diceNumber) <= 0) && boardPosition.BlackIsInGoal())
                {
                    boardPosition.CurrentPosition[PositionIndex].Pop();
                    boardPosition.PushChecker(Color, 0);
                }
                else
                {
                    Console.WriteLine("Error: move out of bounds!");
                }
            }
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