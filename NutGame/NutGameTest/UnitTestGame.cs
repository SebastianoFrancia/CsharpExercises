using NutGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutGameTest
{
    [TestClass]
    public class UnitTestGame
    {
        [TestMethod]
        
        public void Game_WithInvalidNamePlayer1()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Game("player 1", null, 15, 1000));
        }

        [TestMethod]
        public void Game_WithInvalidNamePlayer2()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Game(null, "player 2", 15, 1000));
        }

        [TestMethod]
        public void Game_WithInvalidRoundNumber()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Game("player 1", "player 2", 0, 100));
        }

        [TestMethod]
        public void Game_WithInvalidMaxPointsNumber()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Game("player 1", "player 2", 15, 0));
        }


        [TestMethod]
        public void Player_WithValidData()
        {
            Game game = new Game("player 1", "player 2", 15, 100);
            //verifico di aver istanziato l'oggetto game
            Assert.IsNotNull(game);
        }
    }
}
