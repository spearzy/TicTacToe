using System;
using System.ComponentModel;
using System.Threading;

namespace tic_tac_toe
{
    public class Program
    {
        static char[] grid = { '-', '-', '-', '-', '-', '-', '-', '-', '-' };
        static int totalTurns = 0;
        static Players winner = Players.None;
        static int player = 1;
        static void Main(string[] args)
        {
            TicTacToeGame.PlayGame();          
        }

    }
}
