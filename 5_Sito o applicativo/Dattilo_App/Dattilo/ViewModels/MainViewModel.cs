using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dattilo.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private ObservableObject _selectedViewModel;

        public ObservableObject SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
        public IRelayCommand<string> UpdateViewCommand { get; set; }

        public MainViewModel()
        {
            //_selectedViewModel = new MainViewModel();
            UpdateViewCommand = new RelayCommand<string>(OnUpdate);
        }

        private void OnUpdate(string? obj)
        {
            string vm = obj ?? "Menu";
            if (vm == "Apprendimento")
                SelectedViewModel = new ApprendimentoViewModel();
            else if(vm == "Dettatura")
                SelectedViewModel = new DettaturaViewModel();
            else
                SelectedViewModel = new MenuViewModel();
        }
    }
}