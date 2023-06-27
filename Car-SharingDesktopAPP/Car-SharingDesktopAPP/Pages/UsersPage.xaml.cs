using Car_SharingDesktopAPP.Models;
using Car_SharingDesktopAPP.Pages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Car_SharingDesktopAPP
{
    /// <summary>
    /// Logika interakcji dla klasy UsersPage.xaml
    /// </summary>
    /// 

    public partial class UsersPage : Page
    {
        public ObservableCollection<User> Users { get; set; }

        public UsersPage()
        {
            InitializeComponent();
            using (var db = new CarSharingDBContext())
            {
                Users = new ObservableCollection<User>(db.Users.ToList());
            }
            OnPropertyChanged("Users");
            DataContext = this;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new CarSharingDBContext())
            {
                if (!string.IsNullOrEmpty(SearchBox.Text))
                {
                    var filteredUsers = db.Users.Where(u => u.FirstName.ToLower().Contains(SearchBox.Text.ToLower()) || 
                    u.LastName.ToLower().Contains(SearchBox.Text.ToLower()) || 
                    u.Email.ToLower().Contains(SearchBox.Text.ToLower()) || 
                    u.PhoneNumber.ToLower().Contains(SearchBox.Text.ToLower())).ToList();
                    Users = new ObservableCollection<User>(filteredUsers);
                }
                else
                {
                    Users = new ObservableCollection<User>(db.Users.ToList());
                }
                OnPropertyChanged("Users");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            AddUserPage addUserPage = new AddUserPage();
            NavigationService.Navigate(addUserPage);
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var user = button.DataContext as User;
                if (user != null)
                {
                    MessageBoxResult result = MessageBox.Show("Czy na pewno chcesz usunąć użytkownika?", "Potwierdzenie usunięcia użytkownika", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        using (var db = new CarSharingDBContext())
                        {
                            db.Users.Remove(user);
                            db.SaveChanges();
                        }
                        Users.Remove(user);
                    }
                }
            }
        }

        private void RefreshUsersButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshUsersList();
        }

        public void RefreshUsersList()
        {
            using (var db = new CarSharingDBContext())
            {
                Users = new ObservableCollection<User>(db.Users.ToList());
            }
            OnPropertyChanged("Users");
            UserDataGrid.ItemsSource = Users;
        }
    }
}
