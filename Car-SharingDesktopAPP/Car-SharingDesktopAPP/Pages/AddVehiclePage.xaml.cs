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
        public AddVehiclePage()
        {
            InitializeComponent();
        }

        private void SaveVehButton_Click(object sender, RoutedEventArgs e)
        {
            string brand = BrandTextBox.Text;
            string model = ModelTextBox.Text;
            string registrationNumber = RegistrationNumberTextBox.Text;
            int year = int.Parse(YearVehTextBox.Text);
            string color = ColorTextBox.Text;
            VehicleType type = (VehicleType)VehTypeComboBox.SelectedIndex;
            FuelType fuelType = (FuelType)VehPetrolComboBox.SelectedIndex;
            AvailableCities cities = (AvailableCities)CurrentCityComboBox.SelectedIndex;
            CleanStatus cleanStatus = (CleanStatus)CleanStatusComboBox.SelectedIndex;
            int fuelLevel = int.Parse(FuelLevelTextBox.Text);
            bool isAvailable = IsAvailableCheckBox.IsChecked ?? false;

            Vehicle newVehicle = new Vehicle
            {
                Brand = brand,
                Model = model,
                RegistrationNumber = registrationNumber,
                Year = year,
                Color = color,
                VehicleType = type,
                FuelType = fuelType,
                CurrentCity = cities,
                CleanStatus = cleanStatus,
                FuelLevel = fuelLevel,
                IsAvailable = isAvailable
            };

            try
            {
                Validator.ValidateObject(newVehicle, new ValidationContext(newVehicle), true);
                using (var db = new VehicleDBContext())
                {
                    db.Vehicles.Add(newVehicle);
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
