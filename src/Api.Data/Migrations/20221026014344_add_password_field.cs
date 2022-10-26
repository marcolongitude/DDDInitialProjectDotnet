using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class add_password_field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c7ec0a7d-dd87-41f3-8927-99c8b2f76f66"));

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "UpdateAt" },
                values: new object[] { new Guid("d3b84aad-6b09-4c57-8d92-edb82b20f023"), new DateTime(2022, 10, 25, 22, 43, 44, 536, DateTimeKind.Local).AddTicks(7971), "adm@gmail.com", "Administrador", new DateTime(2022, 10, 25, 22, 43, 44, 540, DateTimeKind.Local).AddTicks(6352) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d3b84aad-6b09-4c57-8d92-edb82b20f023"));

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "UpdateAt" },
                values: new object[] { new Guid("c7ec0a7d-dd87-41f3-8927-99c8b2f76f66"), new DateTime(2022, 10, 24, 11, 58, 35, 95, DateTimeKind.Local).AddTicks(4341), "adm@gmail.com", "Administrador", new DateTime(2022, 10, 24, 11, 58, 35, 99, DateTimeKind.Local).AddTicks(6330) });
        }
    }
}
