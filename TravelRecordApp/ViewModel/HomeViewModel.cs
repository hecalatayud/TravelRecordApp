using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TravelRecordApp.ViewModel.Commands;
using Xamarin.Forms;

namespace TravelRecordApp.ViewModel
{
    public class HomeViewModel
    {
        public ICommand NavigationCommand { get; set; }

        public HomeViewModel() => NavigationCommand = new NavigationCommand(this);

        public void Navigate() => Application.Current.MainPage.Navigation.PushAsync(new NewTravelPage());
    }
}
