using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Car_SharingDesktopAPP.Migrations
{
    /// <inheritdoc />
    public partial class CarSharingMG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDocumentsVerified = table.Column<bool>(type: "bit", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VehicleType = table.Column<int>(type: "int", nullable: false),
                    FuelType = table.Column<int>(type: "int", nullable: false),
                    CurrentCity = table.Column<int>(type: "int", nullable: false),
                    CleanStatus = table.Column<int>(type: "int", nullable: false),
                    FuelLevel = table.Column<float>(type: "real", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "IsDocumentsVerified", "LastName", "Login", "Password", "PhoneNumber", "Rank" },
                values: new object[,]
                {
                    { 1, "adam.kowalski@example.com", "Adam", true, "Kowalski", "adam", "password123", "123456789", 0 },
                    { 2, "anna.nowak@example.com", "Anna", true, "Nowak", "anna", "password456", "987654321", 2 },
                    { 3, "partyka@example.com", "Mateusz", true, "Partyka", "matt", "testowe", "555444333", 99 }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "CleanStatus", "Color", "CurrentCity", "FuelLevel", "FuelType", "IsAvailable", "Model", "RegistrationNumber", "VehicleType", "Year" },
                values: new object[,]
                {
                    { 1, "Skoda", 0, "Czarny", 0, 100f, 1, true, "Fabia", "RZ2345", 0, 2015 },
                    { 2, "Seat", 2, "Czerwony", 0, 100f, 2, true, "Leon", "RZ3456", 0, 2018 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
