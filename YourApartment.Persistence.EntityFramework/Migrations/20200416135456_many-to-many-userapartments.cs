using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YourApartment.Persistence.EntityFramework.Migrations
{
    public partial class manytomanyuserapartments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Users_UserId",
                table: "Apartments");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_UserId",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Apartments");

            migrationBuilder.CreateTable(
                name: "UserApartments",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    ApartmentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserApartments", x => new { x.UserId, x.ApartmentId });
                    table.ForeignKey(
                        name: "FK_UserApartments_Users_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserApartments_Apartments_UserId",
                        column: x => x.UserId,
                        principalTable: "Apartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserApartments_ApartmentId",
                table: "UserApartments",
                column: "ApartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserApartments");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Apartments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_UserId",
                table: "Apartments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Users_UserId",
                table: "Apartments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
