using MorraCinese;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorraCineseTest
{
    [TestClass]
    public class UnitTestPartita
    {
        [TestMethod]
        public void Round_SceltaUtenteInaccettabileMinore0()
        {
            Partita p = new Partita();
            Assert.ThrowsException<System.ArgumentException>(() => p.Round(-1));
        }

        [TestMethod]
        public void Round_SceltaUtenteInaccettabileMaggiore2()
        {
            Partita p = new Partita();
            Assert.ThrowsException<System.ArgumentException>(() => p.Round(3));
        }
    }
}
