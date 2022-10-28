using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Dattilo.Models;

namespace Dattilo.ViewModels
{
    public class ApprendimentoViewModel : ObservableObject
    {
        #region =================== costanti ===================
        #endregion

        #region =================== membri statici =============
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
                //model.cambiaLunghezzaCharLivello();
                OnPropertyChanged(nameof(Stampa));
            }
        }        
        //stampa del array di caratteri
        public String Stampa
        {
            get 
            {
                model.generaLivello();
                return model.stampaLivello(); 
            }
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
                model.confrontaChar();
                OnPropertyChanged(nameof(TestoUtente));
                OnPropertyChanged(nameof(CorrectChar));
                OnPropertyChanged(nameof(WrongChar));
            }
        }
        //numero di giusti sbagliati scritti dall'utente
        public int CorrectChar
        {
            get { return model.CorrectChar; }
            set
            {
                if (model.CorrectChar == value)
                    return;
                model.CorrectChar = value;
            }
        }
        //numero di carattetri sbagliati scritti dall'utente
        public int WrongChar
        {
            get { return model.WrongChar; }
            set
            {
                if (model.WrongChar == value)
                    return;
                model.WrongChar = value;
            }
        }

        #endregion

        #region =================== costruttori ================
        public ApprendimentoViewModel()
        {
            model = new Apprendimento();
        }
        #endregion

        #region =================== metodi privati e aiuto =====
        #endregion

        #region =================== metodi generali ============
        #endregion

    }
}
