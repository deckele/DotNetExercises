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

            Turn = Checker.CheckerColor.Black;
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
            Logic logic = new Logic();
            Console.SetWindowSize(100, 45);

            while (!(boardPosition.RedIsWin() || boardPosition.BlackIsWin()))
            {
                Dice dice = new Dice(Turn, RandomNumberGen);
                GUIBoard.Display(boardPosition);
                GUIDice.Display(dice, Turn);
                GUIMessageArea.Display(logic, boardPosition, dice, Turn);

                if (Turn == Checker.CheckerColor.Red)
                {
                    Move userInput = RedPlayer.ChooseMove(dice.CurrentDiceNumbers,
                        logic.ListPossibleMoves(boardPosition, dice, Turn));
                    logic.ApplyMove(boardPosition, userInput, Turn);
                    Turn = Checker.CheckerColor.Black;
                }
                else if (Turn == Checker.CheckerColor.Black)
                {
                    Move userInput = BlackPlayer.ChooseMove(dice.CurrentDiceNumbers,
                        logic.ListPossibleMoves(boardPosition, dice, Turn));
                    logic.ApplyMove(boardPosition, userInput, Turn);
                    Turn = Checker.CheckerColor.Red;
                }
            }
        }
    }
}
