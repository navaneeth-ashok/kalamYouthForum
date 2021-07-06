using Microsoft.EntityFrameworkCore.Migrations;

namespace KalamYouthForumWebApp.Data.Migrations
{
    public partial class chapterXshe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
