﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace KalamYouthForumWebApp.Data.Migrations
{
    public partial class chapterXuserremove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserXChapters");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserXChapters",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChapterID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserXChapters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserXChapters_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserXChapters_chapterModels_ChapterID",
                        column: x => x.ChapterID,
                        principalTable: "chapterModels",
                        principalColumn: "ChapterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserXChapters_ChapterID",
                table: "UserXChapters",
                column: "ChapterID");

            migrationBuilder.CreateIndex(
                name: "IX_UserXChapters_UserID",
                table: "UserXChapters",
                column: "UserID");
        }
    }
}
