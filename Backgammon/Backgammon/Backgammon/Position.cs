using System.Collections.Generic;

namespace Backgammon
{
    public class Position
    {
        public Position()
        {
            CurrentPosition = new List<Stack<Checker>>(27);
            for (int i = 0; i < 27; i++)
            {
                CurrentPosition.Add(new Stack<Checker>(15));
            }

            //Red checkers initial positions
            for (var i = 0; i < 2; i++)
            {
                CurrentPosition[1].Push(new Checker(Checker.CheckerColor.Red));
            }
            for (var i = 0; i < 5; i++)
            {
                CurrentPosition[12].Push(new Checker(Checker.CheckerColor.Red));
            }
            for (var i = 0; i < 3; i++)
            {
                CurrentPosition[17].Push(new Checker(Checker.CheckerColor.Red));
            }
            for (var i = 0; i < 5; i++)
            {
                CurrentPosition[19].Push(new Checker(Checker.CheckerColor.Red));
            }
            //Black checkers initial positions
            for (var i = 0; i < 2; i++)
            {
                CurrentPosition[24].Push(new Checker(Checker.CheckerColor.Black));
            }
            for (var i = 0; i < 5; i++)
            {
                CurrentPosition[13].Push(new Checker(Checker.CheckerColor.Black));
            }
            for (var i = 0; i < 3; i++)
            {
                CurrentPosition[8].Push(new Checker(Checker.CheckerColor.Black));
            }
            for (var i = 0; i < 5; i++)
            {
                CurrentPosition[6].Push(new Checker(Checker.CheckerColor.Black));
            }

        }

        public List<Stack<Checker>> CurrentPosition {get; private set; }

        public bool RedIsOut()
        {
            return CurrentPosition[27] != null;
        }
        public bool RedIsInGoal()
        {
            int redCounter = 0;
            for (int i = 19; i < 26; i++)
            {
                if (CurrentPosition[i] != null)
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
            return CurrentPosition[26] != null;
        }
        public bool BlackIsInGoal()
        {
            int blackCounter = 0;
            for (int i = 0; i < 7; i++)
            {
                if (CurrentPosition[i] != null)
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

    }
}