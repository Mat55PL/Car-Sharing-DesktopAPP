using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.Infrastructure.Design;
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
using Car_SharingDesktopAPP.Models;

namespace Car_SharingDesktopAPP.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy ReportsPage.xaml
    /// </summary>
    

    public partial class ReportsPage : Page
    {
        public ObservableCollection<Report> Reports { get; set; }
        public ReportsPage()
        {
            InitializeComponent();
            SetReportsList();
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        private void SetReportsList()
        {
            using (var db = new CarSharingDBContext())
            {
                Reports = new ObservableCollection<Report>(db.Reports.ToList());
            }
            OnPropertyChanged("Reports");
            DataContext = this;
        }
        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        private void AddReportButton_Click(object sender, RoutedEventArgs e)
        {
            AddReportPage addReportPage = new AddReportPage();
            NavigationService.Navigate(addReportPage);
        }
        
        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            SetReportsList();
            OnPropertyChanged("Reports");
            ReportDataGrid.ItemsSource = Reports;
        }
        
        private void EditReportButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var report = button.DataContext as Report;
            AddReportPage addReportPage = new AddReportPage(report);
            NavigationService.Navigate(addReportPage);
        }
        
        private void DeleteReportButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var report = button.DataContext as Report;
            if (button != null || report != null)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Czy na pewno chcesz usunąć zgłoszenie?", "Potwierdzenie", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    using (var db = new CarSharingDBContext())
                    {
                        db.Reports.Remove(report);
                        db.SaveChanges();
                    }
                    SetReportsList();
                    OnPropertyChanged("Reports");
                    Reports.Remove(report);
                    ReportDataGrid.ItemsSource = Reports;
                }
            }
        }
    }
}
