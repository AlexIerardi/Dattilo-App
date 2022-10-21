using System;
using System.Collections.Generic;
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
        //https://stackoverflow.com/questions/47128393/how-to-detect-keypress-in-textbox-using-mvvm-light
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
        //
        public void confrontaTesti()
        {

        }

        //metodo per riempire l'array di stringhe con 
        private void inizializzaLivelli()
        {
            livelli[0] = new string[3] { "f", "j", " " };
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
