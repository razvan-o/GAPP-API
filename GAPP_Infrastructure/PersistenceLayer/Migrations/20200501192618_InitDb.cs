using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GAPP_Infrastructure.PersistenceLayer.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InstagramAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstagramAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstagramPosts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    InstagramAccountId = table.Column<long>(nullable: false),
                    ShortCode = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Caption = table.Column<string>(nullable: true),
                    LikesCount = table.Column<long>(nullable: false),
                    CommentsCount = table.Column<long>(nullable: false),
                    Hashtags = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstagramPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstagramPosts_InstagramAccounts_InstagramAccountId",
                        column: x => x.InstagramAccountId,
                        principalTable: "InstagramAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstagramPosts_InstagramAccountId",
                table: "InstagramPosts",
                column: "InstagramAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstagramPosts");

            migrationBuilder.DropTable(
                name: "InstagramAccounts");
        }
    }
}
