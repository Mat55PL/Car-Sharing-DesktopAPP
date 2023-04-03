using Car_SharingDesktopAPP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Logika interakcji dla klasy VehiclesPage.xaml
    /// </summary>
    public partial class VehiclesPage : Page
    {
        private List<Vehicle> _vehicles;
        public List<Vehicle> Vehicles
        {
            get { return _vehicles; }
            set
            {
                _vehicles = value;
                OnPropertyChanged(nameof(Vehicles));
            }
        }
        public VehiclesPage()
        {
            InitializeComponent();
            Vehicles = new List<Vehicle>
            {
                new Vehicle {Id = 1, Brand = "Toyota", Model = "Corolla", RegistrationNumber = "KRK 12345", Year = 2020, Color = "Red", VehicleType = VehicleType.Car, FuelType = FuelType.Gasoline, 
                    CurrentCity = AvailableCities.Rzeszow, CleanStatus = CleanStatus.Clean, FuelStatus = FuelStatus.Fueled, IsAvailable = true},
                new Vehicle {Id = 3, Brand = "Fiat", Model = "Ducato", RegistrationNumber = "LBN 67890", Year = 2019, Color = "White", VehicleType = VehicleType.Van, FuelType = FuelType.Diesel, 
                    CurrentCity = AvailableCities.Lublin, CleanStatus = CleanStatus.Dirty, FuelStatus = FuelStatus.Fueled, IsAvailable = false},
                new Vehicle {Id = 4, Brand = "Tesla", Model = "Model S", RegistrationNumber = "TAR 24680", Year = 2022, Color = "Black", VehicleType = VehicleType.Car, FuelType = FuelType.Electric, 
                    CurrentCity = AvailableCities.Tarnow, CleanStatus = CleanStatus.Clean, FuelStatus = FuelStatus.ToRefuel, IsAvailable = true}
            };
        }
    }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
