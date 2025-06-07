using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContactBook.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Designation", "Name" },
                values: new object[,]
                {
                    { 1, "Software Engineer", "John Doe" },
                    { 2, "Project Manager", "Jane Smith" },
                    { 3, "UX Designer", "Alice Johnson" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "EmailAddress", "EmployeeId", "MobileNumber" },
                values: new object[,]
                {
                    { 1, "jd@gmail.com", 1, "123-456-7890" },
                    { 2, "js@gmail.com", 2, "987-654-3210" },
                    { 3, "aj@gmail.com", 3, "555-555-5555" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
