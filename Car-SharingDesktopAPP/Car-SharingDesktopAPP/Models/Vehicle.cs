using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Car_SharingDesktopAPP.Models
{
    internal class Vehicle
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Marka pojazdu jest wymagana!")]
        [StringLength(50)]
        public string Brand { get; set; }
        [Required]
        [StringLength(50)]
        public string Model { get; set; }
        [Required(ErrorMessage = "Numer rejestracyjny jest wymagany!")]
        [StringLength(10, ErrorMessage = "Numer rejestracyjny nie może być dłuższy niż 10. znaków")]
        public string RegistrationNumber { get; set; }
        [Required(ErrorMessage = "Podanie roku produkacji pojazdu jest wymagane!")]
        [Range(1900, 2030)]
        public int Year { get; set; }
        [Required(ErrorMessage = "Podanie koloru pojazdu jest wymagane!")]
        [StringLength(50)]
        public string Color { get; set; }
        [Required(ErrorMessage = "Nie podano typu pojazdu!")]
        public VehicleType VehicleType { get; set; }
        [Required(ErrorMessage = "Nie podano typu paliwa dla nowego pojazdu!")]
        public FuelType FuelType { get; set; }
        [Required(ErrorMessage = "Nie podano aktualnej miejscowości pojazdu!")]
        public AvailableCities CurrentCity { get; set; }
        [Required(ErrorMessage = "Nie podano aktualnego statusu czystości pojazdu")]
        public CleanStatus CleanStatus { get; set; }
        [Range(1, 100, ErrorMessage = "Przedział % paliwa wynosi od 1 do 100%")]
        public float FuelLevel { get; set; }
        public bool IsAvailable { get; set; }
        
        public Vehicle(int id, string brand, string model, string registrationNumber, int year, string color, 
            VehicleType vehicleType, FuelType fuelType, AvailableCities currentCity, 
            CleanStatus cleanStatus, float fuelLevel, bool isAvailable)
        {
            Id = id;
            Brand = brand;
            Model = model;
            RegistrationNumber = registrationNumber;
            Year = year;
            Color = color;
            VehicleType = vehicleType;
            FuelType = fuelType;
            CurrentCity = currentCity;
            CleanStatus = cleanStatus;
            FuelLevel = fuelLevel;
            IsAvailable = isAvailable;
        }

        public Vehicle() {}
    }
}

public enum CleanStatus
{
    Clean,
    LightDirty,
    Dirty
}

public enum VehicleType
{
    Car,
    Van
}

public enum AvailableCities
{
    Rzeszow = 0,
    Krakow = 1,
    Lublin = 2,
    Tarnobrzeg = 3,
    Tarnow = 4,
    Sandomierz = 5,
    Łańcut = 6
}

public enum FuelType
{
    Gasoline,
    Diesel,
    LPG,
    Hybrid,
    Electric
}
