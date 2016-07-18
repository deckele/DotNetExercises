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

            //Creating a working dice number list that contains negative numbers if it's black's turn and ignores doubles. 
            var adjustedDiceNumbers = new List<int>();
            if (dice.IsDouble)
            {
                adjustedDiceNumbers.Add(dice.CurrentDiceNumbers[0]);
            }
            else
            {
                foreach (var diceNumber in dice.CurrentDiceNumbers)
                {
                    adjustedDiceNumbers.Add(diceNumber);
                }
            }
            if (currentPlayer == Checker.CheckerColor.Black)
            {
                if (dice.IsDouble)
                {
                    adjustedDiceNumbers[0] = (0 - adjustedDiceNumbers[0]);
                }
                else
                {
                    int counter = 0;
                    foreach (var diceNumber in dice.CurrentDiceNumbers)
                    {
                        adjustedDiceNumbers[counter++] = (0 - diceNumber);
                    }
                }
            }

            //Gets legal moves if player is in Jail.
            if (boardPosition.CurrentPlayerIsInJail(currentPlayer))
            {
                foreach (var dieNumber in adjustedDiceNumbers)
                {

                    if (currentPlayer == Checker.CheckerColor.Red)
                    {
                        if (CheckMoveInteraction(boardPosition, currentPlayer, dieNumber) != MoveInteraction.Illegal)
                        {
                            legalMovesList.Add(new Move(0, dieNumber,
                            CheckMoveInteraction(boardPosition, currentPlayer, dieNumber)));
                        }
                    }
                    else if (currentPlayer == Checker.CheckerColor.Black)
                    {
                        if (CheckMoveInteraction(boardPosition, currentPlayer, 25 + dieNumber) != MoveInteraction.Illegal)
                        {
                            legalMovesList.Add(new Move(25, dieNumber,
                            CheckMoveInteraction(boardPosition, currentPlayer, 25 + dieNumber)));
                        }
                    }
                }
            }
            //Gets legal moves if player is not in jail.
            else if (!boardPosition.CurrentPlayerIsInJail(currentPlayer))
            {
                for (int i = 1; i <= 24; i++)
                {
                    if (boardPosition.CountAtPosition(i) > 0)
                    {
                        if (boardPosition.ColorAtPosition(i) == currentPlayer)
                        {
                            foreach (var dieNumber in adjustedDiceNumbers)
                            {
                                //Gets legal moves if player is at goal and is hedding out of board bounds (going out).
                                if (CheckMoveInteraction(boardPosition, currentPlayer, i + dieNumber) == MoveInteraction.Out)
                                {
                                    if ((i + dieNumber == 0) || (i + dieNumber == 25))
                                    {
                                        legalMovesList.Add(new Move(i, dieNumber,
                                            CheckMoveInteraction(boardPosition, currentPlayer, i + dieNumber)));
                                    }
                                    else if (boardPosition.IsBiggestInGoal(currentPlayer,boardPosition, i))
                                    {
                                        if ((currentPlayer == Checker.CheckerColor.Red) && (dieNumber > (25 - i)))
                                        {
                                            legalMovesList.Add(new Move(i, dieNumber,
                                                CheckMoveInteraction(boardPosition, currentPlayer, i + dieNumber)));
                                        }
                                        else if ((currentPlayer == Checker.CheckerColor.Black) && ((-1) * dieNumber > i))
                                        {
                                            legalMovesList.Add(new Move(i, dieNumber,
                                                CheckMoveInteraction(boardPosition, currentPlayer, i + dieNumber)));
                                        }
                                    }
                                }
                                //All other legal moves (not jail and not going out).
                                else if ((CheckMoveInteraction(boardPosition, currentPlayer, i + dieNumber) != MoveInteraction.Illegal)
                                    && (CheckMoveInteraction(boardPosition, currentPlayer, i + dieNumber) != MoveInteraction.Out))
                                {
                                    legalMovesList.Add(new Move(i, dieNumber,
                                        CheckMoveInteraction(boardPosition, currentPlayer, i + dieNumber)));
                                }
                            }
                        }
                    }
                }
            }
            return legalMovesList;
        }

        //Gets a Move and applies it over the board.
        public void ApplyMove(BoardPosition boardPosition, Move move, Checker.CheckerColor currentPlayer)
        {
            switch (move.MoveInteraction)
            {
                case MoveInteraction.JailMove:
                case MoveInteraction.Move:
                {
                    boardPosition.CurrentPosition[move.PositionIndex].Pop();
                    boardPosition.PushChecker(currentPlayer, move.PositionIndex + move.Distance);                    
                    break;
                }
                case MoveInteraction.JailEat:
                case MoveInteraction.Eat:
                {
                    boardPosition.CurrentPosition[move.PositionIndex].Pop();
                    boardPosition.CurrentPosition[move.PositionIndex + move.Distance].Pop();
                    boardPosition.PushChecker(currentPlayer, move.PositionIndex + move.Distance);
                    if (currentPlayer == Checker.CheckerColor.Red)
                    {
                        boardPosition.PushChecker(Checker.CheckerColor.Black, 25);
                    }
                    else if (currentPlayer == Checker.CheckerColor.Black)
                    {
                        boardPosition.PushChecker(Checker.CheckerColor.Red, 0);
                    }
                    break;
                }
                case MoveInteraction.Out:
                {
                    boardPosition.CurrentPosition[move.PositionIndex].Pop();
                    if (currentPlayer == Checker.CheckerColor.Red)
                    {
                        boardPosition.PushChecker(Checker.CheckerColor.Red, 26);
                    }
                    else if (currentPlayer == Checker.CheckerColor.Black)
                    {
                        boardPosition.PushChecker(Checker.CheckerColor.Black, 27);
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
