using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dattilo.Models
{
    public class Apprendimento
    {


        #region =================== costanti ===================
        #endregion

        #region =================== membri statici =============
        private Random rnd = new Random();
        //array di lettere per i levelli
        private string[][] livelli = new string[15][];
        int posChar = 0;
        #endregion

        #region =================== membri & proprietà =========
        //lunghezza array di caratteri
        private int nCaratteri;
        public int NCaratteri
        {
            get { return nCaratteri; }
            set 
            {
                if(value <= 30)
                    value = 30; 
                nCaratteri = value; 
            }
        }
        //array con i caratteri del livello
        public string[] CharLivello { get; set; }
        //numero che incrementa ad ogni livello superato
        public int Nlivello { get; set; }
        //testo che inserisce l'utente
        private string testoUtente;
        public string TestoUtente
        {
            get { return testoUtente; }
            set { testoUtente = value; }
        }
        #endregion

        #region =================== costruttori ================
        public Apprendimento()
        {
            inizializzaLivelli();
            NCaratteri = 30;
            Nlivello = 0;
            CharLivello = new string[NCaratteri];
            TestoUtente = "";
        }

        #endregion

        #region =================== metodi privati e aiuto =====
        //in base al livello riempe l'array con lettere differenti
        public void generaLivello()
        {

            for (int i = 0; i < NCaratteri; i++)
            {
                CharLivello[i] = livelli[Nlivello][rnd.Next(0, livelli[Nlivello].Length)];
            }

            for (int i = 0; i < NCaratteri; i++)
            {
                if (i % 2 == 0)
                {
                    CharLivello[i] = "f";

                }
                else
                {
                    CharLivello[i] = "g";
                }
            }
            //CharLivello[0] = "f";
            //CharLivello[1] = "i";
            //CharLivello[2] = "a";
            //CharLivello[3] = "o";

        }
        //incremento livello
        public void incrementaLivello()
        {
            Nlivello++;
        }
        //metodo per cambiare la lunghezza dell'array per i caratteri da stampare
        public void cambiaLunghezzaCharLivello()
        {
            CharLivello = new string[NCaratteri];
        }
        public bool confrontaChar()
        {
            if (posChar <= NCaratteri)
            {
                if (TestoUtente[posChar].ToString().Equals(CharLivello[posChar].ToString()))
                {
                    posChar++;
                    return true;
                }
                else
                    return false;

            }
            else
            {
                posChar = 0;
                return false;
            }
        }
        //metodo per riempire l'array di stringhe con 
        private void inizializzaLivelli()
        {
            livelli[0] = new string[3] { "f", "j", " "  };
            livelli[1] = new string[5] { "f", "j", "d", "k", " " };
            livelli[2] = new string[7] { "f", "j", "d", "k", "s", "l", " " };
            //altri livelli
        }
        #endregion

        #region =================== metodi generali ============
        //metodo che stampa l'array dei caratteri
        public string stampaLivello()
        {
            string stampa = "";
            for(int i = 0; i < CharLivello.Length; i++)
            {
                stampa += CharLivello[i];
            }
            return stampa;
        }        
        #endregion


    }
}
