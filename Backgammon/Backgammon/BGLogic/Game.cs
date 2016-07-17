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
            IPlayer redPlayer, IPlayer blackPlayer, Random randomNumberGen)
        {
            GUIBoard = guiBoard;
            GUIDice = guiDice;
            GUIMessageArea = guiMessageArea;
            RedPlayer = redPlayer;
            BlackPlayer = blackPlayer;

            RandomNumberGen = randomNumberGen;

            Turn = Checker.CheckerColor.Black;
        }

        private Random RandomNumberGen { get; }

        public Checker.CheckerColor Turn { get; private set; }
        public Dice Dice { get; private set; }

        private IBoardDrawable GUIBoard { get; }
        private IDiceDrawable GUIDice { get; }
        private IMessageDrawable GUIMessageArea { get; }
        private IPlayer RedPlayer { get; }
        private IPlayer BlackPlayer { get; }

        private void PassTurn()
        {
            if (Turn == Checker.CheckerColor.Red)
            {
                Turn = Checker.CheckerColor.Black;
            }
            else if (Turn == Checker.CheckerColor.Black)
            {
                Turn = Checker.CheckerColor.Red;
            }
        }

        public void Run()
        {
            BoardPosition boardPosition = new BoardPosition();
            Logic logic = new Logic();
            Console.SetWindowSize(100, 45);

            //Main game Loop.
            while (!boardPosition.CheckWin())
            {
                //Current player rolls dice
                if (Turn == Checker.CheckerColor.Red)
                {
                    Dice = RedPlayer.Roll(Turn, RandomNumberGen);
                }
                else if (Turn == Checker.CheckerColor.Black)
                {
                    Dice = BlackPlayer.Roll(Turn, RandomNumberGen);
                }

                while (Dice.CurrentDiceNumbers.Count > 0)
                {
                    GUIBoard.Display(boardPosition);
                    GUIDice.Display(Dice, Turn);
                    GUIMessageArea.Display(logic, boardPosition, Dice, Turn);

                    if (Turn == Checker.CheckerColor.Red)
                    {
                        Move userInput = RedPlayer.ChooseMove(Dice.CurrentDiceNumbers,
                            logic.ListPossibleMoves(boardPosition, Dice, Turn), Turn);
                        logic.ApplyMove(boardPosition, userInput, Turn);
                    }
                    else if (Turn == Checker.CheckerColor.Black)
                    {
                        Move userInput = BlackPlayer.ChooseMove(Dice.CurrentDiceNumbers,
                            logic.ListPossibleMoves(boardPosition, Dice, Turn), Turn);
                        logic.ApplyMove(boardPosition, userInput, Turn);
                    }
                }

                if (!boardPosition.CheckWin())
                {
                    PassTurn();
                }
            }
            GUIMessageArea.DisplayWinner(Turn);
        }
    }
}
