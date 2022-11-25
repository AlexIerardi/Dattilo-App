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
                OnPropertyChanged(nameof(TextBoxEnable));
                OnPropertyChanged(nameof(VisibilityButtonRiprova));
                OnPropertyChanged(nameof(VisibilityButtonAvanti));
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
        //stringa per stampare il cronometro che viene calcolato nel model
        public string Cronometro
        {
            get { return model.ConvertToSM(); }
        }
        //variabile per abilitare il textbox
        public bool TextBoxEnable
        {
            get { return model.TextBoxEnable; }
        }
        //stringa per la visibilità del bottone riprova
        public string VisibilityButtonRiprova
        {
            get { return model.VisibilityButtonRiprova; }
        }
        //stringa per la visibilità del bottono avanti
        public string VisibilityButtonAvanti
        {
            get { return model.VisibilityButtonAvanti; }
        }
        public RelayCommand NothingCommand { get; protected set; }
        public RelayCommand RiprovaCommand { get; protected set; }
        public RelayCommand AvantiCommand { get; protected set; }
        #endregion

        #region =================== costruttori ================
        public ApprendimentoViewModel()
        {
            model = new Apprendimento();
            NothingCommand = new RelayCommand(DoNothing);
            RiprovaCommand = new RelayCommand(Riprova);
            AvantiCommand = new RelayCommand(Avanti);
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
        // metodo che aggiorna il cronometro ogni 200 ms
        private void AggiornaCronometro()
        {
            while (true)
            {
                OnPropertyChanged(nameof(Cronometro));
                Thread.Sleep(200);
            }
        }
        // metdo che viene evocato quando si preme sul bottone riprova
        private void Riprova()
        {
            TestoUtente = "";
            OnPropertyChanged(nameof(Stampa));
            model.TextBoxEnable = true;
            OnPropertyChanged(nameof(TextBoxEnable));
            model.VisibilityButtonRiprova = "Collapsed";
            OnPropertyChanged(nameof(VisibilityButtonRiprova));
            model.VisibilityButtonAvanti = "Collapsed";
            OnPropertyChanged(nameof(VisibilityButtonAvanti));
            model.CorrectChar = 0;
            OnPropertyChanged(nameof(CorrectChar));
            model.WrongChar = 0;
            OnPropertyChanged(nameof(WrongChar));
            model.PercChar = 0;
            OnPropertyChanged(nameof(PercChar));
        }
        // metdo che viene evocato quando si preme sul bottone avanti
        private void Avanti()
        {
            //da fare
        }
        #endregion

        #region =================== metodi generali ============
        #endregion

    }
}
