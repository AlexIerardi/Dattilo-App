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
        private Random rnd;
        //array di lettere per i levelli
        private string[][] livelli = new string[15][];
        int posChar = 0;
        private Thread thread;
        //variabile che aumenta ogni secondo di 1
        private int Cronometro { get; set; }
        #endregion

        #region =================== membri & proprietà =========
        //lunghezza array di caratteri
        private int nCaratteri;
        public int NCaratteri
        {
            get { return nCaratteri; }
            set 
            {
                if(value < 5)
                    value = 5;
                //else if(value > )
                nCaratteri = value;
                posChar = 0;
            }
        }
        //testo che inserisce l'utente
        private string _testoUtente;
        public string TestoUtente
        {
            get { return _testoUtente; }
            set 
            {
                _testoUtente = value;
                ConfrontaChar();
                CalcolaPercentuale();
            }
        }
        //array con i caratteri del livello
        public string CharLivello { get; set; }
        //numero che incrementa ad ogni livello superato
        public int Nlivello { get; set; }
        //numero di caratteri giusti
        public int CorrectChar { get; set; }
        //numero di caratteri sbagliati
        public int WrongChar { get; set; }
        //percentuale di caratteri giusti
        public double PercChar { get; set; }
        //variabile per abilitare il text Box per l'inserimento dell'utente
        public bool TextBoxEnable { get; set; }
        //variabile per impostare la visibiltà del bottono riprova
        public String VisibilityButtonRiprova { get; set; }
        public String VisibilityButtonAvanti { get; set; }
        #endregion 

        #region =================== costruttori ================
        public Apprendimento()
        {
            InizializzaLivelli();
            NCaratteri = 5;
            Nlivello = 0;
            CharLivello = "";
            TestoUtente = "";
            CorrectChar = 0;
            WrongChar = 0;
            PercChar = 0;
            Cronometro = 0;
            TextBoxEnable = true;
            VisibilityButtonRiprova = "Collapsed";
            VisibilityButtonAvanti = "Collapsed";

            rnd = new Random();
            ThreadStart ts = new ThreadStart(AggiornaCronometro);
            thread = new Thread(ts);
            thread.IsBackground = true;
            thread.Priority = ThreadPriority.BelowNormal;
            thread.Start();
        }

        #endregion

        #region =================== metodi privati e aiuto =====
        //in base al livello riempe l'array con lettere differenti
        public void GeneraLivello()
        {
            CharLivello = "";
            for (int i = 0; i < NCaratteri; i++)
            {
                string charGenerato = livelli[Nlivello][rnd.Next(0, livelli[Nlivello].Length)];
                if (charGenerato.Equals(" ") && (i == 0 || i == nCaratteri - 1))
                {
                    i--;
                }
                else if (charGenerato.Equals(" ") && i > 1 && CharLivello[i - 1] == 32)
                {
                    i--;
                }
                else
                {
                    CharLivello += charGenerato;
                }
            }
        }             
        //confronta caratteri dell'utente con quelli generati
        public void ConfrontaChar()
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
            if (posChar == NCaratteri)
            {
                VisibilityButtonRiprova = "Visible";
                TextBoxEnable = false;
                posChar = 0;
                if(PercChar > 80)
                {
                    VisibilityButtonAvanti = "Visible";
                }
            }
        }
        //metodo per riempire l'array di stringhe con 
        private void InizializzaLivelli()
        {
            livelli[0] = new string[3] { "f", "j", " "};
            livelli[1] = new string[5] { "f", "j", "d", "k", " " };
            livelli[2] = new string[7] { "f", "j", "d", "k", "s", "l", " " };
            //altri livelli
        }
        //metdo per calcolare la percentuale
        public void CalcolaPercentuale()
        {
            if ((CorrectChar + WrongChar) > 0)
                PercChar = ((double)CorrectChar / (double)(CorrectChar + WrongChar))*100;
        }
        //metdo che aggiorno il cronometro
        private void AggiornaCronometro()
        {
            while (true)
            {
                Cronometro++;
                ConvertToSM();
                Thread.Sleep(1000);
            }
        }
        #endregion

        #region =================== metodi generali ============
        //metodo che stampa l'array dei caratteri
        public string stampaLivello()
        {
            GeneraLivello();
            string stampa = "";
            for(int i = 0; i < CharLivello.Length; i++)
            {
                stampa += CharLivello[i];
            }
            return stampa;
        }
        //metodo che converte la variabile cronometro in minuti e secondi
        public string ConvertToSM()
        {
            int min = Cronometro / 60;
            int sec = Cronometro - min * 60;
            string secText = Convert.ToString(sec);
            string minText = Convert.ToString(min);

            if (sec < 10)
            {
                secText = "0" + sec;
            }
            if (min < 10)
            {
                minText = "0" + min;
            }
            return minText + ":" + secText ;
        }
        #endregion
    }
}
