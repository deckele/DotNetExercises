using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToeGame game1 = new TicTacToeGame(3);
            game1.DisplayBoard();
            while (!game1.IsGameOver)
            {
                game1.play();
                game1.CheckGameOver();
            }
            if (game1.CheckGameOver() == Move.Empty)
            {
                Console.WriteLine("Game over. Stalemate!");
            }
            else
            {
                Console.WriteLine("Game over. {0} wins!!!", game1.CheckGameOver());
            }
        }
    }
}
