using Microsoft.EntityFrameworkCore.Migrations;

namespace KalamYouthForumWebApp.Data.Migrations
{
    public partial class chaptermonthlydoc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChapterMonthlyDocument",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChapterID = table.Column<int>(type: "int", nullable: false),
                    FileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterMonthlyDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChapterMonthlyDocument_chapterModels_ChapterID",
                        column: x => x.ChapterID,
                        principalTable: "chapterModels",
                        principalColumn: "ChapterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChapterMonthlyDocument_MonthlyAccountDocuments_FileId",
                        column: x => x.FileId,
                        principalTable: "MonthlyAccountDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChapterMonthlyDocument_ChapterID",
                table: "ChapterMonthlyDocument",
                column: "ChapterID");

            migrationBuilder.CreateIndex(
                name: "IX_ChapterMonthlyDocument_FileId",
                table: "ChapterMonthlyDocument",
                column: "FileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChapterMonthlyDocument");
        }
    }
}
