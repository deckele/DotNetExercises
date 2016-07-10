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

        public Checker(CheckerColor checkerColor, int positionIndex)
        {
            Color = checkerColor;
            PositionIndex = positionIndex;
        }

        public CheckerColor Color { get; }
        public int PositionIndex { get; private set; }

        public void Move(Position position, BGRuls rulsInfo, int diceNumber)
        {
            if (Color == CheckerColor.Red)
            {
                if ((PositionIndex + diceNumber) < 25)
                {
                    if (position.DestinationIsEmpty(PositionIndex + diceNumber))
                    {
                        position.CurrentPosition[PositionIndex].Pop();
                        position.PushChecker(Color, PositionIndex + diceNumber);
                    }
                    else if (Color == position.CurrentPosition[PositionIndex + diceNumber].Peek().Color)
                    {
                        position.CurrentPosition[PositionIndex].Pop();
                        position.PushChecker(Color, PositionIndex + diceNumber);
                    }
                    else if ((Color != position.CurrentPosition[PositionIndex + diceNumber].Peek().Color) &&
                             position.CurrentPosition[PositionIndex + diceNumber].Count == 1)
                    {
                        position.CurrentPosition[PositionIndex].Pop();
                        position.CurrentPosition[PositionIndex + diceNumber].Pop();
                        position.PushChecker(Color, PositionIndex + diceNumber);
                        position.PushChecker(CheckerColor.Black, 26);
                    }
                    else
                    {
                        Console.WriteLine("Error: position taken!");
                    }
                }
                else if (((PositionIndex + diceNumber) >= 25) && position.RedIsInGoal())
                {
                    position.CurrentPosition[PositionIndex].Pop();
                    position.PushChecker(Color, 25);
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
                    if (position.DestinationIsEmpty(PositionIndex - diceNumber))
                    {
                        position.CurrentPosition[PositionIndex].Pop();
                        position.PushChecker(Color, PositionIndex - diceNumber);
                    }
                    else if (Color == position.CurrentPosition[PositionIndex - diceNumber].Peek().Color)
                    {
                        position.CurrentPosition[PositionIndex].Pop();
                        position.PushChecker(Color, PositionIndex - diceNumber);
                    }
                    else if ((Color != position.CurrentPosition[PositionIndex - diceNumber].Peek().Color) &&
                             position.CurrentPosition[PositionIndex - diceNumber].Count == 1)
                    {
                        position.CurrentPosition[PositionIndex].Pop();
                        position.CurrentPosition[PositionIndex - diceNumber].Pop();
                        position.PushChecker(Color, PositionIndex - diceNumber);
                        position.PushChecker(CheckerColor.Red, 27);
                    }
                    else
                    {
                        Console.WriteLine("Error: position taken!");
                    }
                }
                else if (((PositionIndex - diceNumber) <= 0) && position.BlackIsInGoal())
                {
                    position.CurrentPosition[PositionIndex].Pop();
                    position.PushChecker(Color, 0);
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