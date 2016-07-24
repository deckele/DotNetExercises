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
        public EventHandler<StateChangedEventArgs> StateChanged;
        public EventHandler<StateChangedEventArgs> GameEnded;
        public Func<bool> PlayAgainUserInput;
        public Func<List<int>, List<Move>, CheckerColor, Move> MoveChoiceUserInput;

        protected virtual void OnStateChanged(BoardPosition boardPosition, Dice dice, CheckerColor checkerColor, Logic logic)
        {
            StateChanged?.Invoke(this, new StateChangedEventArgs(boardPosition, dice, checkerColor, logic));
        }

        protected virtual void OnGameEnded(BoardPosition boardPosition, Dice dice, CheckerColor checkerColor, Logic logic)
        {
            GameEnded?.Invoke(this, new StateChangedEventArgs(boardPosition, dice, checkerColor, logic));
        }

        public Game(IPlayer redPlayer, IPlayer blackPlayer, Random randomNumberGen)
        {
            RedPlayer = redPlayer;
            BlackPlayer = blackPlayer;

            RandomNumberGen = randomNumberGen;

            Turn = CheckerColor.Red;
        }

        private Random RandomNumberGen { get; }

        public CheckerColor Turn { get; private set; }
        public Dice Dice { get; private set; }

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

                while ((Dice.CurrentDiceNumbers.Count > 0) && !boardPosition.CheckWin())
                {
                    OnStateChanged(boardPosition, Dice, Turn, logic);

                    if (logic.ListPossibleMoves(boardPosition, Dice, Turn).Count > 0 )
                    {
                        if (Turn == CheckerColor.Red)
                        {
                            Move userInput = RedPlayer.ChooseMove(Dice.CurrentDiceNumbers,
                                logic.ListPossibleMoves(boardPosition, Dice, Turn), Turn, this);
                            logic.ApplyMove(boardPosition, userInput, Turn);
                        }
                        else if (Turn == CheckerColor.Black)
                        {
                            Move userInput = BlackPlayer.ChooseMove(Dice.CurrentDiceNumbers,
                                logic.ListPossibleMoves(boardPosition, Dice, Turn), Turn, this);
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
            }

            OnGameEnded(boardPosition, Dice, Turn, logic);
        }

        public bool PlayAgainCheck()
        {
            return PlayAgainUserInput.Invoke();
        }
    }
}
