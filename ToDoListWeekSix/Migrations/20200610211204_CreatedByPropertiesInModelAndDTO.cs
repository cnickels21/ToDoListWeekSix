using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoListWeekSix.Migrations
{
    public partial class CreatedByPropertiesInModelAndDTO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserID",
                table: "Lists",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2020, 6, 10, 16, 12, 4, 565, DateTimeKind.Local).AddTicks(6862));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2020, 6, 10, 16, 12, 4, 568, DateTimeKind.Local).AddTicks(8392));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUserID",
                table: "Lists");

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2020, 6, 8, 15, 43, 9, 803, DateTimeKind.Local).AddTicks(2696));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2020, 6, 8, 15, 43, 9, 807, DateTimeKind.Local).AddTicks(7600));
        }
    }
}
