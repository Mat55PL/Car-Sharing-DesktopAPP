using System;
using System.Collections.Generic;
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
using MaterialDesignThemes.Wpf;
using System.Diagnostics;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Car_SharingDesktopAPP
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public bool IsDarkTheme { get; set; }
        private readonly PaletteHelper paletteHelper = new PaletteHelper();
        //db connect var
        private static string ConnectionString = (string)DBManager.GetConnectionString();
        MySqlConnection con;
        MySqlCommand command;
        MySqlDataReader reader;
        private void ThemeToggle_Click(object sender, RoutedEventArgs e)
        {
            ITheme theme = paletteHelper.GetTheme();
            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
            }
            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
            }
            paletteHelper.SetTheme(theme);
        }

        private void ExitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con = new MySqlConnection(ConnectionString);
                con.Open();
                command = new MySqlCommand("Select * From users WHERE login = @Login", con);
                command.Parameters.AddWithValue("@Login", textUsername.Text.ToString());
                reader = command.ExecuteReader();
                if(reader.Read())
                {
                    string password = reader["password"].ToString();
                    if(password == textPassword.Password)
                    {
                        MessageBox.Show("Zalogowano pomyślnie!");
                        UserPanel userPanel = new UserPanel();
                        userPanel.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Nieprawidłowe hasło!");
                    }
                }
                else
                {
                    MessageBox.Show("Nie znaleziono użytkownika o podanej nazwie!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd " + ex.Message);
            }
            finally
            {
                if(con != null)
                    con.Close();

                reader.Close();
            }
        }
    }
}
