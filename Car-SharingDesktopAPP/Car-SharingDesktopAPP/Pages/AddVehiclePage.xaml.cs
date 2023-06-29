using Car_SharingDesktopAPP.Models;
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
    /// Logika interakcji dla klasy AddVehiclePage.xaml
    /// </summary>
    public partial class AddVehiclePage : Page
    {
        private Vehicle? _vehicle;
        public AddVehiclePage(Vehicle? vehicle = null)
        {
            InitializeComponent();
            _vehicle = vehicle ?? new Vehicle();
            DataContext = _vehicle;
        }

        private void SaveVehButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _vehicle.Brand = BrandTextBox.Text;
                _vehicle.Model = ModelTextBox.Text;
                _vehicle.RegistrationNumber = RegistrationNumberTextBox.Text;
                _vehicle.Year = Int32.Parse(YearVehTextBox.Text);
                _vehicle.Color = ColorTextBox.Text;
                _vehicle.VehicleType = (VehicleType)VehTypeComboBox.SelectedIndex;
                _vehicle.FuelType = (FuelType)VehPetrolComboBox.SelectedIndex;
                _vehicle.CurrentCity = (AvailableCities)CurrentCityComboBox.SelectedIndex;
                _vehicle.CleanStatus = (CleanStatus)CleanStatusComboBox.SelectedIndex;
                _vehicle.FuelLevel = Int32.Parse(FuelLevelTextBox.Text);
                _vehicle.IsAvailable = IsAvailableCheckBox.IsChecked ?? false;

                Validator.ValidateObject(_vehicle, new ValidationContext(_vehicle), true);
                using (var db = new CarSharingDBContext())
                {
                    if(_vehicle.Id == 0)
                    {
                        db.Vehicles.Add(_vehicle);
                    }
                    else
                    {
                        db.Vehicles.Update(_vehicle);
                    }
                    db.SaveChanges();
                }

                MessageBox.Show("Pojazd został dodany do bazy danych", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
            }
            catch(ValidationException Ve)
            {
                MessageBox.Show("Wystąpił błąd walidacji: " + Ve.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Wystąpił nieznany błąd: " + ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
