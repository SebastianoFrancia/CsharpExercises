using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NutGame;

namespace NutGameTest
{
    /*
     qui tutti i tets per la classe Player
     */
    [TestClass]
    public class UnitTestPlayer
    {
        [TestMethod]
        public void Player_WithInvalidName()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Player(null));
        }

        [TestMethod]
        public void Player_WithValidName()
        {
            Player player = new Player("Name");
            Assert.AreEqual("Name", player.Name);
        }

    }
}
