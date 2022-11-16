using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class initial_migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    Cel = table.Column<string>(maxLength: 25, nullable: false),
                    Permission = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Cel", "CreateAt", "Email", "Name", "Password", "Permission", "UpdateAt" },
                values: new object[] { new Guid("3383b9b8-7ba5-423a-8150-8124acdee46b"), "64992959483", new DateTime(2022, 11, 7, 20, 50, 24, 344, DateTimeKind.Local).AddTicks(5740), "adm@gmail.com", "Administrador", "AJVubWbqOapXMlj8lr1H0wTjdrtpI6zDaXFTZkoVwWBSiscNjdMvzz1nyVK3WP+RWQ==", "admin", new DateTime(2022, 11, 7, 20, 50, 24, 349, DateTimeKind.Local).AddTicks(1490) });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
