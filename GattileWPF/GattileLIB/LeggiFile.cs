using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GattileLIB
{
    public class LeggiFile
    {
        private string _pathGatti;
        private string _pathAdottanti;
        private string _pathAdozioni;

        public LeggiFile(string pathGatti, string pathAdottanti, string pathAdozioni)
        {
            _pathGatti = pathGatti;
            _pathAdottanti = pathAdottanti;
            _pathAdozioni = pathAdozioni;
        }

        public LeggiFile(string pathGatti, string pathAdottanti) 
        {
            _pathGatti = pathGatti;
            _pathAdottanti = pathAdottanti;
        }

        public LeggiFile(string pathAdozioni)
        {
            _pathAdozioni = pathAdozioni;
        }

        public List<Gatto> LeggiDatiGatti()
        {
            List<Gatto> gatti = new List<Gatto>();
            string line;
            using (StreamReader sr = new StreamReader(_pathGatti))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string[] dati = line.Split('$');
                    string id = dati[0];
                    string nome = dati[1];
                    string Srazza = dati[2];
                    string Ssesso = dati[3];
                    string Sarrivo = dati[4];
                    string? Suscita = dati[5];
                    string? Snascita = dati[6];
                    string descrizione = dati[7];

                    Razza razza = StringToRazza(Srazza);
                    Sesso sesso = StringToSesso(Ssesso);
                    DateOnly arrivo = DateOnly.Parse(Sarrivo);

                    DateOnly? uscita;
                    if (Suscita == string.Empty)
                    {
                        uscita = null;
                    }
                    else
                    {
                        uscita = DateOnly.Parse(Suscita);
                    }

                    DateOnly? nascita;
                    if (Snascita == string.Empty)
                    {
                        nascita = null;
                    }
                    else
                    {
                        nascita = DateOnly.Parse(Snascita);
                    }

                    gatti.Add(new Gatto(id, nome, razza, sesso, arrivo, uscita, nascita, descrizione));
                }
            }
            return gatti;
        }

        private Razza StringToRazza(string Srazza)
        {
            if (Srazza == Razza.Sconosciuta.ToString())
            {
                return Razza.Sconosciuta;
            }
            else if (Srazza == Razza.Siamese.ToString())
            {
                return Razza.Siamese;
            }
            else if (Srazza == Razza.Soriano.ToString())
            {
                return Razza.Soriano;
            }
            else if (Srazza == Razza.ColorpointShorthair.ToString())
            {
                return Razza.ColorpointShorthair;
            }
            else if (Srazza == Razza.Persiano.ToString())
            {
                return Razza.Persiano;
            }
            else throw new Exception(message: "razza string non acetabile");
        }

        private Sesso StringToSesso(string Ssesso)
        {
            if (Ssesso == Sesso.Femmina.ToString())
            {
                return Sesso.Femmina;
            }
            else if (Ssesso == Sesso.Maschio.ToString())
            {
                return Sesso.Maschio;
            }
            else throw new Exception(message: "sesso string non acetabile");
        }


        public List<Adottante> LeggiDatiAdottanti()
        {
            List<Adottante> adottanti = new List<Adottante>();
            string line;
            using (StreamReader sr = new StreamReader(_pathAdottanti))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string[] dati = line.Split('$');
                    string nome = dati[0];
                    string cognome = dati[1];
                    string indirizzo = dati[2];
                    int telefono = int.Parse(dati[3]);

                    adottanti.Add(new Adottante(nome, cognome, indirizzo, telefono));
                }
            }
            return adottanti;
        }

        public List<Adozione> LeggiDatiAdozioni(List<Gatto> gatti)
        { 
            List<Adozione> adozioni = new List<Adozione>();
            string line;
            using (StreamReader sr = new StreamReader(_pathAdozioni))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string[] dati = line.Split('$');
                    string id = dati[0];
                    DateOnly data = DateOnly.Parse(dati[1]);

                    string nome = dati[2];
                    string cognome = dati[3];
                    string indirizzo = dati[4];
                    int telefono = int.Parse(dati[5]);

                    adozioni.Add(new Adozione( IdToGatto(gatti, id), data, new Adottante(nome, cognome, indirizzo, telefono) ));
                }
            }
            return adozioni;
        }

        public Gatto IdToGatto(List<Gatto> gatti, string id)
        {
            for (int i = 0; i < gatti.Count; i++)
            {
                if (gatti[i].Id == id) return gatti[i];
            }
            throw new Exception(message: "id del gatto non trovato");
        }
    }
}
