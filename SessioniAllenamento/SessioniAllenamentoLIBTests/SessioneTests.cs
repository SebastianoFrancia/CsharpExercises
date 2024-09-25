using Microsoft.VisualStudio.TestTools.UnitTesting;
using SessioniAllenamentoLIB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessioniAllenamentoLIB.Tests
{
    [TestClass()]
    public class SessioneTests
    {
        [TestMethod()]
        public void TempoSecondiNonValido()
        {
            Assert.ThrowsException<ArgumentException>(() => new Sessione(1, 2, 60));
            Assert.ThrowsException<ArgumentException>(() => new Sessione(1, 2, -1));
        }

        public void TempoMinutiNonValido()
        {
            Assert.ThrowsException<ArgumentException>(() => new Sessione(1, 60, 6));
            Assert.ThrowsException<ArgumentException>(() => new Sessione(1, -1, 6));
        }

        public void TempoOreNonValido()
        {
            Assert.ThrowsException<ArgumentException>(() => new Sessione(-1, 1, 6));
        }

        [TestMethod()]
        public void SessioneIsIntensivoTest()
        {
            Sessione a = new Sessione(4,1,2);
            Assert.AreEqual(true, a.IsIntensivo);

            Sessione b = new Sessione(3, 59, 59);
            Assert.AreEqual(false, b.IsIntensivo);
        }

    }
}