using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1Project.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code3 = table.Column<string>(type: "char(3)", maxLength: 3, nullable: true),
                    CountryNumber = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    FlagUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryCode);
                });

            migrationBuilder.CreateTable(
                name: "Circuit",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitute = table.Column<double>(type: "float", nullable: true),
                    Longitute = table.Column<double>(type: "float", nullable: true),
                    Wiki = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CountryCode = table.Column<string>(type: "char(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Circuit", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Circuit_Country_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Country",
                        principalColumn: "CountryCode");
                });

            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Wiki = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Gender = table.Column<string>(type: "char(1)", maxLength: 1, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "char(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Driver_Country_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Country",
                        principalColumn: "CountryCode");
                });

            migrationBuilder.CreateTable(
                name: "Grandprix",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wiki = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CountryCode = table.Column<string>(type: "char(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grandprix", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Grandprix_Country_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Country",
                        principalColumn: "CountryCode");
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wiki = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CountryCode = table.Column<string>(type: "char(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Team_Country_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Country",
                        principalColumn: "CountryCode");
                });

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Racenumber = table.Column<byte>(type: "tinyint", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Rounds = table.Column<byte>(type: "tinyint", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverID = table.Column<int>(type: "int", nullable: false),
                    GrandprixID = table.Column<int>(type: "int", nullable: false),
                    CircuitID = table.Column<int>(type: "int", nullable: false),
                    TeamID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Result_Circuit_CircuitID",
                        column: x => x.CircuitID,
                        principalTable: "Circuit",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Result_Driver_DriverID",
                        column: x => x.DriverID,
                        principalTable: "Driver",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Result_Grandprix_GrandprixID",
                        column: x => x.GrandprixID,
                        principalTable: "Grandprix",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Result_Team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Team",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Circuit_CountryCode",
                table: "Circuit",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Driver_CountryCode",
                table: "Driver",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Grandprix_CountryCode",
                table: "Grandprix",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Result_CircuitID",
                table: "Result",
                column: "CircuitID");

            migrationBuilder.CreateIndex(
                name: "IX_Result_DriverID",
                table: "Result",
                column: "DriverID");

            migrationBuilder.CreateIndex(
                name: "IX_Result_GrandprixID",
                table: "Result",
                column: "GrandprixID");

            migrationBuilder.CreateIndex(
                name: "IX_Result_TeamID",
                table: "Result",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Team_CountryCode",
                table: "Team",
                column: "CountryCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropTable(
                name: "Circuit");

            migrationBuilder.DropTable(
                name: "Driver");

            migrationBuilder.DropTable(
                name: "Grandprix");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
