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
        private const int LIVELLO_MASSIMO = 0;
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
        //numero del livello corrente
        public int NLivello
        {
            get { return model.NLivello; }
            set
            {
                if (model.NLivello == value)
                    return;
                model.NLivello = value;
                OnPropertyChanged(nameof(NLivello));
            }
        }
        //stampa del array di caratteri
        public String Stampa
        {
            get { return model.StampaLivello(); }            
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
                OnPropertyChanged(nameof(CorrectCar));
                OnPropertyChanged(nameof(WrongCar));
                OnPropertyChanged(nameof(PercCar));
                OnPropertyChanged(nameof(TextBoxAttivo));
                OnPropertyChanged(nameof(VisibilitaPulsanteRiprova));
                OnPropertyChanged(nameof(VisibilitaPulsanteAvanti));
                OnPropertyChanged(nameof(VisibilitaPulsantePrecedente));
            }
        }
        //numero di giusti sbagliati scritti dall'utente
        public int CorrectCar
        {
            get { return model.CorrectCar; }
            set 
            {
                if (model.CorrectCar == value)
                    return;
                model.CorrectCar = value;
                OnPropertyChanged(nameof(CorrectCar));
            }
        }
        //numero di carattetri sbagliati scritti dall'utente
        public int WrongCar
        {
            get { return model.WrongCar; }
            set
            {
                if (model.WrongCar == value)
                    return;
                model.WrongCar = value;
                OnPropertyChanged(nameof(WrongCar));
            }
        }
        //percentuale di caratteri giusti
        public double PercCar
        {
            get { return model.PercCar; }
            set
            {
                if (model.PercCar == value)
                    return;
                model.PercCar = value;
                OnPropertyChanged(nameof(PercCar));
            }
        }
        //stringa per stampare il cronometro che viene calcolato nel model
        public string Cronometro
        {
            get { return model.ConvertToSM(); }
        }
        //variabile per abilitare il textbox
        public bool TextBoxAttivo
        {
            get { return model.TextBoxAttivo; }
            set
            {
                if (model.TextBoxAttivo == value)
                    return;
                model.TextBoxAttivo = value;
                OnPropertyChanged(nameof(TextBoxAttivo));
            }
        }
        //stringa per la visibilità del bottone riprova
        public string VisibilitaPulsanteRiprova
        {
            get { return model.VisibilitaPulsanteRiprova; }
            set
            {
                if (model.VisibilitaPulsanteRiprova == value)
                    return;
                else if (value == "Collapsed" || value == "Visible")
                    model.VisibilitaPulsanteRiprova = value;
                else
                    model.VisibilitaPulsanteRiprova = "Collapsed";
                OnPropertyChanged(nameof(VisibilitaPulsanteRiprova));
            }
        }
        //stringa per la visibilità del bottono avanti
        public string VisibilitaPulsanteAvanti
        {
            get { return model.VisibilitaPulsanteAvanti; }
            set
            {
                if (model.VisibilitaPulsanteAvanti == value)
                    return;
                else if (value == "Collapsed" || value == "Visible")
                    model.VisibilitaPulsanteAvanti = value;
                else
                    model.VisibilitaPulsanteAvanti = "Collapsed";
                OnPropertyChanged(nameof(VisibilitaPulsanteAvanti));
            }
        }
        //stringa con il numero del livello
        public string StringaLivello
        {
            get { return model.StringaLivello(); }
        }
        //stringa per la visibilità del bottono precedente
        public string VisibilitaPulsantePrecedente
        {
            get { return model.VisibilitaPulsantePrecedente; }
            set
            {
                if (model.VisibilitaPulsantePrecedente == value)
                    return;
                else if (value == "Collapsed" || value == "Visible")
                    model.VisibilitaPulsantePrecedente = value;
                else
                    model.VisibilitaPulsantePrecedente = "Collapsed";
                OnPropertyChanged(nameof(VisibilitaPulsantePrecedente));
            }
        }
        public RelayCommand NothingCommand { get; set; }
        public RelayCommand RiprovaCommand { get; set; }
        public RelayCommand AvantiCommand { get; set; }
        public RelayCommand PrecedenteCommand { get; set; }
        #endregion

        #region =================== costruttori ================
        public ApprendimentoViewModel()
        {
            model = new Apprendimento();
            NothingCommand = new RelayCommand(DoNothing);
            RiprovaCommand = new RelayCommand(Riprova);
            AvantiCommand = new RelayCommand(Avanti);
            PrecedenteCommand = new RelayCommand(Precedente);
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
        // metodo che viene evocato quando si preme sul bottone riprova
        private void Riprova()
        {
            TestoUtente = "";
            TextBoxAttivo = true;
            VisibilitaPulsanteRiprova = "Collapsed";
            VisibilitaPulsanteAvanti = "Collapsed";            
            CorrectCar = 0;
            WrongCar = 0;
            PercCar = 0;
            model.Cronometro = 0;
            OnPropertyChanged(nameof(NLivello));
            OnPropertyChanged(nameof(Stampa));
        }
        // metodo che viene evocato quando si preme sul bottone avanti
        private void Avanti()
        {
            NLivello++;
            Riprova();
        }
        // metodo che viene evocato quando si preme sul bottone precedente
        private void Precedente()
        {
            NLivello--;
            Riprova();
        }
        #endregion

        #region =================== metodi generali ============
        #endregion

    }
}
