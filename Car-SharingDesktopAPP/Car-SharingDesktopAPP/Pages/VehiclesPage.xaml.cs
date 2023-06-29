using Car_SharingDesktopAPP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
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
    public partial class VehiclesPage : Page
    {
        public ObservableCollection<Vehicle> Vehicles { get; set; }

        public VehiclesPage()
        {
            InitializeComponent();
            using (var db = new CarSharingDBContext())
            {
                Vehicles = new ObservableCollection<Vehicle>(db.Vehicles.ToList());
            }
            OnPropertyChanged("Vehicles");
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void DeleteVehicleButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if(button != null)
            {
               var vehicle = button.DataContext as Vehicle;
               if(vehicle != null)
               {
                    MessageBoxResult messageBoxResult = MessageBox.Show($"Czy na pewno chcesz usunąć pojazd [{vehicle.Id}] {vehicle.Brand} {vehicle.Model}?", "Potwierdzenie usunięcia pojazdu!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if(messageBoxResult == MessageBoxResult.Yes)
                    {
                        using (var db = new CarSharingDBContext())
                        {
                            db.Vehicles.Remove(vehicle);
                            db.SaveChanges();                            
                            OnPropertyChanged("Vehicles");
                        }
                        Vehicles.Remove(vehicle);
                    }   
               } else
               {
                    Trace.WriteLine("Veh is null");
               }
            }
        }

        private void AddVehicleButton_Click(object sender, RoutedEventArgs e)
        {
            AddVehiclePage addVehiclePage = new AddVehiclePage();
            NavigationService.Navigate(addVehiclePage);
        }

        private void EditVehicleButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var vehicle = button.DataContext as Vehicle;
            AddVehiclePage addVehiclePage = new AddVehiclePage(vehicle);
            NavigationService.Navigate(addVehiclePage);
        }

        private void RefreshVehicleButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshVehicles();
        }

        public void RefreshVehicles()
        {
            using (var db = new CarSharingDBContext())
            {
                Vehicles = new ObservableCollection<Vehicle>(db.Vehicles.ToList());
            }
            OnPropertyChanged("Vehicles");
            VehicleDataGrid.ItemsSource = Vehicles;
        }
    }
}
