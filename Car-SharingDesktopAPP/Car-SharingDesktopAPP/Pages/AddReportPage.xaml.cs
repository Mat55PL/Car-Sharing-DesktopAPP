using System;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Controls;
using Car_SharingDesktopAPP.Models;

namespace Car_SharingDesktopAPP.Pages;

public partial class AddReportPage : Page
{
    private Report? _report;
    public AddReportPage(Report? report = null)
    {
        InitializeComponent();
        _report = report ?? new Report();
        DataContext = _report;
    }
    
    private void SaveReportButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            _report.ReportTitle = ReportTitleBox.Text;
            _report.ReportDescription = ReportDescriptionBox.Text;
            _report.ReportDate = DateReportPicker.SelectedDate ?? DateTime.Now;
            _report.ReportStatus = (ReportStatus)StatusComboBox.SelectedIndex;
            
            Validator.ValidateObject(_report, new ValidationContext(_report), true);
            using(var db = new CarSharingDBContext())
            {
                if (_report.Id == 0)
                {
                    db.Reports.Add(_report);
                }
                else
                {
                    db.Reports.Update(_report);
                }
                db.SaveChanges();
            }
            MessageBox.Show("Zgłoszenie zostało zapisane.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.GoBack();
        }
        catch (ValidationException validationException)
        {
            MessageBox.Show(validationException.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        catch (Exception exception)
        {
            MessageBox.Show("Wystąpił błąd: "+ exception.Message);
        }
    }
}