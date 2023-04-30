using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_SharingDesktopAPP.Models
{
    public class UserDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CarSharingDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
