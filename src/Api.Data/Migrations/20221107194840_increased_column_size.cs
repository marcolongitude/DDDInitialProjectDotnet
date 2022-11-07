using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class increased_column_size : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f749de26-52b3-41a4-9a34-08ed2af17772"));

            migrationBuilder.AlterColumn<string>(
                name: "Cel",
                table: "Users",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15) CHARACTER SET utf8mb4",
                oldMaxLength: 15);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Cel", "CreateAt", "Email", "Name", "Password", "Permission", "UpdateAt" },
                values: new object[] { new Guid("e605559e-1abe-4ff4-be93-fed9e5e959e6"), "64992959483", new DateTime(2022, 11, 7, 16, 48, 40, 544, DateTimeKind.Local).AddTicks(5005), "adm@gmail.com", "Administrador", "AJVubWbqOapXMlj8lr1H0wTjdrtpI6zDaXFTZkoVwWBSiscNjdMvzz1nyVK3WP+RWQ==", "admin", new DateTime(2022, 11, 7, 16, 48, 40, 545, DateTimeKind.Local).AddTicks(3090) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e605559e-1abe-4ff4-be93-fed9e5e959e6"));

            migrationBuilder.AlterColumn<string>(
                name: "Cel",
                table: "Users",
                type: "varchar(15) CHARACTER SET utf8mb4",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Cel", "CreateAt", "Email", "Name", "Password", "Permission", "UpdateAt" },
                values: new object[] { new Guid("f749de26-52b3-41a4-9a34-08ed2af17772"), "64992959483", new DateTime(2022, 11, 7, 16, 42, 13, 480, DateTimeKind.Local).AddTicks(3867), "adm@gmail.com", "Administrador", "AJVubWbqOapXMlj8lr1H0wTjdrtpI6zDaXFTZkoVwWBSiscNjdMvzz1nyVK3WP+RWQ==", "admin", new DateTime(2022, 11, 7, 16, 42, 13, 481, DateTimeKind.Local).AddTicks(2508) });
        }
    }
}
