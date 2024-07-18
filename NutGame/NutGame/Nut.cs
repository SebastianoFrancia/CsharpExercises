using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutGame
{
    public class Nut
    {
        //attributo che contiene il numero delle facce del dado
        private int _numberFace;

        //proprietà associata al numero delle facce
        public int NumberFace
        { 
            //il get semplicemente restituisce il valore del campo
            get { return _numberFace; } 

            //il set imposta il valore nel campo, ma prima di impostarlo si assicura che sia accettabile
            //essendo il metodo private non sarà possibile dall'esterno della classe accedere a questo metodo
            private set { 
                if(value < 4)
                    throw new ArgumentOutOfRangeException("il valore del numero di facce non è accettabile");
                _numberFace = value; 
            } 
        }

        //costruttore che si aspetta come paramentro il nuemro di facce
        //il paramentro ha un valore di default pari a 6,q uesto buol dire che se non passo nesun valore per numberFace questo assumerà valore 6
        public Nut(int numberFace=6)
        {
            //richiamo il set della proprietà passandogli come value il valore del parametro numberFace 
            NumberFace = numberFace;
        }

        /// <summary>
        /// simula il lancio del dato
        /// </summary>
        /// <returns>restituisce il valore uscito dal lancio</returns>
        public int Roll()
        { 
            Random random = new Random();
            //genero un numero random tra 0 e _numberFace-1 e poi aggiungo 1 perchè i valori accettabili della face sono da 1 al numero di facce compreso
            return random.Next(_numberFace)+1;
        }


    }
}
