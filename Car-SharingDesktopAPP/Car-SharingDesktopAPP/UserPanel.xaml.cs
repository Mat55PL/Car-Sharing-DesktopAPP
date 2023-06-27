using Car_SharingDesktopAPP.Pages;
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
using System.Windows.Shapes;
using System.Diagnostics;
namespace Car_SharingDesktopAPP
{
    /// <summary>
    /// Logika interakcji dla klasy UserPanel.xaml
    /// </summary>
    public partial class UserPanel : Window
    {
        private SettingsPage? _settignsPage;
        private HomePage? _homePage;
        private VehiclesPage? _vehiclesPage;
        private UsersPage? _usersPage;
        private MapPage? _mapPage;
        private RentalPage? _rentalPage;
        private ReportsPage? _reportsPage;
        public UserPanel()
        {
            InitializeComponent();
            if (_homePage == null)
            {
                _homePage = new HomePage();
            }
            PageFrame.Navigate(_homePage);
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            if(_usersPage == null)
            {
                _usersPage = new UsersPage();
            }
            PageFrame.Navigate(_usersPage);
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            if(_homePage == null)
            {
                _homePage = new HomePage();
            }
            PageFrame.Navigate(_homePage);
        }

        private void VehicleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Width = 1400;
            if (_vehiclesPage == null)
            {
                _vehiclesPage = new VehiclesPage();
            }
            PageFrame.Width = 1200;
            PageFrame.Navigate(_vehiclesPage);
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            if(_settignsPage == null)
            {
                _settignsPage = new SettingsPage();
            }
            PageFrame.Navigate(_settignsPage);
        }

        private void MapButton_Click(object sender, RoutedEventArgs e)
        {
            if(_mapPage == null)
            {
                _mapPage = new MapPage();
            }
            PageFrame.Navigate(_mapPage);
        }

        private void RentalButton_Click(object sender, RoutedEventArgs e)
        {
            if (_rentalPage == null)
            {
                _rentalPage = new RentalPage();
            }
            PageFrame.Navigate(_rentalPage);
        }

        private void ReportsButton_Click(object sender, RoutedEventArgs e)
        {
            if(_reportsPage == null)
            {
                _reportsPage = new ReportsPage();
            }
            PageFrame.Navigate(_reportsPage);
        }
    }
}
