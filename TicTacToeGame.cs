using System;
using System.ComponentModel;
using System.Threading;

namespace tic_tac_toe
{
    public class TicTacToeGame
    {
        public static char[] grid = { '-', '-', '-', '-', '-', '-', '-', '-', '-' };
        public static int totalTurns = 0;
        public static Players winner = Players.None;
        static int player = 1;

        public static void PlayGame()
        {
            ResetGame();
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to Tic Tac Toe! \n");
                Console.WriteLine("Player 1: X");
                Console.WriteLine("Player 2: O \n");
                Console.WriteLine("Enter a number from 1 to 9 to select a position. \nPlayer 1 to start\n");
                int playerSelection = 0;
                UpdateBoard();

                try
                {
                    playerSelection = int.Parse(Console.ReadLine()) - 1;
                    if (playerSelection == -1)
                        throw new Exception();
                    if (grid[playerSelection].ToString() != Players.Player1.GetDescription() && grid[playerSelection].ToString() != Players.Player2.GetDescription())
                        if (player % 2 == 0)
                        {
                            grid[playerSelection] = char.Parse(Players.Player2.GetDescription());
                            player++;
                        }
                        else
                        {
                            grid[playerSelection] = char.Parse(Players.Player1.GetDescription());
                            player++;
                        }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Position is already marked with {1}", playerSelection, grid[playerSelection]);
                        Console.WriteLine("board reloading...");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                    }
                    UpdateBoard();
                    totalTurns++;
                    winner = CheckWinner();
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Please enter a number between 1 and 9");
                    Console.WriteLine("board reloading...");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                }
                if (totalTurns == 10)
                    winner = Players.Draw;

            } while (winner == Players.None);

            if (winner == Players.Draw)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nIt's a draw!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0} has won!", winner == Players.Player1 ? "Player 1" : "Player 2");
                Console.ResetColor();
                Console.WriteLine("\nPress any key to play again");
            }

            Console.ReadKey();
            PlayGame();
        }

        public static void UpdateBoard()
        {
            Console.WriteLine(" {0} {1} {2}", grid[0], grid[1], grid[2]);
            Console.WriteLine(" {0} {1} {2}", grid[3], grid[4], grid[5]);
            Console.WriteLine(" {0} {1} {2}", grid[6], grid[7], grid[8]);
        }

        public static Players CheckWinner()
        {
            if (grid[0] == grid[1] && grid[1] == grid[2])
                return GetPlayer(grid[0]);
            else if (grid[3] == grid[4] && grid[4] == grid[5])
                return GetPlayer(grid[3]);
            else if (grid[6] == grid[7] && grid[7] == grid[8])
                return GetPlayer(grid[6]);

            if (grid[0] == grid[3] && grid[3] == grid[6])
                return GetPlayer(grid[0]);
            else if (grid[1] == grid[4] && grid[4] == grid[7])
                return GetPlayer(grid[1]);
            else if (grid[2] == grid[5] && grid[5] == grid[8])
                return GetPlayer(grid[2]);

            if (grid[0] == grid[4] && grid[4] == grid[8])
                return GetPlayer(grid[0]);
            else if (grid[2] == grid[4] && grid[4] == grid[6])
                return GetPlayer(grid[2]);


            return Players.None;
        }

        public static Players GetPlayer(char value)
        {
            if (value.ToString() == Players.Player1.GetDescription())
                return Players.Player1;
            else if (value.ToString() == Players.Player2.GetDescription())
                return Players.Player2;
            else
                return Players.None;
        }

        private static void ResetGame()
        {
            grid = new char[] { '-', '-', '-', '-', '-', '-', '-', '-', '-' };
            totalTurns = 0;
            winner = Players.None;
        }
    }
}
