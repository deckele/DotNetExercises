using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public class Logic
    {
        public List<Move> ListPossibleMoves(BoardPosition boardPosition, Dice dice, Checker.CheckerColor currentPlayer)
        {
            var legalMovesList = new List<Move>();

            if (boardPosition.CurrentPlayerIsInJail(currentPlayer))
            {

            }

            for (int i = 1; i <= 24; i++)
            {
                if (boardPosition.CountAtPosition(i) > 0)
                {
                    if (boardPosition.ColorAtPosition(i) == currentPlayer)
                    {

                    }
                }
            }
            return legalMovesList;
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

        private enum MoveInteraction
        {
            Move,
            Eat,
            Out,
            Illegal
        }

        private MoveInteraction CheckMoveInteraction(BoardPosition boardPosition, Checker.CheckerColor currentPlayer, int targetIndex)
        {
            //If target input is inside board limits (1-24)
            if ((targetIndex >= 1) && (targetIndex <= 24))
            {
                if (boardPosition.CountAtPosition(targetIndex) != 0)
                {
                    //Unmatching colors:
                    if (currentPlayer != boardPosition.ColorAtPosition(targetIndex))
                    {
                        //If target stack has only one enemy piece - eat it!
                        if (boardPosition.CountAtPosition(targetIndex) == 1)
                        {
                            return MoveInteraction.Eat;
                        }
                        //Can't move to position where there is more than 1 enemy piece.
                        else if (boardPosition.CountAtPosition(targetIndex) > 1)
                        {
                            return MoveInteraction.Illegal;
                        }
                    }
                    //Matching colors:
                    //If target stack is friendly (same color) - move on top of stack.
                    else
                    {
                        return MoveInteraction.Move;
                    }
                }
                //If target stack is empty - just move there.
                else
                {
                    return MoveInteraction.Move;
                }
            }
            //if Target index is out of board limits
            else
            {
                if (boardPosition.CurrentPlayerIsInGoal(currentPlayer))
                {
                    return MoveInteraction.Out;
                }
            }
            return MoveInteraction.Illegal;
        }
    }
}
