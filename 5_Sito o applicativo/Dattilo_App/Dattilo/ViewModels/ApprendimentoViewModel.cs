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
                model.cambiaLunghezzaCharLivello();
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
                if (model.confrontaChar())
                    return "diomaiale";
                else
                    return "";
            }
            set 
            {
                if (model.TestoUtente == value)
                    return;
                model.TestoUtente = value;
                OnPropertyChanged(nameof(TestoUtente));
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
