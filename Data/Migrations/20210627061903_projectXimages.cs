using Microsoft.EntityFrameworkCore.Migrations;

namespace KalamYouthForumWebApp.Data.Migrations
{
    public partial class projectXimages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ImageProject",
                columns: table => new
                {
                    ImagesId = table.Column<int>(type: "int", nullable: false),
                    ProjectsProjectIDKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageProject", x => new { x.ImagesId, x.ProjectsProjectIDKey });
                    table.ForeignKey(
                        name: "FK_ImageProject_Images_ImagesId",
                        column: x => x.ImagesId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageProject_Project_ProjectsProjectIDKey",
                        column: x => x.ProjectsProjectIDKey,
                        principalTable: "Project",
                        principalColumn: "ProjectIDKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageProject_ProjectsProjectIDKey",
                table: "ImageProject",
                column: "ProjectsProjectIDKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageProject");

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
    }
}
