using Microsoft.EntityFrameworkCore.Migrations;

namespace KalamYouthForumWebApp.Data.Migrations
{
    public partial class imageprojects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath1",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ImagePath2",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ImagePath3",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ImagePath4",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ImagePath5",
                table: "Project");

            migrationBuilder.AddColumn<int>(
                name: "ProjectIDKey",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProjectIDKey",
                table: "Images",
                column: "ProjectIDKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Project_ProjectIDKey",
                table: "Images",
                column: "ProjectIDKey",
                principalTable: "Project",
                principalColumn: "ProjectIDKey",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Project_ProjectIDKey",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ProjectIDKey",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ProjectIDKey",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath1",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath2",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath3",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath4",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath5",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
