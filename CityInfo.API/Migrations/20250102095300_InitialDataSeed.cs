using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityInfo.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Applicants",
                columns: new[] { "Id", "Email", "Name", "Vrn" },
                values: new object[] { 1, "tegan.o'connor@informed.com", "Tegan O'Connor", 123 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Applicants",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
