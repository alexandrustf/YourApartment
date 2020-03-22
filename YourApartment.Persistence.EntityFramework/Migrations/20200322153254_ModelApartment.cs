using Microsoft.EntityFrameworkCore.Migrations;

namespace YourApartment.Persistence.EntityFramework.Migrations
{
    public partial class ModelApartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Building",
                table: "Apartments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Apartments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Landmark",
                table: "Apartments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Apartments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PartitioningType",
                table: "Apartments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PostedBy",
                table: "Apartments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PostedFor",
                table: "Apartments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalNumberOfFloors",
                table: "Apartments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Building",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "Landmark",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "PartitioningType",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "PostedFor",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "TotalNumberOfFloors",
                table: "Apartments");
        }
    }
}
