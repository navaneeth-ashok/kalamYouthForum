using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KalamYouthForumWebApp.Data.Migrations
{
    public partial class chaptershe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chapterModels",
                columns: table => new
                {
                    ChapterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Panchayat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Muncipality = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Taluk = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Constituency = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OfficeAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chapterModels", x => x.ChapterID);
                });

            migrationBuilder.CreateTable(
                name: "sheModels",
                columns: table => new
                {
                    SHEId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SHEName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfFormation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfMembers = table.Column<int>(type: "int", nullable: false),
                    ElectedPresident = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PresidentEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PresidentPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElectedSecretary = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SecretaryEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecretaryPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElectedTreasurer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TreasurerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TreasurerPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sheModels", x => x.SHEId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chapterModels");

            migrationBuilder.DropTable(
                name: "sheModels");
        }
    }
}
