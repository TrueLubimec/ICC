using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ICC.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonalAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountNum = table.Column<string>(type: "TEXT", nullable: true),
                    EffectiveDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Square = table.Column<int>(type: "INTEGER", nullable: false),
                    Residents = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Residents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonalAccountId = table.Column<int>(type: "INTEGER", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Residents_PersonalAccounts_PersonalAccountId",
                        column: x => x.PersonalAccountId,
                        principalTable: "PersonalAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PersonalAccounts",
                columns: new[] { "Id", "AccountNum", "Address", "EffectiveDate", "ExpirationDate", "Residents", "Square" },
                values: new object[] { 1, "1_2024_AB", "103132, г. Москва, Ивановская площадь", new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2027, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), " ", 277000 });

            migrationBuilder.InsertData(
                table: "Residents",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PersonalAccountId" },
                values: new object[] { 1, "eva@gmail.com", "Ева", "Кернс", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Residents_PersonalAccountId",
                table: "Residents",
                column: "PersonalAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Residents");

            migrationBuilder.DropTable(
                name: "PersonalAccounts");
        }
    }
}
