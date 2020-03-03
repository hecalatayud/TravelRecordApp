using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using SQLite;
using TravelRecordApp.Annotations;

namespace TravelRecordApp.Model
{
    public class Post : INotifyPropertyChanged
    {
        private int _id;
        private string _experience;
        private string _venueName;
        private string _categoryId;
        private string _categoryName;
        private string _address;
        private double _latitude;
        private double _longitude;
        private int _distance;
        private int _userId;

        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get => _id;
            set
            {
                _id = value;

                OnPropertyChanged();
            }
        }

        [MaxLength(250)]
        public string Experience
        {
            get => _experience;
            set
            {
                _experience = value;

                OnPropertyChanged();
            }
        }

        public string VenueName
        {
            get => _venueName;
            set
            {
                _venueName = value;

                OnPropertyChanged();
            }
        }

        public string CategoryId
        {
            get => _categoryId;
            set
            {
                _categoryId = value;

                OnPropertyChanged();
            }
        }

        public string CategoryName
        {
            get => _categoryName;
            set
            {
                _categoryName = value;

                OnPropertyChanged();
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                _address = value;

                OnPropertyChanged();
            }
        }

        public double Latitude
        {
            get => _latitude;
            set
            {
                _latitude = value;

                OnPropertyChanged();
            }
        }

        public double Longitude
        {
            get => _longitude;
            set
            {
                _longitude = value;

                OnPropertyChanged();
            }
        }

        public int Distance
        {
            get => _distance;
            set
            {
                _distance = value;

                OnPropertyChanged();
            }
        }

        public int UserId
        {
            get => _userId;
            set
            {
                _userId = value;

                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static int Insert(Post post)
        {
            using (var connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Post>();

                return connection.Insert(post);
            }
        }

        public static IEnumerable<Post> Read()
        {
            using (var connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Post>();

                return connection.Table<Post>().Where(post => post.UserId == App.User.Id).ToList();
            }
        }

        public static IDictionary<string, int> GetPostCategories(IEnumerable<Post> posts) => posts.GroupBy(post => post.CategoryName).ToDictionary(grouping => grouping.Key, grouping => grouping.Count());

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
