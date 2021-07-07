using Microsoft.EntityFrameworkCore.Migrations;

namespace KalamYouthForumWebApp.Data.Migrations
{
    public partial class userXchapter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserXChapterId",
                table: "chapterModels",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserXChapterId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserXChapters",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserXChapters", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chapterModels_UserXChapterId",
                table: "chapterModels",
                column: "UserXChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserXChapterId",
                table: "AspNetUsers",
                column: "UserXChapterId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserXChapters_UserXChapterId",
                table: "AspNetUsers",
                column: "UserXChapterId",
                principalTable: "UserXChapters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_chapterModels_UserXChapters_UserXChapterId",
                table: "chapterModels",
                column: "UserXChapterId",
                principalTable: "UserXChapters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserXChapters_UserXChapterId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_chapterModels_UserXChapters_UserXChapterId",
                table: "chapterModels");

            migrationBuilder.DropTable(
                name: "UserXChapters");

            migrationBuilder.DropIndex(
                name: "IX_chapterModels_UserXChapterId",
                table: "chapterModels");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserXChapterId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserXChapterId",
                table: "chapterModels");

            migrationBuilder.DropColumn(
                name: "UserXChapterId",
                table: "AspNetUsers");
        }
    }
}
