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

            //Gets legal moves if player is in Jail.
            if (boardPosition.CurrentPlayerIsInJail(currentPlayer))
            {
                foreach (var dieNumber in dice.CurrentDiceNumbers)
                {
                    if (currentPlayer == Checker.CheckerColor.Red)
                    {
                        if (CheckMoveInteraction(boardPosition, currentPlayer, dieNumber) !=
                            MoveInteraction.Illegal)
                        {
                            legalMovesList.Add(new Move(27, dieNumber,
                                CheckMoveInteraction(boardPosition, currentPlayer, dieNumber)));
                        }
                    }
                    if (currentPlayer == Checker.CheckerColor.Black)
                    {
                        if (CheckMoveInteraction(boardPosition, currentPlayer, 25- dieNumber) !=
                            MoveInteraction.Illegal)
                        {
                            legalMovesList.Add(new Move(26, dieNumber,
                                CheckMoveInteraction(boardPosition, currentPlayer, 25- dieNumber)));
                        }
                    }
                }
            }

            for (int i = 1; i <= 24; i++)
            {
                if (boardPosition.CountAtPosition(i) > 0)
                {
                    if (boardPosition.ColorAtPosition(i) == currentPlayer)
                    {
                        foreach (var dieNumber in dice.CurrentDiceNumbers)
                        {
                            if (currentPlayer == Checker.CheckerColor.Red)
                            {
                                if (CheckMoveInteraction(boardPosition, currentPlayer, i + dieNumber) !=
                                    MoveInteraction.Illegal)
                                {
                                    legalMovesList.Add(new Move(i, dieNumber,
                                        CheckMoveInteraction(boardPosition, currentPlayer, i + dieNumber)));
                                }
                            }
                            if (currentPlayer == Checker.CheckerColor.Black)
                            {
                                if (CheckMoveInteraction(boardPosition, currentPlayer, i - dieNumber) !=
                                    MoveInteraction.Illegal)
                                {
                                    legalMovesList.Add(new Move(i, dieNumber,
                                        CheckMoveInteraction(boardPosition, currentPlayer, i - dieNumber)));
                                }
                            }
                        }
                    }
                }
            }
            return legalMovesList;
        }

        public void ApplyMove(BoardPosition boardPosition, Move move, Checker.CheckerColor currentPlayer)
        {
            switch (move.MoveInteraction)
            {
                case MoveInteraction.Move:
                {
                    if (currentPlayer == Checker.CheckerColor.Red)
                    {
                        boardPosition.CurrentPosition[move.PositionIndex].Pop();
                        boardPosition.PushChecker(currentPlayer, move.PositionIndex + move.Distance);
                    }
                    if (currentPlayer == Checker.CheckerColor.Black)
                    {
                        boardPosition.CurrentPosition[move.PositionIndex].Pop();
                        boardPosition.PushChecker(currentPlayer, move.PositionIndex - move.Distance);
                    }
                    break;
                }
                case MoveInteraction.Out:
                {
                    if (currentPlayer == Checker.CheckerColor.Red)
                    {
                        boardPosition.CurrentPosition[move.PositionIndex].Pop();
                        boardPosition.PushChecker(currentPlayer, 25);
                    }
                    if (currentPlayer == Checker.CheckerColor.Black)
                    {
                        boardPosition.CurrentPosition[move.PositionIndex].Pop();
                        boardPosition.PushChecker(currentPlayer, 0);
                    }
                    break;
                }
                case MoveInteraction.Eat:
                {
                    if (currentPlayer == Checker.CheckerColor.Red)
                    {
                        boardPosition.CurrentPosition[move.PositionIndex].Pop();
                        boardPosition.CurrentPosition[move.PositionIndex + move.Distance].Pop();
                        boardPosition.PushChecker(currentPlayer, move.PositionIndex + move.Distance);
                        boardPosition.PushChecker(Checker.CheckerColor.Black, 26);
                    }
                    if (currentPlayer == Checker.CheckerColor.Black)
                    {
                        boardPosition.CurrentPosition[move.PositionIndex].Pop();
                        boardPosition.CurrentPosition[move.PositionIndex - move.Distance].Pop();
                        boardPosition.PushChecker(currentPlayer, move.PositionIndex - move.Distance);
                        boardPosition.PushChecker(Checker.CheckerColor.Red, 27);
                    }
                    break;
                }
                case MoveInteraction.JailMove:
                {
                    if (currentPlayer == Checker.CheckerColor.Red)
                    {
                        boardPosition.CurrentPosition[move.PositionIndex].Pop();
                        boardPosition.PushChecker(currentPlayer, move.Distance);
                    }
                    if (currentPlayer == Checker.CheckerColor.Black)
                    {
                        boardPosition.CurrentPosition[move.PositionIndex].Pop();
                        boardPosition.PushChecker(currentPlayer, 25 - move.Distance);
                    }
                    break;
                }
                case MoveInteraction.JailEat:
                {
                    if (currentPlayer == Checker.CheckerColor.Red)
                    {
                        boardPosition.CurrentPosition[move.PositionIndex].Pop();
                        boardPosition.CurrentPosition[move.Distance].Pop();
                        boardPosition.PushChecker(currentPlayer, move.Distance);
                        boardPosition.PushChecker(Checker.CheckerColor.Black, 26);
                    }
                    if (currentPlayer == Checker.CheckerColor.Black)
                    {
                        boardPosition.CurrentPosition[move.PositionIndex].Pop();
                        boardPosition.CurrentPosition[25 - move.Distance].Pop();
                        boardPosition.PushChecker(currentPlayer, 25 - move.Distance);
                        boardPosition.PushChecker(Checker.CheckerColor.Red, 27);
                    }
                    break;
                }
            }
        }

        public enum MoveInteraction
        {
            Move,
            Eat,
            JailMove,
            JailEat,
            Out,
            Illegal
        }

        public MoveInteraction CheckMoveInteraction(BoardPosition boardPosition, Checker.CheckerColor currentPlayer, int targetIndex)
        {
            //If player is in jail.
            if (boardPosition.CurrentPlayerIsInJail(currentPlayer))
            {
                if (boardPosition.CountAtPosition(targetIndex) != 0)
                {
                    //Unmatching colors:
                    if (currentPlayer != boardPosition.ColorAtPosition(targetIndex))
                    {
                        //If target stack has only one enemy piece - eat it!
                        if (boardPosition.CountAtPosition(targetIndex) == 1)
                        {
                            return MoveInteraction.JailEat;
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
                        return MoveInteraction.JailMove;
                    }
                }
                //If target stack is empty - just move there.
                else
                {
                    return MoveInteraction.JailMove;
                }
            }

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
