using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Server.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catalogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Url = table.Column<string>(maxLength: 32, nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Pri = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Url = table.Column<string>(maxLength: 256, nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    IsPage = table.Column<bool>(nullable: false),
                    CatalogId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostTags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PostId = table.Column<Guid>(nullable: false),
                    Tag = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostTags_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalogs_Pri",
                table: "Catalogs",
                column: "Pri");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_IsPage",
                table: "Posts",
                column: "IsPage");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Time",
                table: "Posts",
                column: "Time");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Title",
                table: "Posts",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Url",
                table: "Posts",
                column: "Url",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_PostId",
                table: "PostTags",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_Tag",
                table: "PostTags",
                column: "Tag");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalogs");

            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
