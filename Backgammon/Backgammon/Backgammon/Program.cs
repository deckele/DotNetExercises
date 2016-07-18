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
            var randomNumberGen = new Random();
            bool PlayAgain = true;

            //Creating all objects with upcasting so Game class will have limited access (better encapsulation).
            IBoardDrawable guiBoard = new BoardGraphic();
            IDiceDrawable guiDice = new DiceGraphic();
            IMessageDrawable guiMessageArea = new MessageAreaGraphic();

            while (PlayAgain)
            {
                IPlayer redPlayer = new HumanPlayer();
                IPlayer blackPlayer = new RandomCompPlayer(randomNumberGen);

                Game backgammon = new Game(guiBoard, guiDice, guiMessageArea, redPlayer, blackPlayer, randomNumberGen);
                backgammon.Run();
                PlayAgain = backgammon.EndGame();
            }
        }
    }
}
