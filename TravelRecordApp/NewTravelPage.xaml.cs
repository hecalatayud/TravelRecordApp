using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTravelPage : ContentPage
    {
        private readonly Post _post;

        public NewTravelPage()
        {
            InitializeComponent();

            _post = new Post();
            ContainerStackLayout.BindingContext = _post;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var position = await CrossGeolocator.Current.GetPositionAsync();

            VenuesListView.ItemsSource = await Venue.GetVenuesAsync(position.Latitude, position.Longitude);
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var selectedItem = (Venue)VenuesListView.SelectedItem;
            var category = selectedItem.Categories.FirstOrDefault();

            _post.VenueName = selectedItem.Name;
            _post.CategoryId = category?.Id;
            _post.CategoryName = category?.Name;
            _post.Address = selectedItem.Location.Address;
            _post.Latitude = selectedItem.Location.Lat;
            _post.Longitude = selectedItem.Location.Lng;
            _post.Distance = selectedItem.Location.Distance;
            _post.UserId = App.User.Id;

            if (Post.Insert(_post) > 0)
                DisplayAlert("Success", "Experience successfully inserted", "OK");
            else
                DisplayAlert("Failure", "Experience failed to be inserted", "OK");
        }
    }
}