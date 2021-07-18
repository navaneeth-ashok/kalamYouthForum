using Microsoft.EntityFrameworkCore.Migrations;

namespace KalamYouthForumWebApp.Data.Migrations
{
    public partial class SHGxFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SHGMonthlyDocuments",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHGMonthlyDocuments",
                table: "SHGMonthlyDocuments",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHGMonthlyDocuments",
                table: "SHGMonthlyDocuments");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SHGMonthlyDocuments");
        }
    }
}
