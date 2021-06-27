using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace tic_tac_toe.Tests
{
    [TestClass]
    public class TicTacToeGameTests
    {
        [DataTestMethod]
        //Horizontal test
        [DataRow(new char[] { 'X', 'X', 'X', 'O', 'O', '-', 'O', '-', '-' }, Players.Player1)]
        //Vertical test
        [DataRow(new char[] { 'X', 'O', 'O', 'X', '-', '-', 'X', 'O', '-' }, Players.Player1)]
        //Diagonal tests
        [DataRow(new char[] { 'O', 'X', 'X', 'X', 'O', '-', '-', '-', 'O' }, Players.Player2)]
        [DataRow(new char[] { 'X', 'X', 'O', '-', 'O', 'X', 'O', '-', '-' }, Players.Player2)]
        //Draw test
        [DataRow(new char[] { 'X', 'X', 'O', 'O', 'O', 'X', 'X', 'X', 'O' }, Players.None)]
        public void CheckWinnerTest(char[] testGrid, Players expectedResult)
        {
            TicTacToeGame.grid = testGrid;
            var result = TicTacToeGame.CheckWinner(); 
                
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GetPlayerPlayer1Test()
        {
            char value = 'X';
            var result = TicTacToeGame.GetPlayer(value);

            Assert.AreEqual(Players.Player1, result);
        }

        [TestMethod]
        public void GetPlayerPlayer2Test()
        {
            char value = 'O';
            var result = TicTacToeGame.GetPlayer(value);

            Assert.AreEqual(Players.Player2, result);
        }

        [TestMethod]
        public void GetPlayerNoneTest()
        {
            char value = '-';
            var result = TicTacToeGame.GetPlayer(value);

            Assert.AreEqual(Players.None, result);
        }
    }
}