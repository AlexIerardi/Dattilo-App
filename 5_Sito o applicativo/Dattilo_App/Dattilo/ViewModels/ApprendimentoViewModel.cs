using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Dattilo.Models;
using CommunityToolkit.Mvvm.Input;
using System.Threading;

namespace Dattilo.ViewModels
{
    public class ApprendimentoViewModel : ObservableObject
    {
        #region =================== costanti ===================
        #endregion

        #region =================== membri statici =============
        private Thread thread;
        private Apprendimento model;
        #endregion

        #region =================== membri & proprietà =========
        //lunghezza array di caratteri che poi andranno stampati
        public int NCaratteri
        {
            get { return model.NCaratteri; }
            set 
            {
                if (model.NCaratteri == value)
                    return;
                model.NCaratteri = value;                
                OnPropertyChanged(nameof(NCaratteri));
                OnPropertyChanged(nameof(Stampa));
                TestoUtente = "";
            }
        }        
        //stampa del array di caratteri
        public String Stampa
        {
            get { return model.stampaLivello(); }            
        }        
        //testo inserito dall'utente
        public string TestoUtente
        {
            get 
            {
                return model.TestoUtente;
            }
            set 
            {
                if (model.TestoUtente == value)
                    return;
                model.TestoUtente = value;
                OnPropertyChanged(nameof(TestoUtente));
                OnPropertyChanged(nameof(CorrectChar));
                OnPropertyChanged(nameof(WrongChar));
                OnPropertyChanged(nameof(PercChar));
            }
        }
        //numero di giusti sbagliati scritti dall'utente
        public int CorrectChar
        {
            get { return model.CorrectChar; }
        }
        //numero di carattetri sbagliati scritti dall'utente
        public int WrongChar
        {
            get { return model.WrongChar; }
        }
        //percentuale di caratteri giusti
        public double PercChar
        {
            get { return model.PercChar; }
        }
        public string Cronometro
        {
            get { return model.ConvertToSM(); }
        }
        public RelayCommand NothingCommand { get; protected set; }
        #endregion

        #region =================== costruttori ================
        public ApprendimentoViewModel()
        {
            model = new Apprendimento();
            NothingCommand = new RelayCommand(DoNothing);
            ThreadStart ts = new ThreadStart(AggiornaCronometro);
            thread = new Thread(ts);
            thread.IsBackground = true;
            thread.Priority = ThreadPriority.BelowNormal;
            thread.Start();
        }

        #endregion

        #region =================== metodi privati e aiuto =====
        // metodo che non fa nulla che viene richiamato quando viene premuto il tasto backsapce
        private void DoNothing()
        {
            ;
        }
        private void AggiornaCronometro()
        {
            while (true)
            {
                OnPropertyChanged(nameof(Cronometro));
                Thread.Sleep(200);
            }
        }
        
        #endregion

        #region =================== metodi generali ============
        #endregion

    }
}
