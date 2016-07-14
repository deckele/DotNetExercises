using BGConsoleGraphics;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    class Program
    {
        static void Main(string[] args)
        {
            IBoardDrawable guiBoard = new BoardGraphic();
            IDiceDrawable guiDice = new DiceGraphic();
            IUIDrawable humanPlayerInput = new UIGraphic();
            IPlayer redPlayer = new HumanPlayer(humanPlayerInput);
            IPlayer blackPlayer = new RandomCompPlayer();

            Game backgammon = new Game(guiBoard, guiDice, redPlayer, blackPlayer);
            backgammon.Run();
        }
    }
}
