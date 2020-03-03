using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TravelRecordApp.ViewModel.Commands
{
    public class NavigationCommand : ICommand
    {
        private readonly HomeViewModel _viewModel;

        public event EventHandler CanExecuteChanged;

        public NavigationCommand(HomeViewModel viewModel) => _viewModel = viewModel;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => _viewModel.Navigate();
    }
}
