using ChineseMorra;
using System.Security.Cryptography.X509Certificates;

namespace ChineseMorraTest
{
    [TestClass]
    public class TestChineseMorraMatch
    {
        Match partita = new Match();
        [TestMethod]
        public void ChineseMorraMatch_ValidArguments()
        {
            partita._pc.Action = TypeAction.rock;
            partita._player.Action = TypeAction.paper;
            Assert.AreEqual("you won", partita.Winner());
            
        }
    }
}