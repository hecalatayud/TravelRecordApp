using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            IconImage.Source = ImageSource.FromResource("TravelRecordApp.Assets.Images.plane.png", GetType());
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            if (!User.Login(EmailEntry.Text, PasswordEntry.Text))
                DisplayAlert("Error", "Email or password are incorrect", "OK");
            else
                Navigation.PushAsync(new HomePage());
        }

        private void RegisterButton_Clicked(object sender, EventArgs e) => Navigation.PushAsync(new RegisterPage());
    }
}
