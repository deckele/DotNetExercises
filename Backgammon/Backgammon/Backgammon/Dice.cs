using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backgammon
{
    public class Dice
    {
        public enum DiceColor
        {
            Black,
            Red
        }

        public Dice()
        {
            CurrentDiceColor = Logic.Turn;
            Die1Number = new Random();
            Die1Number.Next(1, 7);
            Die2Number = new Random();
            Die2Number.Next(1, 7);
        }

        public DiceColor CurrentDiceColor { get; private set; }
        public Random Die1Number { get; private set; }
        public Random Die2Number { get; private set; }

        public Dice Roll()
        {
            for (int i = 0; i < 4; i++)
            {
                Die1Number.Next(1, 7);
                Die2Number.Next(1, 7);
                Board.DisplayDice();
                Thread.Sleep(300);
            }
            return this;
        }
    }
}
