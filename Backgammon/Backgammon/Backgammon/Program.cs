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
            var playAgain = true;

            IBoardDrawable guiBoard = new BoardGraphic();
            IDiceDrawable guiDice = new DiceGraphic();
            IMessageDrawable guiMessageArea = new MessageAreaGraphic();

            while (playAgain)
            {
                IPlayer redPlayer = new HumanPlayer();
                IPlayer blackPlayer = new RandomCompPlayer(randomNumberGen);

                Game backgammon = new Game(redPlayer, blackPlayer, randomNumberGen);

                //Subscribing all graphic functions to game event StateChanged and game event GameEnded.
                backgammon.StateChanged += guiBoard.Display;
                backgammon.StateChanged += guiDice.Display;
                backgammon.StateChanged += guiMessageArea.Display;
                backgammon.GameEnded += guiBoard.Display;
                backgammon.GameEnded += guiMessageArea.DisplayWinner;
                //Subscribing to other return type delegates for getting user input.
                backgammon.PlayAgainUserInput += guiMessageArea.PlayAgainUserInput;
                backgammon.MoveChoiceUserInput += guiMessageArea.ChooseMoveUserInput;

                backgammon.Run();
                playAgain = backgammon.PlayAgainCheck();
            }
        }
    }
}
