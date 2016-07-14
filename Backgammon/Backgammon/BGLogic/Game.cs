using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public class Game
    {
        public Game(IBoardDrawable guiBoard, IDiceDrawable guiDice)
        {

            GUIBoard = guiBoard;
            GUIDice = guiDice;

            Turn = Checker.CheckerColor.Red;
            RandomNumberGen = new Random();
        }

        public Checker.CheckerColor Turn { get; private set; }
        private Random RandomNumberGen { get; }

        private IBoardDrawable GUIBoard { get; }
        private IDiceDrawable GUIDice { get; }


        public void Run()
        {
            BoardPosition boardPosition = new BoardPosition();          
            Dice dice = new Dice(Turn, RandomNumberGen);
            GUIBoard.Display(boardPosition);
            GUIDice.Display(dice, Turn);        
        }
    }
}
