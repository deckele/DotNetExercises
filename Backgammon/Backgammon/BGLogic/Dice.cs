using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backgammon
{
    public class Dice
    {
        private Die _die1;
        private Die _die2;

        public class Die //Nested class Die in Dice. Die can be instantiated by itself, or as part of dice (a "die" pair).
        {
            public enum DieColor
            {
                Black,
                Red,
            }

            public Die(Checker.CheckerColor color, Random randomDieGen)
            {
                CurrentDieColor = (DieColor)color;
                DieIsUsed = false;

                DieNumber = randomDieGen.Next(1, 7);
            }

            public DieColor CurrentDieColor { get; private set; }
            public bool DieIsUsed { get; private set; } // TODO Add "used" property to Die object

            public int DieNumber { get; private set; }
        }

        public Dice(Checker.CheckerColor color, Random randomDieGen)
        {
            _die1 = new Die(color, randomDieGen);
            _die2 = new Die(color, randomDieGen);
            Die1Number = _die1.DieNumber;
            Die2Number = _die2.DieNumber;

            if (IsDouble)
            {
                Die3Number = Die1Number;
                Die4Number = Die1Number;
            }
            else
            {
                Die3Number = -1;
                Die4Number = -1;
            }
        }

        public int Die1Number { get; private set; }
        public int Die2Number { get; private set; }
        public int Die3Number { get; private set; }
        public int Die4Number { get; private set; }
        
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
    }
}
