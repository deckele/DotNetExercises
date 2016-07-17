using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backgammon;

namespace BGLogic
{
    class Logic
    {
        public List<Move> ListPossibleMoves(BoardPosition boardPosition, Dice dice, Checker.CheckerColor currentPlayer)
        {
            return null;
        }

        public void ApplyMove(BoardPosition boardPosition, Move move, Checker.CheckerColor currentPlayer)
        {
            if (currentPlayer == Checker.CheckerColor.Red)
            {
                if ((move.PositionIndex + move.Distance) < 25)
                {
                    //If target stack is empty - just move there.
                    if (boardPosition.CountAtPosition(move.PositionIndex + move.Distance) == 0)
                    {
                        boardPosition.CurrentPosition[move.PositionIndex].Pop();
                        boardPosition.PushChecker(currentPlayer, move.PositionIndex + move.Distance);
                    }
                    //If target stack is friendly (same color) - move on top of stack.
                    else if (currentPlayer == boardPosition.CurrentPosition[move.PositionIndex + move.Distance].Peek().Color)
                    {
                        boardPosition.CurrentPosition[move.PositionIndex].Pop();
                        boardPosition.PushChecker(currentPlayer, move.PositionIndex + move.Distance);
                    }
                    //If target stack has only one enemy piece - eat it!
                    else if ((currentPlayer != boardPosition.CurrentPosition[move.PositionIndex + move.Distance].Peek().Color) &&
                             boardPosition.CurrentPosition[move.PositionIndex + move.Distance].Count == 1)
                    {
                        boardPosition.CurrentPosition[move.PositionIndex].Pop();
                        boardPosition.CurrentPosition[move.PositionIndex + move.Distance].Pop();
                        boardPosition.PushChecker(currentPlayer, move.PositionIndex + move.Distance);
                        boardPosition.PushChecker(Checker.CheckerColor.Black, 26);
                    }
                    //Can't move to position where there is more than 1 enemy pieces.
                    else
                    {
                        Console.WriteLine("Error: position taken!");
                    }
                }
                else if (((move.PositionIndex + move.Distance) >= 25) && boardPosition.RedIsInGoal())
                {
                    boardPosition.CurrentPosition[move.PositionIndex].Pop();
                    boardPosition.PushChecker(currentPlayer, 25);
                }
                else
                {
                    Console.WriteLine("Error: move out of bounds!");
                }
            }
            //Same with the black pieces, only reversed moving directions...
            else if (currentPlayer == Checker.CheckerColor.Black)
            {
                if ((move.PositionIndex - move.Distance) > 0)
                {
                    if (boardPosition.CountAtPosition(move.PositionIndex - move.Distance) == 0)
                    {
                        boardPosition.CurrentPosition[move.PositionIndex].Pop();
                        boardPosition.PushChecker(currentPlayer, move.PositionIndex - move.Distance);
                    }
                    else if (currentPlayer == boardPosition.CurrentPosition[move.PositionIndex - move.Distance].Peek().Color)
                    {
                        boardPosition.CurrentPosition[move.PositionIndex].Pop();
                        boardPosition.PushChecker(currentPlayer, move.PositionIndex - move.Distance);
                    }
                    else if ((currentPlayer != boardPosition.CurrentPosition[move.PositionIndex - move.Distance].Peek().Color) &&
                             boardPosition.CurrentPosition[move.PositionIndex - move.Distance].Count == 1)
                    {
                        boardPosition.CurrentPosition[move.PositionIndex].Pop();
                        boardPosition.CurrentPosition[move.PositionIndex - move.Distance].Pop();
                        boardPosition.PushChecker(currentPlayer, move.PositionIndex - move.Distance);
                        boardPosition.PushChecker(Checker.CheckerColor.Red, 27);
                    }
                    else
                    {
                        Console.WriteLine("Error: position taken!");
                    }
                }
                else if (((move.PositionIndex - move.Distance) <= 0) && boardPosition.BlackIsInGoal())
                {
                    boardPosition.CurrentPosition[move.PositionIndex].Pop();
                    boardPosition.PushChecker(currentPlayer, 0);
                }
                else
                {
                    Console.WriteLine("Error: move out of bounds!");
                }
            }
        }
    }
}
