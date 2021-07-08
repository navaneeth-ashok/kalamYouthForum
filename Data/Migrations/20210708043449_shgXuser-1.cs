using Microsoft.EntityFrameworkCore.Migrations;

namespace KalamYouthForumWebApp.Data.Migrations
{
    public partial class shgXuser1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserXSHGs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SHGID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserXSHGs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserXSHGs_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserXSHGs_sheModels_SHGID",
                        column: x => x.SHGID,
                        principalTable: "sheModels",
                        principalColumn: "SHEId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserXSHGs_SHGID",
                table: "UserXSHGs",
                column: "SHGID");

            migrationBuilder.CreateIndex(
                name: "IX_UserXSHGs_UserID",
                table: "UserXSHGs",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserXSHGs");
        }
    }
}
