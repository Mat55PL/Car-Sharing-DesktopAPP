using Car_SharingDesktopAPP.Models;
using System;
using System.Collections.Generic;
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
        private List<User> _users;
        public List<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        public UsersPage()
        {
            InitializeComponent();
            Users = new List<User>
            {
                new User { Id = 1, FirstName = "Test", LastName = "Partyka", Email = "test@wp.pl", Password="Test", PhoneNumber = "789456123", IsDocumentsVerified = true, Rank = UserRank.Owner},
                new User { Id = 2, FirstName = "Mateusz", LastName = "Partyka", Email = "test@gmail.pl", Password="test", PhoneNumber = "587987445", IsDocumentsVerified = false, Rank = UserRank.User}
            };
            DataContext = this;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchBox.Text.ToLower();
            var filteredUsers = Users.Where(u => u.FirstName.ToLower().Contains(searchText)
                                               || u.LastName.ToLower().Contains(searchText)
                                               || u.Email.ToLower().Contains(searchText));
            Users = filteredUsers.ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
