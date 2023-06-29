﻿// <auto-generated />
using System;
using Car_SharingDesktopAPP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Car_SharingDesktopAPP.Migrations
{
    [DbContext(typeof(CarSharingDBContext))]
    partial class CarSharingDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Car_SharingDesktopAPP.Models.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ReportDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReportDescription")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("ReportStatus")
                        .HasColumnType("int");

                    b.Property<string>("ReportTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Reports", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ReportDate = new DateTime(2023, 6, 24, 22, 48, 30, 160, DateTimeKind.Local).AddTicks(7425),
                            ReportDescription = "Samochód nie odpala, czerwona kontrolka na desce rozdzielczej",
                            ReportStatus = 0,
                            ReportTitle = "Zepsuty samochód"
                        },
                        new
                        {
                            Id = 2,
                            ReportDate = new DateTime(2023, 6, 19, 22, 48, 30, 160, DateTimeKind.Local).AddTicks(7459),
                            ReportDescription = "Radio nie działa, nie można włączyć radia",
                            ReportStatus = 1,
                            ReportTitle = "Uszkodzone radio"
                        });
                });

            modelBuilder.Entity("Car_SharingDesktopAPP.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDocumentsVerified")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "adam.kowalski@example.com",
                            FirstName = "Adam",
                            IsDocumentsVerified = true,
                            LastName = "Kowalski",
                            Login = "adam",
                            Password = "password123",
                            PhoneNumber = "123456789",
                            Rank = 0
                        },
                        new
                        {
                            Id = 2,
                            Email = "anna.nowak@example.com",
                            FirstName = "Anna",
                            IsDocumentsVerified = true,
                            LastName = "Nowak",
                            Login = "anna",
                            Password = "password456",
                            PhoneNumber = "987654321",
                            Rank = 2
                        },
                        new
                        {
                            Id = 3,
                            Email = "partyka@example.com",
                            FirstName = "Mateusz",
                            IsDocumentsVerified = true,
                            LastName = "Partyka",
                            Login = "matt",
                            Password = "testowe",
                            PhoneNumber = "555444333",
                            Rank = 99
                        });
                });

            modelBuilder.Entity("Car_SharingDesktopAPP.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CleanStatus")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CurrentCity")
                        .HasColumnType("int");

                    b.Property<float>("FuelLevel")
                        .HasColumnType("real");

                    b.Property<int>("FuelType")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("VehicleType")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Skoda",
                            CleanStatus = 0,
                            Color = "Czarny",
                            CurrentCity = 0,
                            FuelLevel = 100f,
                            FuelType = 1,
                            IsAvailable = true,
                            Model = "Fabia",
                            RegistrationNumber = "RZ2345",
                            VehicleType = 0,
                            Year = 2015
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Seat",
                            CleanStatus = 2,
                            Color = "Czerwony",
                            CurrentCity = 0,
                            FuelLevel = 100f,
                            FuelType = 2,
                            IsAvailable = true,
                            Model = "Leon",
                            RegistrationNumber = "RZ3456",
                            VehicleType = 0,
                            Year = 2018
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
