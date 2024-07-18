using ChineseMorra;
using System.Security.Cryptography.X509Certificates;

namespace ChineseMorraTest
{
    [TestClass]
    public class TestChineseMorraPlayer
    {
        Player player = new Player();
        [TestMethod]
        public void ChineseMorraPlayerCounterWins_WithInvalidCounterWins()
        {
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => player.CounterWins = 3);
            
        }

        [TestMethod]
        public void ChineseMorraPlayerAction_WithNullAction()
        {
            TypeAction test = new TypeAction();
            test = (TypeAction)5;
            Console.WriteLine(test);
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => player.Action = test );
        }

        [TestMethod]
        public void ChineseMorraPlayerEquals_WithinvalidObject()
        {
            Player test = null;
            
            Assert.ThrowsException<System.ArgumentException>(()=> player.Equals(test));
        }
    }
}