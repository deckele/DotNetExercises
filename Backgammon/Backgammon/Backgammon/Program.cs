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
            //Creating all objects with upcasting so Game class will have limited access (better encapsulation).
            IBoardDrawable guiBoard = new BoardGraphic();
            IDiceDrawable guiDice = new DiceGraphic();
            IMessageDrawable guiMessageArea = new MessageAreaGraphic();
            IPlayer redPlayer = new HumanPlayer();
            IPlayer blackPlayer = new RandomCompPlayer();

            Game backgammon = new Game(guiBoard, guiDice, guiMessageArea, redPlayer, blackPlayer);
            backgammon.Run();
        }
    }
}
