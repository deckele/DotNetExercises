using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backgammon
{
    public class Game
    {
        public EventHandler<EventArgs> OnTurnEnded;

        public Game(IBoardDrawable guiBoard, IDiceDrawable guiDice, IMessageDrawable guiMessageArea, 
            IPlayer redPlayer, IPlayer blackPlayer, Random randomNumberGen)
        {
            GUIBoard = guiBoard;
            GUIDice = guiDice;
            GUIMessageArea = guiMessageArea;
            RedPlayer = redPlayer;
            BlackPlayer = blackPlayer;

            RandomNumberGen = randomNumberGen;

            Turn = CheckerColor.Red;
        }

        private Random RandomNumberGen { get; }

        public CheckerColor Turn { get; private set; }
        public Dice Dice { get; private set; }

        private IBoardDrawable GUIBoard { get; }
        private IDiceDrawable GUIDice { get; }
        private IMessageDrawable GUIMessageArea { get; }
        private IPlayer RedPlayer { get; }
        private IPlayer BlackPlayer { get; }

        private void PassTurn()
        {
            if (Turn == CheckerColor.Red)
            {
                Turn = CheckerColor.Black;
            }
            else if (Turn == CheckerColor.Black)
            {
                Turn = CheckerColor.Red;
            }
            
        }

        public void Run()
        {
            BoardPosition boardPosition = new BoardPosition();
            Logic logic = new Logic();
            Console.SetWindowSize(100, 42);

            //Main game Loop.
            while (!boardPosition.CheckWin())
            {
                //Current player rolls dice
                if (Turn == CheckerColor.Red)
                {
                    Dice = RedPlayer.Roll(Turn, RandomNumberGen);
                }
                else if (Turn == CheckerColor.Black)
                {
                    Dice = BlackPlayer.Roll(Turn, RandomNumberGen);
                }

                while (Dice.CurrentDiceNumbers.Count > 0)
                {
                    GUIBoard.Display(boardPosition);
                    GUIDice.Display(Dice, Turn);
                    GUIMessageArea.Display(logic, boardPosition, Dice, Turn);

                    if (logic.ListPossibleMoves(boardPosition, Dice, Turn).Count > 0)
                    {
                        if (Turn == CheckerColor.Red)
                        {
                            Move userInput = RedPlayer.ChooseMove(Dice.CurrentDiceNumbers,
                                logic.ListPossibleMoves(boardPosition, Dice, Turn), Turn);
                            logic.ApplyMove(boardPosition, userInput, Turn);
                        }
                        else if (Turn == CheckerColor.Black)
                        {
                            Move userInput = BlackPlayer.ChooseMove(Dice.CurrentDiceNumbers,
                                logic.ListPossibleMoves(boardPosition, Dice, Turn), Turn);
                            logic.ApplyMove(boardPosition, userInput, Turn);
                        }
                    }
                    //In case there are no legal moves
                    else
                    {
                        Dice.CurrentDiceNumbers.Clear();
                    }
                }
                //Checking if someone is winning
                if (!boardPosition.CheckWin())
                {
                    PassTurn();
                }
                //Displaying the board for the last time before ending game loop;
                else
                {
                    GUIBoard.Display(boardPosition);
                }
            }
        }

        public bool EndGame()
        {
            return GUIMessageArea.DisplayWinner(Turn);
        }
    }
}
