using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class initial : Migration
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
                    Cel = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Cel", "CreateAt", "Email", "Name", "Password", "UpdateAt" },
                values: new object[] { new Guid("3fd22209-5bc4-47a7-a6d4-0a9cba50e838"), "64992959483", new DateTime(2022, 11, 7, 11, 47, 47, 106, DateTimeKind.Local).AddTicks(1242), "adm@gmail.com", "Administrador", "AJVubWbqOapXMlj8lr1H0wTjdrtpI6zDaXFTZkoVwWBSiscNjdMvzz1nyVK3WP+RWQ==", new DateTime(2022, 11, 7, 11, 47, 47, 107, DateTimeKind.Local).AddTicks(33) });

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
