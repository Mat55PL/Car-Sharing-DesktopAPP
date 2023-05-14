using MaterialDesignThemes.Wpf.Converters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_SharingDesktopAPP.Models
{
    internal class VehicleDBContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CarSharingDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle
                {
                    Id = 1,
                    Brand = "Skoda",
                    Model = "Fabia",
                    RegistrationNumber = "RZ2345",
                    IsAvailable = true,
                    Year = 2015,
                    Color = "Czarny",
                    VehicleType = VehicleType.Car,
                    FuelType = FuelType.Diesel,
                    CurrentCity = AvailableCities.Rzeszow,
                    CleanStatus = CleanStatus.Clean,
                    FuelLevel = 100
                },
                new Vehicle
                {
                    Id = 2,
                    Brand = "Seat",
                    Model = "Leon",
                    RegistrationNumber = "RZ3456",
                    IsAvailable = true,
                    Year = 2018,
                    Color = "Czerwony",
                    VehicleType = VehicleType.Car,
                    FuelType = FuelType.LPG,
                    CurrentCity = AvailableCities.Rzeszow,
                    CleanStatus = CleanStatus.Dirty,
                    FuelLevel = 100
                }
            );
        }
    }
}
