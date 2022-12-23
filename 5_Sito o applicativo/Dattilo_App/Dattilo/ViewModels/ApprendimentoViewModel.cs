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
        public Thread thread;
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
                OnPropertyChanged(nameof(Velocita));
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
        //
        public double Velocita
        {
            get { return model.Velocita; }
            set
            {
                if (model.Velocita == value)
                    return;
                model.Velocita = value;
                OnPropertyChanged(nameof(Velocita));
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
        //stringa per le visibilità dei pulsanti
        public string VisibilitaPulsanteRiprova
        {
            get { return model.VisibilitaPulsanteRiprova; }
            set
            {
                if (model.VisibilitaPulsanteRiprova == value)
                    return;
                model.VisibilitaPulsanteRiprova = value;
                OnPropertyChanged(nameof(VisibilitaPulsanteRiprova));
            }
        }
        public string VisibilitaPulsanteAvanti
        {
            get { return model.VisibilitaPulsanteAvanti; }
            set
            {
                if (model.VisibilitaPulsanteAvanti == value)
                    return;
                model.VisibilitaPulsanteAvanti = value;
                OnPropertyChanged(nameof(VisibilitaPulsanteAvanti));
            }
        }
        public string VisibilitaPulsantePrecedente
        {
            get { return model.VisibilitaPulsantePrecedente; }
            set
            {
                if (model.VisibilitaPulsantePrecedente == value)
                    return;
                model.VisibilitaPulsantePrecedente = value;
                OnPropertyChanged(nameof(VisibilitaPulsantePrecedente));
            }
        }
        public string VisibilitaCaratteriGenerati
        {
            get { return model.VisibilitaCaratteriGenerati; }
            set
            {
                if (model.VisibilitaCaratteriGenerati == value)
                    return;
                model.VisibilitaCaratteriGenerati = value;
                OnPropertyChanged(nameof(VisibilitaCaratteriGenerati));
            }
        }
        public string VisibilitaStringaLivello
        {
            get { return model.VisibilitaStringaLivello; }
            set
            {
                if (model.VisibilitaStringaLivello == value)
                    return;
                model.VisibilitaStringaLivello = value;
                OnPropertyChanged(nameof(VisibilitaStringaLivello));
            }
        }
        public string VisibilitaTextBox
        {
            get { return model.VisibilitaTextBox; }
            set
            {
                if (model.VisibilitaTextBox == value)
                    return;
                model.VisibilitaTextBox = value;
                OnPropertyChanged(nameof(VisibilitaTextBox));
            }
        }
        public string VisibilitaPulsanteInizia
        {
            get { return model.VisibilitaPulsanteInizia; }
            set
            {
                if (model.VisibilitaPulsanteInizia == value)
                    return;
                model.VisibilitaPulsanteInizia = value;
                OnPropertyChanged(nameof(VisibilitaPulsanteInizia));
            }
        }
        public string VisibilitaCaratteri
        {
            get { return model.VisibilitaCaratteri; }
            set
            {
                if (model.VisibilitaCaratteri == value)
                    return;
                model.VisibilitaCaratteri = value;
                OnPropertyChanged(nameof(VisibilitaCaratteri));
            }
        }
        //stringa con il numero del livello
        public string StringaLivello
        {
            get { return model.StringaLivello(); }
        }
        public RelayCommand NothingCommand { get; set; }
        public RelayCommand RiprovaCommand { get; set; }
        public RelayCommand AvantiCommand { get; set; }
        public RelayCommand PrecedenteCommand { get; set; }
        public RelayCommand IniziaCommand { get; set; }
        #endregion

        #region =================== costruttori ================
        public ApprendimentoViewModel()
        {
            model = new Apprendimento();
            NothingCommand = new RelayCommand(BloccaTasto);
            RiprovaCommand = new RelayCommand(Riprova);
            AvantiCommand = new RelayCommand(Avanti);
            IniziaCommand = new RelayCommand(Inizia);
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
        private void BloccaTasto()
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
        // metodo che viene invocato quando si preme sul pulsante riprova
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
            OnPropertyChanged(nameof(VisibilitaPulsantePrecedente));
            OnPropertyChanged(nameof(StringaLivello));
        }
        // metodo che viene invocato quando si preme sul pulsante avanti
        private void Avanti()
        {
            NLivello++;
            Riprova();
        }
        // metodo che viene invocato quando si preme sul pulsante precedente
        private void Precedente()
        {
            NLivello--;
            Riprova();       
        }
        // metodo che viene invocato quando si preme sul pulsante inizia
        private void Inizia()
        {
            model.Cronometro = 0;
            VisibilitaPulsanteInizia = "Collapsed";
            VisibilitaCaratteri = "Collapsed";
            VisibilitaCaratteriGenerati = "Visible";
            VisibilitaStringaLivello = "Visible";
            VisibilitaTextBox = "Visible";
        }

        #endregion

        #region =================== metodi generali ============
        #endregion

    }
}
