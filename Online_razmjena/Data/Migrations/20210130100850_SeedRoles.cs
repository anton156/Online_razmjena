using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_razmjena.Data.Migrations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dd532204-0941-4c5a-a59f-cfe45f6eb292", "618c0949-a7d6-49d5-9411-5c6c080bccdd", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "355991cd-ae6a-4151-bae9-582c845ffbe2", "7559cd5c-f41a-4cb0-a764-3c414ca57a69", "Korisnik", "KORISNIK" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "355991cd-ae6a-4151-bae9-582c845ffbe2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd532204-0941-4c5a-a59f-cfe45f6eb292");
        }
    }
}
