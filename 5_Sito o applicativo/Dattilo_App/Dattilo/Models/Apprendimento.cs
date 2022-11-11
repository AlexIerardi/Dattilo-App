using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
        //private Thread thread;
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
        //testo che inserisce l'utente
        public string TestoUtente { get; set; }
        //array con i caratteri del livello
        public string CharLivello { get; set; }
        //numero che incrementa ad ogni livello superato
        public int Nlivello { get; set; }
        //numero di caratteri giusti
        public int CorrectChar { get; set; }
        //numero di caratteri sbagliati
        public int WrongChar { get; set; }
        //percentuale di caratteri giusti
        public int PercChar { get; set; }
        #endregion

        #region =================== costruttori ================
        public Apprendimento()
        {
            inizializzaLivelli();
            NCaratteri = 30;
            Nlivello = 0;
            CharLivello = "";
            TestoUtente = "";
            CorrectChar = 0;
            WrongChar = 0;
            PercChar = 0;
            //ThreadStart ts = ThreadStart(aggiornaSecondi);
            //thread = new Thread(ts);
            //thread.IsBackground = true;
            //thread.Priority = ThreadPriority.BelowNormal;
            //thread.Start();
        }

        #endregion

        #region =================== metodi privati e aiuto =====
        //in base al livello riempe l'array con lettere differenti
        public void generaLivello()
        {

            for (int i = 0; i < NCaratteri; i++)
            {
                CharLivello += livelli[Nlivello][rnd.Next(0, livelli[Nlivello].Length)];
            }
                Debug.WriteLine("|" + CharLivello + "|");

            //for (int i = 0; i < NCaratteri; i++)
            //{
            //    if (i % 2 == 0)
            //    {
            //        CharLivello += "f";

            //    }
            //    else
            //    {
            //        CharLivello += "g";
            //    }
            //}
        }
        //incremento livello
        public void incrementaLivello()
        {
            Nlivello++;
        }
        
        public void confrontaChar()
        {
            if (posChar < NCaratteri)
            {
                if(TestoUtente.Length-1 == posChar)
                {
                    if (TestoUtente[posChar].Equals(CharLivello[posChar])) 
                    {
                        posChar++;
                        CorrectChar++;
                    }
                    else
                    {
                        TestoUtente = TestoUtente.Substring(0, posChar);
                        WrongChar++;
                    }

                }
            }
            else
            {
               // quando ha finito di scrivere
               incrementaLivello();
               posChar = 0;
            }
        }
        //metodo per riempire l'array di stringhe con 
        private void inizializzaLivelli()
        {
            livelli[0] = new string[2] { "f", "j"};
            livelli[1] = new string[5] { "f", "j", "d", "k", " " };
            livelli[2] = new string[7] { "f", "j", "d", "k", "s", "l", " " };
            //altri livelli
        }
        //
        private void aggiornaSecondi()
        {

        }        
        #endregion

        #region =================== metodi generali ============
        //metodo che stampa l'array dei caratteri
        public string stampaLivello()
        {
            string stampa = "";
            for(int i = 0; i < CharLivello.Length; i++)
            {
                if (CharLivello[i] == ' ')
                {
                    stampa += "_";
                }
                else
                {
                    stampa += CharLivello[i];
                }
            }
            Debug.WriteLine("|" + stampa + "|");
            return stampa;
        }
        //metodo che calcola la percentuale di caratteri giusti
        
        public int calcolaPercentuale()
            // non corretto
        {
            if (WrongChar == 0)
            {
                return 0;
            }
            else
            {
                return (int)(CorrectChar / TestoUtente.Length * 100);
            }
        }
        #endregion



    }
}
