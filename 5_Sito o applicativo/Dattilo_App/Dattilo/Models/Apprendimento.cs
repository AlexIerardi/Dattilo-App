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
        //numero massimo di livelli
        private const int LIVELLO_MASSIMO = 2;
        #endregion

        #region =================== membri statici =============
        //random
        private Random rnd;
        //array di lettere per i levelli
        private string[][] livelli = new string[15][];
        //posizione del carattere che si sta controllando
        int posCar = 0;
        //thread per la realizzazione del cronometro
        private Thread thread;
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
                posCar = 0;
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
            }
        }
        //array con i caratteri del livello
        public string CarLivello { get; set; }
        //numero che incrementa ad ogni livello superato
        public int NLivello { get; set; }
        //numero di caratteri giusti
        public int CorrectCar { get; set; }
        //numero di caratteri sbagliati
        public int WrongCar { get; set; }
        //percentuale di caratteri giusti
        public double PercCar { get; set; }
        //variabile che aumenta ogni secondo di 1
        public int Cronometro { get; set; }
        //variabile per abilitare il text Box per l'inserimento dell'utente
        public bool TextBoxAttivo { get; set; }
        //variabile per impostare la visibiltà del bottono riprova
        public String VisibilitaPulsanteRiprova { get; set; }
        public String VisibilitaPulsanteAvanti { get; set; }
        public String VisibilitaPulsantePrecedente { get; set; }
        #endregion 

        #region =================== costruttori ================
        public Apprendimento()
        {
            InizializzaLivelli();
            NCaratteri = 5;
            NLivello = 0;
            CarLivello = "";
            TestoUtente = "";
            CorrectCar = 0;
            WrongCar = 0;
            PercCar = 0;
            Cronometro = 0;
            TextBoxAttivo = true;
            VisibilitaPulsanteRiprova = "Collapsed";
            VisibilitaPulsanteAvanti = "Collapsed";
            VisibilitaPulsantePrecedente = "Collapsed";

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
            CarLivello = "";
            for (int i = 0; i < NCaratteri; i++)
            {
                string charGenerato = livelli[NLivello][rnd.Next(0, livelli[NLivello].Length)];
                if (charGenerato.Equals(" ") && (i == 0 || i == nCaratteri - 1))
                {
                    i--;
                }
                else if (charGenerato.Equals(" ") && i > 1 && CarLivello[i - 1] == 32)
                {
                    i--;
                }
                else
                {
                    CarLivello += charGenerato;
                }
            }
        }             
        //confronta caratteri dell'utente con quelli generati
        public void ConfrontaChar()
        {
            if (posCar < NCaratteri)
            {
                if(TestoUtente.Length-1 == posCar)
                {
                    if (TestoUtente[posCar].Equals(CarLivello[posCar])) 
                    {
                        posCar++;
                        CorrectCar++;
                    }
                    else
                    {
                        TestoUtente = TestoUtente.Substring(0, posCar);
                        WrongCar++;
                    }
                }
            }            
            CalcolaPercentuale();
            if (posCar == NCaratteri)
            {
                posCar = 0;
                TextBoxAttivo = false;
                //posizione sbaglaita
                if (NLivello != 0)
                    VisibilitaPulsantePrecedente = "Visible";
                VisibilitaPulsanteRiprova = "Visible";
                if(PercCar > 80 && NLivello < LIVELLO_MASSIMO)
                    VisibilitaPulsanteAvanti = "Visible";
            }
        }
        //metodo per riempe l'array dei livelli con i rispettivi caratteri
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
            if ((CorrectCar + WrongCar) > 0)
                PercCar = ((double)CorrectCar / (double)(CorrectCar + WrongCar))*100;
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
        public string StampaLivello()
        {
            GeneraLivello();
            string stampa = "";
            for(int i = 0; i < CarLivello.Length; i++)
            {
                stampa += CarLivello[i];
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
        //metdo che ritorna la stampa con il numero del livello
        public string StringaLivello()
        {
            return "LIVELLO: " + NLivello;
        }
        #endregion
    }
}
