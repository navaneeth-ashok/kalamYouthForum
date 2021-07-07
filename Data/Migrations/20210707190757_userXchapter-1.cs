using Microsoft.EntityFrameworkCore.Migrations;

namespace KalamYouthForumWebApp.Data.Migrations
{
    public partial class userXchapter1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserXChapters_UserXChapterId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_chapterModels_UserXChapters_UserXChapterId",
                table: "chapterModels");

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

            migrationBuilder.AddColumn<int>(
                name: "ChapterID",
                table: "UserXChapters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "UserXChapters",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserXChapters_ChapterID",
                table: "UserXChapters",
                column: "ChapterID");

            migrationBuilder.CreateIndex(
                name: "IX_UserXChapters_UserID",
                table: "UserXChapters",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserXChapters_AspNetUsers_UserID",
                table: "UserXChapters",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserXChapters_chapterModels_ChapterID",
                table: "UserXChapters",
                column: "ChapterID",
                principalTable: "chapterModels",
                principalColumn: "ChapterID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserXChapters_AspNetUsers_UserID",
                table: "UserXChapters");

            migrationBuilder.DropForeignKey(
                name: "FK_UserXChapters_chapterModels_ChapterID",
                table: "UserXChapters");

            migrationBuilder.DropIndex(
                name: "IX_UserXChapters_ChapterID",
                table: "UserXChapters");

            migrationBuilder.DropIndex(
                name: "IX_UserXChapters_UserID",
                table: "UserXChapters");

            migrationBuilder.DropColumn(
                name: "ChapterID",
                table: "UserXChapters");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "UserXChapters");

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
    }
}
