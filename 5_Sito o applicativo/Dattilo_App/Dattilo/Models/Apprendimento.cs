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
        Random rnd = new Random();
        //array di lettere per i levelli
        private string[] charPrimoLivello = new string[] {"f","j"," "};
        private string[] charSecondoLivello = new string[] {"f","j","d","k"," "};
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

        #endregion

        #region =================== costruttori ================
        public Apprendimento()
        {
            generaLivello();
            NCaratteri = 30;
            Nlivello = 1;
            CharLivello = new string[NCaratteri];
        }
        
        #endregion

        #region =================== metodi privati e aiuto =====
        //in base al livello riempe l'array con lettere differenti
        public void generaLivello()
        {
            if (Nlivello == 1)
            {
                for (int i = 0; i < NCaratteri; i++)
                {
                    CharLivello[i] = charPrimoLivello[rnd.Next(0, 2)];
                }
            }else if (Nlivello == 2)
            {
                for (int i = 0; i < NCaratteri; i++)
                {
                    CharLivello[i] = charSecondoLivello[rnd.Next(0, 4)];
                }
            }
        }
        public void incrementaLivello()
        {
            //da fare
        }

        #endregion

        #region =================== metodi generali ============
        public string stampaLivello()
        {
            //da fare
            return "";
        }
        #endregion


    }
}
