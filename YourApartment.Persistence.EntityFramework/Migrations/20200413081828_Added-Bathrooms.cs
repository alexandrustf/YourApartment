using Microsoft.EntityFrameworkCore.Migrations;

namespace YourApartment.Persistence.EntityFramework.Migrations
{
    public partial class AddedBathrooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfBathrooms",
                table: "Apartments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfBathrooms",
                table: "Apartments");
        }
    }
}
