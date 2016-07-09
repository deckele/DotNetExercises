using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BGConsoleGraphics;

namespace Backgammon
{
    public class Game
    {
        public void Run()
        {
            BoardGraphic board = new BoardGraphic();
            BGRuls rulsInfo = new BGRuls();
            Dice dice = new Dice(rulsInfo);
            DiceGraphic diceGraphic = new DiceGraphic(dice, rulsInfo);
        }
    }
}
