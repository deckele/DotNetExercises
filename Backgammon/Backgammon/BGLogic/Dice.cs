using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BGLogic;

namespace Backgammon
{
    public class Dice
    {
        private BGRuls ruleInfo = new BGRuls();

        public enum DiceColor
        {
            Black,
            Red
        }

        public Dice()
        {
            CurrentDiceColor = (DiceColor)ruleInfo.Turn;
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
            Die1Number.Next(1, 7);
            Die2Number.Next(1, 7);
            return this;
        }
    }
}
