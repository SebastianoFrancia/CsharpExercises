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
    public class AtletaTests
    {
        [TestMethod()]
        public void TempoSecondiNonValido()
        {
            List<int[]> tempi = new List<int[]>();
            tempi.Add(new int[] { 1, 2, 60 });
            tempi.Add(new int[] { 1, 2, -1 });
            Assert.ThrowsException<ArgumentException>(() => new Atleta(tempi));
            Assert.ThrowsException<ArgumentException>(() => new Atleta(tempi));
        }

        public void TempoMinutiNonValido()
        {
            List<int[]> tempi = new List<int[]>();
            tempi.Add(new int[] { 1, 60, 6 });
            tempi.Add(new int[] { 1, -1, 6 });
            Assert.ThrowsException<ArgumentException>(() => new Atleta(tempi));
            Assert.ThrowsException<ArgumentException>(() => new Atleta(tempi));
        }

        public void TempoOreNonValido()
        {
            List<int[]> tempi = new List<int[]>();
            tempi.Add(new int[] { -1, 1, 6 });
            Assert.ThrowsException<ArgumentException>(() => new Atleta(tempi));
        }

        [TestMethod()]
        public void StessiTempiAllenamentiTest()
        {
            List<int[]> tempi1 = new List<int[]>();
            tempi1.Add(new int[] { 1, 10, 3 });
            tempi1.Add(new int[] { 10, 0, 4 });
            Atleta a = new Atleta(tempi1);

            List<int[]> tempi2 = new List<int[]>();
            tempi2.Add(new int[] { 1, 10, 3 });
            tempi2.Add(new int[] { 10, 0, 4 });
            Atleta b = new Atleta(tempi2);

            Assert.AreEqual(true, a.StessiTempiAllenamenti(b));

            List<int[]> tempi3 = new List<int[]>();
            tempi3.Add(new int[] { 10, 10, 3 });
            tempi3.Add(new int[] { 10, 0, 4 });
            Atleta c = new Atleta(tempi3);

            Assert.AreEqual(false, a.StessiTempiAllenamenti(c));
        }

        [TestMethod()]
        public void MiglioreAllenamentoIntensivoTest()
        {
            List<int[]> tempi1 = new List<int[]>();
            tempi1.Add(new int[] { 1, 10, 3 });
            tempi1.Add(new int[] { 10, 0, 4 });
            Atleta a = new Atleta(tempi1);

            Assert.AreEqual(10 *60 + 0 + 4 / 60, a.MiglioreAllenamentoIntensivo);

            List<int[]> tempi2 = new List<int[]>();
            tempi2.Add(new int[] { 1, 10, 3 });
            tempi2.Add(new int[] { 2, 0, 4 });
            Atleta b = new Atleta(tempi2);

            Assert.AreEqual(null, b.MiglioreAllenamentoIntensivo);

        }

        [TestMethod()]
        public void MiglioreAllenamentoStandardTest()
        {
            List<int[]> tempi1 = new List<int[]>();
            tempi1.Add(new int[] { 1, 10, 3 });
            tempi1.Add(new int[] { 10, 0, 4 });
            Atleta a = new Atleta(tempi1);

            Assert.AreEqual(10 * 60 + 0 + 3 / 60, a.MiglioreAllenamentoIntensivo);

            List<int[]> tempi2 = new List<int[]>();
            tempi2.Add(new int[] { 1, 10, 3 });
            tempi2.Add(new int[] { 2, 0, 4 });
            Atleta b = new Atleta(tempi2);

            Assert.AreEqual(2 * 60 + 0 + 4 / 60, b.MiglioreAllenamentoStandard);

        }
    }
}