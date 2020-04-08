using Microsoft.EntityFrameworkCore.Migrations;

namespace YourApartment.Persistence.EntityFramework.Migrations
{
    public partial class AddLocationApartmentexactAdress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_PreciseLocation_ExactAdressPreciseAdress",
                table: "Apartments");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_ExactAdressPreciseAdress",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "ExactAdressPreciseAdress",
                table: "Apartments");

            migrationBuilder.AddColumn<string>(
                name: "ExactAdress",
                table: "Apartments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExactAdress",
                table: "Apartments");

            migrationBuilder.AddColumn<string>(
                name: "ExactAdressPreciseAdress",
                table: "Apartments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_ExactAdressPreciseAdress",
                table: "Apartments",
                column: "ExactAdressPreciseAdress");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_PreciseLocation_ExactAdressPreciseAdress",
                table: "Apartments",
                column: "ExactAdressPreciseAdress",
                principalTable: "PreciseLocation",
                principalColumn: "PreciseAdress",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
