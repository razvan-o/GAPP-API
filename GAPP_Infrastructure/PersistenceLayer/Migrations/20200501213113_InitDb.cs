using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GAPP_Infrastructure.PersistenceLayer.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FocusSubject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FocusSubject", x => x.Id);
                });

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
                name: "AccountFocusSubject",
                columns: table => new
                {
                    FocusSubjectId = table.Column<int>(nullable: false),
                    InstagramAccountId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountFocusSubject", x => new { x.InstagramAccountId, x.FocusSubjectId });
                    table.ForeignKey(
                        name: "FK_AccountFocusSubject_FocusSubject_FocusSubjectId",
                        column: x => x.FocusSubjectId,
                        principalTable: "FocusSubject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountFocusSubject_InstagramAccounts_InstagramAccountId",
                        column: x => x.InstagramAccountId,
                        principalTable: "InstagramAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstagramPosts",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 21, nullable: false),
                    InstagramAccountId = table.Column<long>(nullable: false),
                    ShortCode = table.Column<string>(maxLength: 15, nullable: false),
                    Url = table.Column<string>(maxLength: 2048, nullable: false),
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

            migrationBuilder.CreateTable(
                name: "PostFocusSubject",
                columns: table => new
                {
                    FocusSubjectId = table.Column<int>(nullable: false),
                    InstagramPostId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostFocusSubject", x => new { x.InstagramPostId, x.FocusSubjectId });
                    table.ForeignKey(
                        name: "FK_PostFocusSubject_FocusSubject_FocusSubjectId",
                        column: x => x.FocusSubjectId,
                        principalTable: "FocusSubject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostFocusSubject_InstagramPosts_InstagramPostId",
                        column: x => x.InstagramPostId,
                        principalTable: "InstagramPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountFocusSubject_FocusSubjectId",
                table: "AccountFocusSubject",
                column: "FocusSubjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountFocusSubject_InstagramAccountId",
                table: "AccountFocusSubject",
                column: "InstagramAccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstagramAccounts_Id",
                table: "InstagramAccounts",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstagramPosts_Id",
                table: "InstagramPosts",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstagramPosts_InstagramAccountId",
                table: "InstagramPosts",
                column: "InstagramAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_InstagramPosts_ShortCode",
                table: "InstagramPosts",
                column: "ShortCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostFocusSubject_FocusSubjectId",
                table: "PostFocusSubject",
                column: "FocusSubjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostFocusSubject_InstagramPostId",
                table: "PostFocusSubject",
                column: "InstagramPostId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountFocusSubject");

            migrationBuilder.DropTable(
                name: "PostFocusSubject");

            migrationBuilder.DropTable(
                name: "FocusSubject");

            migrationBuilder.DropTable(
                name: "InstagramPosts");

            migrationBuilder.DropTable(
                name: "InstagramAccounts");
        }
    }
}
