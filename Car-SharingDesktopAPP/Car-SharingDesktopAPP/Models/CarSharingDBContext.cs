using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_SharingDesktopAPP.Models
{
    public class CarSharingDBContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Report> Reports { get; set; }
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
            
            modelBuilder.Entity<Report>().ToTable("Reports");

            modelBuilder.Entity<Report>().HasData(
                new Report()
                {
                    Id = 1,
                    ReportTitle = "Zepsuty samochód",
                    ReportDescription = "Samochód nie odpala, czerwona kontrolka na desce rozdzielczej",
                    ReportDate = DateTime.Now - TimeSpan.FromDays(5),
                    ReportStatus = ReportStatus.New
                },
                new Report()
                {
                    Id = 2,
                    ReportTitle = "Uszkodzone radio",
                    ReportDescription = "Radio nie działa, nie można włączyć radia",
                    ReportDate = DateTime.Now - TimeSpan.FromDays(10),
                    ReportStatus = ReportStatus.InProgress
                }
            );
            
            modelBuilder.Entity<User>().HasData(
               new User
               {
                   Id = 1,
                   Login = "adam",
                   FirstName = "Adam",
                   LastName = "Kowalski",
                   Email = "adam.kowalski@example.com",
                   Password = "password123",
                   PhoneNumber = "123456789",
                   IsDocumentsVerified = true,
                   Rank = UserRank.User
               },
               new User
               {
                   Id = 2,
                   Login = "anna",
                   FirstName = "Anna",
                   LastName = "Nowak",
                   Email = "anna.nowak@example.com",
                   Password = "password456",
                   PhoneNumber = "987654321",
                   IsDocumentsVerified = true,
                   Rank = UserRank.Technician
               },
               new User
               {
                   Id = 3,
                   Login = "matt",
                   FirstName = "Mateusz",
                   LastName = "Partyka",
                   Email = "partyka@example.com",
                   Password = "testowe",
                   PhoneNumber = "555444333",
                   IsDocumentsVerified = true,
                   Rank = UserRank.Owner
               }
           );
        }
    }
}
