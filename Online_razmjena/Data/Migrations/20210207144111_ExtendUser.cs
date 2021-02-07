using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_razmjena.Data.Migrations
{
    public partial class ExtendUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7084951a-580e-4c8c-b4f5-40886f9a2e6f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5117854-a8d2-43d9-a60c-652dbccdb19b");

            migrationBuilder.AddColumn<int>(
                name: "NeProcitano",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "58fbc949-0d93-47d5-ad12-ca9649ef6a5d", "41305c6f-dd7e-4ebe-b162-fb3bf471014f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e794e1fe-d863-44bf-9c1f-3f03978c5d88", "33258bec-963a-4add-af85-eae9f0872c26", "Korisnik", "KORISNIK" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58fbc949-0d93-47d5-ad12-ca9649ef6a5d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e794e1fe-d863-44bf-9c1f-3f03978c5d88");

            migrationBuilder.DropColumn(
                name: "NeProcitano",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7084951a-580e-4c8c-b4f5-40886f9a2e6f", "c43af6ac-beb4-4e67-9e6a-dfcf320cf611", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b5117854-a8d2-43d9-a60c-652dbccdb19b", "16e414ad-f1b4-4d78-a8a0-5e31dc549676", "Korisnik", "KORISNIK" });
        }
    }
}
