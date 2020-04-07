using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YourApartment.Persistence.EntityFramework.Migrations
{
    public partial class AddLocationToAPartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Landmark",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Apartments");

            migrationBuilder.AddColumn<string>(
                name: "ExactAdressPreciseAdress",
                table: "Apartments",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "Apartments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_ExactAdressPreciseAdress",
                table: "Apartments",
                column: "ExactAdressPreciseAdress");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_LocationId",
                table: "Apartments",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_PreciseLocation_ExactAdressPreciseAdress",
                table: "Apartments",
                column: "ExactAdressPreciseAdress",
                principalTable: "PreciseLocation",
                principalColumn: "PreciseAdress",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Locations_LocationId",
                table: "Apartments",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_PreciseLocation_ExactAdressPreciseAdress",
                table: "Apartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Locations_LocationId",
                table: "Apartments");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_ExactAdressPreciseAdress",
                table: "Apartments");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_LocationId",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "ExactAdressPreciseAdress",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Apartments");

            migrationBuilder.AddColumn<string>(
                name: "Landmark",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
