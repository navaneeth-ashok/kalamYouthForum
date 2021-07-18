using Microsoft.EntityFrameworkCore.Migrations;

namespace KalamYouthForumWebApp.Data.Migrations
{
    public partial class MonthlyDoc3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MonthlyAccountDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "SHGMonthlyDocuments",
                columns: table => new
                {
                    SHGId = table.Column<int>(type: "int", nullable: false),
                    FileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_SHGMonthlyDocuments_MonthlyAccountDocuments_FileId",
                        column: x => x.FileId,
                        principalTable: "MonthlyAccountDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SHGMonthlyDocuments_sheModels_SHGId",
                        column: x => x.SHGId,
                        principalTable: "sheModels",
                        principalColumn: "SHEId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SHGMonthlyDocuments_FileId",
                table: "SHGMonthlyDocuments",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_SHGMonthlyDocuments_SHGId",
                table: "SHGMonthlyDocuments",
                column: "SHGId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SHGMonthlyDocuments");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MonthlyAccountDocuments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
