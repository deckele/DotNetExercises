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
            Position position = new Position();
            BoardGraphic board = new BoardGraphic(position);
            BGRuls rulsInfo = new BGRuls();
            Dice dice = new Dice(rulsInfo);
            DiceGraphic diceGraphic = new DiceGraphic(dice, rulsInfo);
            position.CurrentPosition[1].Peek().Move(position, rulsInfo, 1);
            position.CurrentPosition[6].Peek().Move(position, rulsInfo, 4);
            board.Display(position);
        }
    }
}
