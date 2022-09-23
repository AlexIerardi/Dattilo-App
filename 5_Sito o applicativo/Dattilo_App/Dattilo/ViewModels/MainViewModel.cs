using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dattilo.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel = new ApprendimentoViewModel();

        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set { _selectedViewModel = value; }
        }

    }
}
