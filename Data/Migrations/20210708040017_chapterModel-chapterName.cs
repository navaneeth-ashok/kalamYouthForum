using Microsoft.EntityFrameworkCore.Migrations;

namespace KalamYouthForumWebApp.Data.Migrations
{
    public partial class chapterModelchapterName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChapterName",
                table: "chapterModels",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChapterName",
                table: "chapterModels");
        }
    }
}
