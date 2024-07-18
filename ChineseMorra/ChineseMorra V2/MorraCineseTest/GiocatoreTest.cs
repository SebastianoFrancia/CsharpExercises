using MorraCinese;

namespace MorraCineseTest
{
    [TestClass]
    public class UnitTestGiocatore
    {
        [TestMethod]
        public void Scelta_SceltaUtenteInaccettabileMinore0()
        {
            Giocatore giocatore = new Giocatore();
            Assert.ThrowsException<ArgumentException>(() => giocatore.Scelta = (TipologiaScelta) (-1));
        }

        [TestMethod]
        public void Scelta_SceltaUtenteInaccettabileMaggiore2()
        {
            Giocatore giocatore = new Giocatore();
            Assert.ThrowsException<ArgumentException>(() => giocatore.Scelta = (TipologiaScelta)(3));
        }
    }
}
