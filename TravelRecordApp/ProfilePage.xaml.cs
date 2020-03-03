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
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (var connection = new SQLiteConnection(App.DatabasePath))
            {
                var posts = Post.Read().ToList();

                PostCountLabel.Text = posts.Count.ToString();
                CategoriesListView.ItemsSource = Post.GetPostCategories(posts);
            }
        }
    }
}