using Microsoft.EntityFrameworkCore.Migrations;

namespace YourApartment.Persistence.EntityFramework.Migrations
{
    public partial class addlocationlatandlong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Apartments",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Apartments",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Apartments");
        }
    }
}
