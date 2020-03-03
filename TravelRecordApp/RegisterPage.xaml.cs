using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        private readonly User _user;

        public RegisterPage()
        {
            InitializeComponent();

            _user = new User();
            ContainerStackLayout.BindingContext = _user;
        }

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            if (PasswordEntry.Text != ConfirmPasswordEntry.Text)
            {
                DisplayAlert("Error", "Passwords do not match", "OK");

                return;
            }

            if (User.Insert(_user) > 0)
                DisplayAlert("Success", "User successfully registered", "OK");
            else
                DisplayAlert("Failure", "User failed to be registered", "OK");

        }
    }
}