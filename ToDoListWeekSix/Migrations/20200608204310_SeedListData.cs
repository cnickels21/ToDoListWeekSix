using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoListWeekSix.Migrations
{
    public partial class SeedListData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Lists",
                columns: new[] { "Id", "Assignee", "DueDate", "Task" },
                values: new object[] { 1, "Chase", new DateTime(2020, 6, 8, 15, 43, 9, 803, DateTimeKind.Local).AddTicks(2696), "Start up injection" });

            migrationBuilder.InsertData(
                table: "Lists",
                columns: new[] { "Id", "Assignee", "DueDate", "Task" },
                values: new object[] { 2, "Chase", new DateTime(2020, 6, 8, 15, 43, 9, 807, DateTimeKind.Local).AddTicks(7600), "Routing" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
