using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class PostsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3383b9b8-7ba5-423a-8150-8124acdee46b"));

            migrationBuilder.AddColumn<Guid>(
                name: "PostEntityId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Cel", "CreateAt", "Email", "Name", "Password", "Permission", "PostEntityId", "UpdateAt" },
                values: new object[] { new Guid("78fdc52a-3dd6-4a62-82df-5513413cdcd1"), "64992959483", new DateTime(2022, 11, 15, 20, 57, 40, 262, DateTimeKind.Local).AddTicks(4603), "adm@gmail.com", "Administrador", "AJVubWbqOapXMlj8lr1H0wTjdrtpI6zDaXFTZkoVwWBSiscNjdMvzz1nyVK3WP+RWQ==", "admin", null, new DateTime(2022, 11, 15, 20, 57, 40, 266, DateTimeKind.Local).AddTicks(8493) });

            migrationBuilder.CreateIndex(
                name: "IX_Users_PostEntityId",
                table: "Users",
                column: "PostEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Posts_PostEntityId",
                table: "Users",
                column: "PostEntityId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Posts_PostEntityId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Users_PostEntityId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("78fdc52a-3dd6-4a62-82df-5513413cdcd1"));

            migrationBuilder.DropColumn(
                name: "PostEntityId",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Cel", "CreateAt", "Email", "Name", "Password", "Permission", "UpdateAt" },
                values: new object[] { new Guid("3383b9b8-7ba5-423a-8150-8124acdee46b"), "64992959483", new DateTime(2022, 11, 7, 20, 50, 24, 344, DateTimeKind.Local).AddTicks(5740), "adm@gmail.com", "Administrador", "AJVubWbqOapXMlj8lr1H0wTjdrtpI6zDaXFTZkoVwWBSiscNjdMvzz1nyVK3WP+RWQ==", "admin", new DateTime(2022, 11, 7, 20, 50, 24, 349, DateTimeKind.Local).AddTicks(1490) });
        }
    }
}
