using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class PostsTableAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("78fdc52a-3dd6-4a62-82df-5513413cdcd1"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Cel", "CreateAt", "Email", "Name", "Password", "Permission", "PostEntityId", "UpdateAt" },
                values: new object[] { new Guid("406e53b0-905e-4cc9-ae56-c96b9f48659d"), "64992959483", new DateTime(2022, 11, 15, 21, 3, 46, 813, DateTimeKind.Local).AddTicks(4030), "adm@gmail.com", "Administrador", "AJVubWbqOapXMlj8lr1H0wTjdrtpI6zDaXFTZkoVwWBSiscNjdMvzz1nyVK3WP+RWQ==", "admin", null, new DateTime(2022, 11, 15, 21, 3, 46, 819, DateTimeKind.Local).AddTicks(6816) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("406e53b0-905e-4cc9-ae56-c96b9f48659d"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Cel", "CreateAt", "Email", "Name", "Password", "Permission", "PostEntityId", "UpdateAt" },
                values: new object[] { new Guid("78fdc52a-3dd6-4a62-82df-5513413cdcd1"), "64992959483", new DateTime(2022, 11, 15, 20, 57, 40, 262, DateTimeKind.Local).AddTicks(4603), "adm@gmail.com", "Administrador", "AJVubWbqOapXMlj8lr1H0wTjdrtpI6zDaXFTZkoVwWBSiscNjdMvzz1nyVK3WP+RWQ==", "admin", null, new DateTime(2022, 11, 15, 20, 57, 40, 266, DateTimeKind.Local).AddTicks(8493) });
        }
    }
}
