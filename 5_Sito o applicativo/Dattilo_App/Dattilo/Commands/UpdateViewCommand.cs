using Dattilo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Dattilo.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Apprendimento")
            {
                viewModel.SelectedViewModel = new ApprendimentoViewModel();
            }
            else if (parameter.ToString() == "Dettatura")
            {
                viewModel.SelectedViewModel = new DettaturaViewModel();
            }
        }
    }
}
