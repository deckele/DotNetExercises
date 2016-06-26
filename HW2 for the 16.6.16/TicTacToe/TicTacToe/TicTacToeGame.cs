using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public enum Move
    {
        Empty,
        X,
        O
    }

    class TicTacToeGame
    {
        private int BoardSize;
        Move[,] board;

        public TicTacToeGame(int boardSize)
        {
            BoardSize = boardSize;
            board = new Move[BoardSize, BoardSize];
        }

        public bool IsGameOver { get; private set; }        

        /// <summary>
        /// Method displys the current status of the game board.
        /// </summary>
        public void DisplayBoard()
        {
            for (int i=0; i<(BoardSize); i++)
            {
                Console.WriteLine();
                for (int j=0; j<(BoardSize); j++)
                {
                    if (j < (BoardSize - 1))
                    {
                        if (board[i, j] == Move.Empty)
                        {
                            Console.Write("   |");
                        }
                        else
                        {
                            Console.Write(" {0} |", board[i, j]);
                        }
                    }
                    else
                    {
                        if (board[i, j] == Move.Empty)
                        {
                            Console.Write("   ");
                        }
                        else
                        {
                            Console.Write(" {0} ", board[i, j]);
                        }
                    }
                }
                if (i < (BoardSize - 1))
                {
                    Console.WriteLine();
                    for (int line=0; line<BoardSize; line++)
                    {
                        Console.Write("----");
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
        }

        private int moveCounter = 1;
        /// <summary>
        /// Determines who's move is it. 
        /// </summary>
        public Move checkTurn()
        {
            if ((moveCounter % 2) != 0)
            {
                return Move.X;                
            }
            else
            {
                return Move.O;                
            }
        }

        /// <summary>
        /// Takes user input, checks if legal move and if legal, plays it.
        /// </summary>
        public void play()
        {
            Console.WriteLine("Choose row for move (1-{0})... ", BoardSize);
            int playX = UserInput();
            Console.WriteLine("Choose column for move (1-{0})... ", BoardSize);
            int playY = UserInput();
            Move turn = checkTurn();
            if (board[playX, playY] == Move.Empty)
            {
                board[playX, playY] = turn;
                moveCounter++;
                Console.Clear();
                DisplayBoard(); 
            }
            else
            {
                Console.Clear();
                DisplayBoard();
                Console.WriteLine("Board move already taken. Choose again.");
            }
        }

        /// <summary>
        /// Checks if user input is correct.
        /// </summary>
        /// <returns></returns>
        public int UserInput()
        {
            while (true)
            {
                int play;
                bool moveCheck;
                moveCheck = int.TryParse(Console.ReadLine(), out play);
                if (moveCheck&&(play>=1)&&(play<=BoardSize))
                {
                    return play-1;
                }
                else
                {
                    Console.WriteLine("Invalid move. Try again.");
                }
            }
        }

        /// <summary>
        /// Checks if game is over.
        /// </summary>
        /// <returns></returns>
        public Move CheckGameOver()
        {
            if (moveCounter <= BoardSize * BoardSize)
            {
                if(CheckRowWin())
                {
                    IsGameOver = true;
                    moveCounter--;
                    return checkTurn();
                }
                else if (CheckColumnWin())
                {
                    IsGameOver = true;
                    moveCounter--;
                    return checkTurn();
                }
                else if (CheckDiagonalWin1())
                {
                    IsGameOver = true;
                    moveCounter--;
                    return checkTurn();
                }
                else if (CheckDiagonalWin2())
                {
                    IsGameOver = true;
                    moveCounter--;
                    return checkTurn();
                }
                else
                {
                    return Move.Empty;
                }
            }
            else
            {
                IsGameOver = true;
                return Move.Empty;
            }
        }

        /// <summary>
        /// Private methods that check all possible win scenarios. All called by CheckGameOver() method.
        /// </summary>
        /// <returns></returns>
        private bool CheckRowWin()
        {
            for (int i = 0; i < BoardSize - 1; i++)
            {
                for (int j = 0; j < BoardSize - 1; j++)
                {
                    if ((board[i,j] != board[i, j+1]) || (board[i, j] == Move.Empty))
                    {
                        break;
                    }
                    else if (j >= (BoardSize - 2))
                    {
                        return true;
                    } 
                }
                
            }
            return false;
        }
        private bool CheckColumnWin()
        {
            for (int j = 0; j < BoardSize - 1; j++)
            {
                for (int i = 0; i < BoardSize - 1; i++)
                {
                    if ((board[i, j] != board[i+1, j]) || (board[i, j] == Move.Empty))
                    {
                        break;
                    }
                    else if (i >= (BoardSize - 2))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool CheckDiagonalWin1()
        {
            for (int i = 0; i < BoardSize - 1; i++)
            {
                if ((board[i, i] != board[i + 1, i + 1]) || (board[i, i] == Move.Empty))
                {
                    return false;
                }
            }
            return true;
        }
        private bool CheckDiagonalWin2()
        {
            for (int i = 0; i < BoardSize - 1; i++)
            {
                if ((board[(BoardSize-1)-i, i] != board[(BoardSize-2)-i, i + 1]) || (board[(BoardSize-1)-i, i] == Move.Empty))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
