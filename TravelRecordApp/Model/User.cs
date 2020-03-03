using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using SQLite;
using TravelRecordApp.Annotations;

namespace TravelRecordApp.Model
{
    public class User : INotifyPropertyChanged
    {
        private int _id;
        private string _email;
        private string _password;

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

        public string Email
        {
            get => _email;
            set
            {
                _email = value;

                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;

                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static int Insert(User user)
        {
            int rows;

            using (var connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<User>();
                rows = connection.Insert(user);
            }

            return rows;
        }

        public static bool Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return false;

            User user;

            using (var connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<User>();
                user = connection.Table<User>().FirstOrDefault(u => u.Email == email);
            }

            if (user == null || password != user.Password)
                return false;

            App.User = user;

            return true;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
