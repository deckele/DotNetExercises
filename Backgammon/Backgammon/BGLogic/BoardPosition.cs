using System.Collections.Generic;

namespace Backgammon
{
    public class BoardPosition
    {
        public BoardPosition()
        {
            //Game pieces ("Checkers") are arranged in a list of stacks.
            //Stack number 26 and 27 are the goal zones for red and black respectively.
            //stack numbers 1-24 correspond with the 1-24 board positions.
            //stack numbers 0 and 25 represent the "out" position when piece is taken for red and black respectively;
            CurrentPosition = new List<Stack<Checker>>(28);
            for (int i = 0; i < 28; i++)
            {
                CurrentPosition.Add(new Stack<Checker>(15));
            }

            ////Red checkers initial positions
            for (var i = 0; i < 2; i++)
            {
                PushChecker(CheckerColor.Red, 1);
            }
            for (var i = 0; i < 5; i++)
            {
                PushChecker(CheckerColor.Red, 12);
            }
            for (var i = 0; i < 3; i++)
            {
                PushChecker(CheckerColor.Red, 17);
            }
            for (var i = 0; i < 5; i++)
            {
                PushChecker(CheckerColor.Red, 19);
            }
            //Black checkers initial positions
            for (var i = 0; i < 2; i++)
            {
                PushChecker(CheckerColor.Black, 24);
            }
            for (var i = 0; i < 5; i++)
            {
                PushChecker(CheckerColor.Black, 13);
            }
            for (var i = 0; i < 3; i++)
            {
                PushChecker(CheckerColor.Black, 8);
            }
            for (var i = 0; i < 5; i++)
            {
                PushChecker(CheckerColor.Black, 6);
            }
            
            //For testing red in winning position, enable this code and block other red positions:
            //for (var i = 0; i < 14; i++)
            //{
            //    PushChecker(CheckerColor.Red, 26);
            //}
            //PushChecker(CheckerColor.Red, 23);
        }

        public List<Stack<Checker>> CurrentPosition {get; private set; }

        public CheckerColor ColorAtPosition(int i)
        {
            if (CountAtPosition(i) == 0)
            {
                return CheckerColor.None;
            }
            else
            {
                return CurrentPosition[i].Peek().Color;
            }
        }

        public int CountAtPosition(int i)
        {
            return CurrentPosition[i].Count;
        }

        //Method creates new checker in new position using the Stack.Push method.
        public void PushChecker(CheckerColor color, int positionIndex)
        {
            CurrentPosition[positionIndex].Push(new Checker(color));
        }

        public bool RedIsInJail()
        {
            return CountAtPosition(0) != 0;
        }

        public bool RedIsInGoal()
        {
            int redCounter = CountAtPosition(26);
            for (int i = 19; i <= 24; i++)
            {
                if (CountAtPosition(i) != 0)
                {
                    if (ColorAtPosition(i) == CheckerColor.Red)
                    {
                        redCounter += CountAtPosition(i);
                    }
                }
            }
            return redCounter == 15;
        }

        public bool RedIsWin()
        {
            return CountAtPosition(26) == 15;
        }

        public bool BlackIsInJail()
        {
            return CountAtPosition(25) != 0;
        }

        public bool BlackIsInGoal()
        {
            int blackCounter = CountAtPosition(27);
            for (int i = 1; i <= 6; i++)
            {
                if (CountAtPosition(i) != 0)
                {
                    if (ColorAtPosition(i) == CheckerColor.Black)
                    {
                        blackCounter += CountAtPosition(i);
                    }
                }
            }
            return blackCounter == 15;
        }

        public bool BlackIsWin()
        {
            return CountAtPosition(27) == 15;
        }

        public bool CurrentPlayerIsInJail(CheckerColor currentPlayer)
        {
            if (currentPlayer == CheckerColor.Red)
            {
                return RedIsInJail();
            }
            else
            {
                return BlackIsInJail();
            }
        }

        public bool CurrentPlayerIsInGoal(CheckerColor currentPlayer)
        {
            if (currentPlayer == CheckerColor.Red)
            {
                return RedIsInGoal();
            }
            else
            {
                return BlackIsInGoal();
            }
        }

        public bool CheckWin()
        {
            return (RedIsWin() || BlackIsWin());
        }

        public bool IsBiggestInGoal(CheckerColor currentPlayer, BoardPosition boardPosition, int checkerindex)
        {
            if (CurrentPlayerIsInGoal(currentPlayer))
            {
                if (currentPlayer == CheckerColor.Red)
                {
                    for (int i = checkerindex - 1; i >= 19; i--)                        
                    {
                        if (boardPosition.CountAtPosition(i) != 0)
                        {
                            if (boardPosition.ColorAtPosition(i) == CheckerColor.Red)
                            {
                                return false;
                            }
                        }
                    }
                }
                else if (currentPlayer == CheckerColor.Black)
                {
                    for (int i = checkerindex + 1; i <= 6; i++)
                    {
                        if (boardPosition.CountAtPosition(i) != 0)
                        {
                            if (boardPosition.ColorAtPosition(i) == CheckerColor.Black)
                            {
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
            return false;
        }
    }
}