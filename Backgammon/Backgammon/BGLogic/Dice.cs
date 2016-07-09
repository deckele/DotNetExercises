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
            CurrentDiceColor = (DiceColor)BGRuls.Turn;
            RandomDieGen = new Random();
            Die1Number = RandomDieGen.Next(1, 7);
            Die2Number = RandomDieGen.Next(1, 7);
        }

        private Random RandomDieGen { get;}
        public DiceColor CurrentDiceColor { get; private set; }

        public int Die1Number { get; private set; }
        public int Die2Number { get; private set; }

        public bool IsDouble
        {
            get
            {
                if (Die1Number == Die2Number)
                {
                    return true;
                }
                return false;
            }
        }

        public Dice Roll()
        {
            Die1Number = RandomDieGen.Next(1, 7);
            Die2Number = RandomDieGen.Next(1, 7);
            return this;
        }
    }
}
