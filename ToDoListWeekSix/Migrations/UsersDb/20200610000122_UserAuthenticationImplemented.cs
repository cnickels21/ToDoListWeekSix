using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoListWeekSix.Migrations.UsersDb
{
    public partial class UserAuthenticationImplemented : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "f7d11de5-b398-4434-a6b9-c117781c2985");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user",
                column: "ConcurrencyStamp",
                value: "6f454848-0477-4dd3-848c-72f51f6f2ab9");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "79575b8e-e8cc-414c-b257-082d1e0c8261");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user",
                column: "ConcurrencyStamp",
                value: "84ce0789-580f-4118-ade8-6488bfce2dd6");
        }
    }
}
