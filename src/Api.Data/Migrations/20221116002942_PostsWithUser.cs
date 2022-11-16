using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class PostsWithUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Posts_PostEntityId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PostEntityId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("406e53b0-905e-4cc9-ae56-c96b9f48659d"));

            migrationBuilder.DropColumn(
                name: "PostEntityId",
                table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Posts",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Cel", "CreateAt", "Email", "Name", "Password", "Permission", "UpdateAt" },
                values: new object[] { new Guid("9b4a9981-ba72-42b6-bbfc-91370912ece8"), "64992959483", new DateTime(2022, 11, 15, 21, 29, 42, 192, DateTimeKind.Local).AddTicks(2782), "adm@gmail.com", "Administrador", "AJVubWbqOapXMlj8lr1H0wTjdrtpI6zDaXFTZkoVwWBSiscNjdMvzz1nyVK3WP+RWQ==", "admin", new DateTime(2022, 11, 15, 21, 29, 42, 196, DateTimeKind.Local).AddTicks(5958) });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_UserId",
                table: "Posts");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9b4a9981-ba72-42b6-bbfc-91370912ece8"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Posts");

            migrationBuilder.AddColumn<Guid>(
                name: "PostEntityId",
                table: "Users",
                type: "char(36)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Cel", "CreateAt", "Email", "Name", "Password", "Permission", "PostEntityId", "UpdateAt" },
                values: new object[] { new Guid("406e53b0-905e-4cc9-ae56-c96b9f48659d"), "64992959483", new DateTime(2022, 11, 15, 21, 3, 46, 813, DateTimeKind.Local).AddTicks(4030), "adm@gmail.com", "Administrador", "AJVubWbqOapXMlj8lr1H0wTjdrtpI6zDaXFTZkoVwWBSiscNjdMvzz1nyVK3WP+RWQ==", "admin", null, new DateTime(2022, 11, 15, 21, 3, 46, 819, DateTimeKind.Local).AddTicks(6816) });

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
    }
}
