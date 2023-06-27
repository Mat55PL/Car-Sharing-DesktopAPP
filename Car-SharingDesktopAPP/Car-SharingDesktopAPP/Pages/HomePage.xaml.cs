using Car_SharingDesktopAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
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
    /// Logika interakcji dla klasy HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private CarSharingDBContext carSharingDBContext;
        public HomePage()
        {
            InitializeComponent();
            carSharingDBContext = new CarSharingDBContext();
            DateText.Text = DateTime.Now.ToString("dd/MM/yyyy");
            CountVehicles();
            CountUsers();
        }

        private void CountVehicles()
        {
            int vehiclesCount = carSharingDBContext.Vehicles.Count();
            VehicleCountText.Text = vehiclesCount.ToString();
            int unavailableVehCount = carSharingDBContext.Vehicles.Where(v => v.IsAvailable == false).Count();
            UnavailableVehicleCountText.Text = unavailableVehCount.ToString();
        }

        private void CountUsers()
        {
            int usersCount = carSharingDBContext.Users.Count();
            UserCountText.Text = usersCount.ToString();
        }
    }
}
