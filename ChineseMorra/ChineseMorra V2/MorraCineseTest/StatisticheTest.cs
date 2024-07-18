using MorraCinese;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorraCineseTest
{
    [TestClass]
    public class StatisticheTest
    {
        Statistiche statistiche = new Statistiche(2);
        [TestMethod]
        public void Statistiche_NumeroPartiteNonAccettabile()
        {
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => new Statistiche(-1));
        }

        [TestMethod]
        public void Statistiche_NumeroTotaleRoundNonAccettabile()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => statistiche.NumeroTotaleRound = 5);
        }


        [TestMethod]
        public void Statistiche_NumeroPartiteVinteGiocatoreNonAccettabile()
        {
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => statistiche.NumeroPartiteVinteGiocatore = -1);
        }

        [TestMethod]
        public void Statistiche_NumeroPartiteVintePCNonAccettabile()
        {
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => statistiche.NumeroPartiteVintePc = -1);
        }

        [TestMethod]
        public void Statistiche_CalcolaNumeroTotaleRoundNonAcetabile()
        {
            Partita[] partita = new Partita[2];
            
            Assert.ThrowsException<System.ArgumentException>(() => statistiche.CalcolaNumeroTotaleRound(partita));
        }

        [TestMethod]
        public void Statistiche_NumeroRoundMediPerPartita()
        {
            Partita[] paritta = new Partita[4];
            
            statistiche.NumeroTotaleRound = 10;
            statistiche.NumeroPartite = 2;
            
            Assert.AreEqual(5.0, statistiche.NumeroRoundMediPerPartita());
        }

        [TestMethod]
        public void Statistiche_NumeroPartiteGiocate()
        {
            Partita[] partite = new Partita[5];
            Assert.AreEqual(-1, statistiche.NumeroPartiteGiocate(partite));
        }

        [TestMethod]
        public void Statistiche_NumeroRoundGiocati()
        {
            Partita[] partite = new Partita[5];
            
            for (int i = 0; i < partite.Length; i++)
            {
                partite[i] = new Partita();
                partite[i].NumeroRound = i+3;
            }
            Assert.AreEqual(25, statistiche.NumeroRoundGiocati(partite));
        }
        
        [TestMethod]
        public void Statistiche_PercentualeVittorieGiocatore()
        {
            statistiche.NumeroPartiteVinteGiocatore = 2;

            statistiche.NumeroPartite = 10;
            Assert.AreEqual(20, statistiche.PercentualeVittorie(TipologiaGiocatore.Giocatore));
        }

        [TestMethod]
        public void Statistiche_CalcolaNumeroTotaleRound()
        {
            Partita[] partite = new Partita[2];

            for (int i = 0; i < partite.Length; i++)
            {
                partite[i] = new Partita();
                partite[i].NumeroRound = i+3;
            }
            statistiche.CalcolaNumeroTotaleRound(partite);
            Assert.AreEqual(7, statistiche.NumeroTotaleRound);
        }

        [TestMethod]
        public void Statistiche_PercentualeVittoriePC()
        {
            statistiche.NumeroPartiteVintePc = 10;

            statistiche.NumeroPartite = 20;
            Assert.AreEqual(50, statistiche.PercentualeVittorie(TipologiaGiocatore.Bot));
        }

        [TestMethod]
        public void Statistiche_VincitorePartitaX()
        {
            Partita[] partite = new Partita[5];
            Giocatore uno = new Giocatore();
            partite[2] = new Partita();
            partite[2].VincitorePartita = uno;
            Assert.AreEqual(uno, statistiche.VincitorePartitaX(2, partite));
        }



    }
}
