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
        public class Die //Nested class Die in Dice. Die can be instantiated by itself, or as part of dice (a "die" pair).
        {
            public enum DieColor
            {
                Black,
                Red,
            }

            public Die(CheckerColor color, Random randomDieGen)
            {
                CurrentDieColor = (DieColor)color;
                DieNumber = randomDieGen.Next(1, 7);
            }

            public DieColor CurrentDieColor { get; private set; }
            public int DieNumber { get; private set; }
        }

        public Dice(CheckerColor color, Random randomDieGen)
        {
            CurrentDice = new List<Die>();
            CurrentDice.Add(new Die(color, randomDieGen));
            CurrentDice.Add(new Die(color, randomDieGen));

            if (IsDouble)
            {
                CurrentDice.Add(CurrentDice[0]);
                CurrentDice.Add(CurrentDice[0]);
            }

            CurrentDiceNumbers = new List<int>();
            foreach (var die in CurrentDice)
            {
                if (die != null)
                {
                    CurrentDiceNumbers.Add(die.DieNumber);
                }
            }
        }

        public List<Die> CurrentDice { get; private set; }
        public List<int> CurrentDiceNumbers { get; private set; }
        
        public bool IsDouble
        {
            get
            {
                if (CurrentDice[0].DieNumber == CurrentDice[1].DieNumber)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
