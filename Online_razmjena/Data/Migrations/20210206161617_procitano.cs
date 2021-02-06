using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_razmjena.Data.Migrations
{
    public partial class procitano : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "355991cd-ae6a-4151-bae9-582c845ffbe2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd532204-0941-4c5a-a59f-cfe45f6eb292");

            migrationBuilder.AddColumn<bool>(
                name: "Procitano",
                table: "Poruke",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7084951a-580e-4c8c-b4f5-40886f9a2e6f", "c43af6ac-beb4-4e67-9e6a-dfcf320cf611", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b5117854-a8d2-43d9-a60c-652dbccdb19b", "16e414ad-f1b4-4d78-a8a0-5e31dc549676", "Korisnik", "KORISNIK" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7084951a-580e-4c8c-b4f5-40886f9a2e6f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5117854-a8d2-43d9-a60c-652dbccdb19b");

            migrationBuilder.DropColumn(
                name: "Procitano",
                table: "Poruke");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dd532204-0941-4c5a-a59f-cfe45f6eb292", "618c0949-a7d6-49d5-9411-5c6c080bccdd", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "355991cd-ae6a-4151-bae9-582c845ffbe2", "7559cd5c-f41a-4cb0-a764-3c414ca57a69", "Korisnik", "KORISNIK" });
        }
    }
}
