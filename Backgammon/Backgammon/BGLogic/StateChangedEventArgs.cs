using System;

namespace Backgammon
{
    public class StateChangedEventArgs : EventArgs
    {
        public StateChangedEventArgs(BoardPosition boardPosition, Dice dice, CheckerColor checkerColor, Logic logic)
        {
            BoardPosition = boardPosition;
            Dice = dice;
            CheckerColor = checkerColor;
            Logic = logic;
        }

        public BoardPosition BoardPosition { get; }
        public Dice Dice { get; }
        public CheckerColor CheckerColor { get; }
        public Logic Logic { get; }
    }
}