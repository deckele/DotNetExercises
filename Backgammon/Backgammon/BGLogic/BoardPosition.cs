using System.Collections.Generic;

namespace Backgammon
{
    public class BoardPosition
    {
        public BoardPosition()
        {
            //Game pieces ("Checkers") are arranged in a list of stacks.
            //Stack number 0 and 25 are the goal zones for black and red respectively.
            //stack numbers 1-24 correspond with the 1-24 board positions.
            //stack numbers 26 and 27 represent the "out" position when piece is taken for black and red respectively;
            CurrentPosition = new List<Stack<Checker>>(28);
            for (int i = 0; i < 28; i++)
            {
                CurrentPosition.Add(new Stack<Checker>(15));
            }

            //Red checkers initial positions
            for (var i = 0; i < 2; i++)
            {
                PushChecker(Checker.CheckerColor.Red, 1);
            }
            for (var i = 0; i < 5; i++)
            {
                PushChecker(Checker.CheckerColor.Red, 12);
            }
            for (var i = 0; i < 3; i++)
            {
                PushChecker(Checker.CheckerColor.Red, 17);
            }
            for (var i = 0; i < 5; i++)
            {
                PushChecker(Checker.CheckerColor.Red, 19);
            }
            //Black checkers initial positions
            for (var i = 0; i < 2; i++)
            {
                PushChecker(Checker.CheckerColor.Black, 24);
            }
            for (var i = 0; i < 5; i++)
            {
                PushChecker(Checker.CheckerColor.Black, 13);
            }
            for (var i = 0; i < 3; i++)
            {
                PushChecker(Checker.CheckerColor.Black, 8);
            }
            for (var i = 0; i < 5; i++)
            {
                PushChecker(Checker.CheckerColor.Black, 6);
            }

        }

        public List<Stack<Checker>> CurrentPosition {get; private set; }

        public Checker.CheckerColor ColorAtPosition(int i)
        {
            if (CountAtPosition(i) == 0)
            {
                return Checker.CheckerColor.None;
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
        public void PushChecker(Checker.CheckerColor color, int positionIndex)
        {
            CurrentPosition[positionIndex].Push(new Checker(color, positionIndex));
        }

        public bool RedIsOut()
        {
            return CountAtPosition(27) != 0;
        }
        public bool RedIsInGoal()
        {
            int redCounter = 0;
            for (int i = 19; i < 26; i++)
            {
                if (ColorAtPosition(i)==Checker.CheckerColor.Red)
                {
                    redCounter += CountAtPosition(i);
                }
            }
            return redCounter == 15;
        }
        public bool RedIsWin()
        {
            return CountAtPosition(25) == 15;
        }

        public bool BlackIsOut()
        {
            return CountAtPosition(27) != 0;
        }
        public bool BlackIsInGoal()
        {
            int blackCounter = 0;
            for (int i = 0; i < 7; i++)
            {
                if (ColorAtPosition(i) == Checker.CheckerColor.Black)
                {
                    blackCounter += CountAtPosition(i);
                }
            }
            return blackCounter == 15;
        }
        public bool BlackIsWin()
        {
            return CountAtPosition(0) == 15;
        }
    }
}