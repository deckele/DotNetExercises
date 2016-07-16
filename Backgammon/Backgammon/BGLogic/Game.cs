using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public class Game
    {
        public Game(IBoardDrawable guiBoard, IDiceDrawable guiDice, IMessageDrawable guiMessageArea, 
            IPlayer redPlayer, IPlayer blackPlayer)
        {
            GUIBoard = guiBoard;
            GUIDice = guiDice;
            GUIMessageArea = guiMessageArea;
            RedPlayer = redPlayer;
            BlackPlayer = blackPlayer;

            Turn = Checker.CheckerColor.Red;
            RandomNumberGen = new Random();
        }

        public Checker.CheckerColor Turn { get; private set; }
        private Random RandomNumberGen { get; }

        private IBoardDrawable GUIBoard { get; }
        private IDiceDrawable GUIDice { get; }
        private IMessageDrawable GUIMessageArea { get; }
        private IPlayer RedPlayer { get; }
        private IPlayer BlackPlayer { get; }


        public void Run()
        {
            BoardPosition boardPosition = new BoardPosition();          
            Dice dice = new Dice(Turn, RandomNumberGen);
            GUIBoard.Display(boardPosition);
            GUIDice.Display(dice, Turn);        
        }
    }
}
