using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_razmjena.Data.Migrations
{
    public partial class kupnjaprodajaFilter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Filter",
                table: "Slicice",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Filter",
                table: "Slicice");
        }
    }
}
