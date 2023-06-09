﻿using Car_SharingDesktopAPP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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

namespace Car_SharingDesktopAPP.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        public AddUserPage()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Password;
            string phoneNumber = PhoneNumberTextBox.Text;
            bool isDocumentsVerified = DocumentsVerifiedCheckBox.IsChecked ?? false;
            UserRank rank = (UserRank)RankComboBox.SelectedIndex;

            User newUser = new User
            {
                Login = login,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
                PhoneNumber = phoneNumber,
                IsDocumentsVerified = isDocumentsVerified,
                Rank = rank
            };

            try
            {
                Validator.ValidateObject(newUser, new ValidationContext(newUser), true);
                using (var db = new CarSharingDBContext())
                {
                    db.Users.Add(newUser);
                    db.SaveChanges();
                }

                MessageBox.Show("Użytkownik został dodany do bazy danych.");

                NavigationService.GoBack();
                if(NavigationService.Content is UsersPage usersPage)
                {
                    usersPage.RefreshUsersList();
                }
            }
            catch(ValidationException ve)
            {
                MessageBox.Show("Wystąpił błąd walidacji: " + ve.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas dodawania użytkownika: " + ex.Message);
            }

        }
    }
}
