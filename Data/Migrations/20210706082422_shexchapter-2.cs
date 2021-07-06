using Microsoft.EntityFrameworkCore.Migrations;

namespace KalamYouthForumWebApp.Data.Migrations
{
    public partial class shexchapter2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sheModels_chapterModels_ChapterModelsChapterID",
                table: "sheModels");

            migrationBuilder.DropIndex(
                name: "IX_sheModels_ChapterModelsChapterID",
                table: "sheModels");

            migrationBuilder.DropColumn(
                name: "ChapterModelsChapterID",
                table: "sheModels");

            migrationBuilder.CreateTable(
                name: "ChapterModelSHEModel",
                columns: table => new
                {
                    ChapterModelsChapterID = table.Column<int>(type: "int", nullable: false),
                    SHEModelsSHEId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterModelSHEModel", x => new { x.ChapterModelsChapterID, x.SHEModelsSHEId });
                    table.ForeignKey(
                        name: "FK_ChapterModelSHEModel_chapterModels_ChapterModelsChapterID",
                        column: x => x.ChapterModelsChapterID,
                        principalTable: "chapterModels",
                        principalColumn: "ChapterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChapterModelSHEModel_sheModels_SHEModelsSHEId",
                        column: x => x.SHEModelsSHEId,
                        principalTable: "sheModels",
                        principalColumn: "SHEId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChapterModelSHEModel_SHEModelsSHEId",
                table: "ChapterModelSHEModel",
                column: "SHEModelsSHEId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChapterModelSHEModel");

            migrationBuilder.AddColumn<int>(
                name: "ChapterModelsChapterID",
                table: "sheModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_sheModels_ChapterModelsChapterID",
                table: "sheModels",
                column: "ChapterModelsChapterID");

            migrationBuilder.AddForeignKey(
                name: "FK_sheModels_chapterModels_ChapterModelsChapterID",
                table: "sheModels",
                column: "ChapterModelsChapterID",
                principalTable: "chapterModels",
                principalColumn: "ChapterID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
