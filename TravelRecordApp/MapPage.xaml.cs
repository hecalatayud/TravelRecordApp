using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);

            if (status != PermissionStatus.Granted)
                status = (await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location))[Permission.Location];

            if (status != PermissionStatus.Granted)
            {
                await DisplayAlert("Location permission denied", "Could not continue, please try again", "OK");

                return;
            }

            LocationsMap.IsShowingUser = true;

            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();

            LocationsMap.MoveToRegion(new MapSpan(new Position(position.Latitude, position.Longitude), 2, 2));

            foreach (var post in Post.Read())
                LocationsMap.Pins.Add(new Pin
                {
                    Type = PinType.SavedPin,
                    Position = new Position(post.Latitude, post.Longitude),
                    Label = post.VenueName,
                    Address = post.Address
                });


            if (locator.IsListening)
                return;

            locator.PositionChanged += Locator_PositionChanged;
            await locator.StartListeningAsync(TimeSpan.Zero, 10);
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();

            var locator = CrossGeolocator.Current;

            if (!locator.IsListening)
                return;

            locator.PositionChanged -= Locator_PositionChanged;
            await locator.StopListeningAsync();
        }

        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e) => LocationsMap.MoveToRegion(new MapSpan(new Position(e.Position.Latitude, e.Position.Longitude), 2, 2));
    }
}