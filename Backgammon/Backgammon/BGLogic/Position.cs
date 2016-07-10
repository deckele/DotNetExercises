using System.Collections.Generic;

namespace Backgammon
{
    public class Position
    {
        public Position()
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

        //Method creates new checker in new position using the Stack.Push method.
        public void PushChecker(Checker.CheckerColor color, int positionIndex)
        {
            CurrentPosition[positionIndex].Push(new Checker(color, positionIndex));
        }

        public bool RedIsOut()
        {
            return CurrentPosition[27].Count != 0;
        }
        public bool RedIsInGoal()
        {
            int redCounter = 0;
            for (int i = 19; i < 26; i++)
            {
                if (CurrentPosition[i].Count != 0)
                {
                    if (CurrentPosition[i].Peek().Color==Checker.CheckerColor.Red)
                    {
                        redCounter += CurrentPosition[i].Count;
                    }
                }
            }
            return redCounter == 15;
        }
        public bool RedIsWin()
        {
            return CurrentPosition[25].Count == 15;
        }

        public bool BlackIsOut()
        {
            return CurrentPosition[26].Count != 0;
        }
        public bool BlackIsInGoal()
        {
            int blackCounter = 0;
            for (int i = 0; i < 7; i++)
            {
                if (CurrentPosition[i].Count != 0)
                {
                    if (CurrentPosition[i].Peek().Color == Checker.CheckerColor.Black)
                    {
                        blackCounter += CurrentPosition[i].Count;
                    }
                }
            }
            return blackCounter == 15;
        }
        public bool BlackIsWin()
        {
            return CurrentPosition[0].Count == 15;
        }

        public bool DestinationIsEmpty(int positionIndex)
        {
            return CurrentPosition[positionIndex].Count == 0;
        }

    }
}