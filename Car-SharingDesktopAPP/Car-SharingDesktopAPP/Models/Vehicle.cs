using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_SharingDesktopAPP.Models
{
    internal class Vehicle
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string RegistrationNumber { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public VehicleType VehicleType { get; set; }
        public FuelType FuelType { get; set; }
        public AvailableCities CurrentCity { get; set; }
        public CleanStatus CleanStatus { get; set; }
        public FuelStatus FuelStatus { get; set; }
        public bool IsAvailable { get; set; }
        
        public Vehicle(int id, string brand, string model, string registrationNumber, int year, string color, VehicleType vehicleType, FuelType fuelType, AvailableCities currentCity, 
            CleanStatus cleanStatus, FuelStatus fuelStatus, bool isAvailable)
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
            FuelStatus = fuelStatus;
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

public enum FuelStatus
{
    Fueled,
    ToRefuel
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
    Sandomierz = 5
}

public enum FuelType
{
    Gasoline,
    Diesel,
    LPG,
    Hybrid,
    Electric
}
