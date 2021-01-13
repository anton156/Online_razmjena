using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_razmjena.Data.Migrations
{
    public partial class novazamjenaialbumi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Slicice_Albumi_AlbumModelAlbumId",
                table: "Slicice");

            migrationBuilder.DropForeignKey(
                name: "FK_Slicice_Zamjene_ZamjenaModelZamjenaId",
                table: "Slicice");

            migrationBuilder.DropIndex(
                name: "IX_Slicice_AlbumModelAlbumId",
                table: "Slicice");

            migrationBuilder.DropIndex(
                name: "IX_Slicice_ZamjenaModelZamjenaId",
                table: "Slicice");

            migrationBuilder.DropColumn(
                name: "Način",
                table: "Zamjene");

            migrationBuilder.DropColumn(
                name: "AlbumModelAlbumId",
                table: "Slicice");

            migrationBuilder.DropColumn(
                name: "ZamjenaModelZamjenaId",
                table: "Slicice");

            migrationBuilder.AddColumn<string>(
                name: "Nacin",
                table: "Zamjene",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Albumi",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Slicice_AlbumId",
                table: "Slicice",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Slicice_ZamjenaId",
                table: "Slicice",
                column: "ZamjenaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Slicice_Albumi_AlbumId",
                table: "Slicice",
                column: "AlbumId",
                principalTable: "Albumi",
                principalColumn: "AlbumId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Slicice_Zamjene_ZamjenaId",
                table: "Slicice",
                column: "ZamjenaId",
                principalTable: "Zamjene",
                principalColumn: "ZamjenaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Slicice_Albumi_AlbumId",
                table: "Slicice");

            migrationBuilder.DropForeignKey(
                name: "FK_Slicice_Zamjene_ZamjenaId",
                table: "Slicice");

            migrationBuilder.DropIndex(
                name: "IX_Slicice_AlbumId",
                table: "Slicice");

            migrationBuilder.DropIndex(
                name: "IX_Slicice_ZamjenaId",
                table: "Slicice");

            migrationBuilder.DropColumn(
                name: "Nacin",
                table: "Zamjene");

            migrationBuilder.AddColumn<string>(
                name: "Način",
                table: "Zamjene",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AlbumModelAlbumId",
                table: "Slicice",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZamjenaModelZamjenaId",
                table: "Slicice",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Albumi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Slicice_AlbumModelAlbumId",
                table: "Slicice",
                column: "AlbumModelAlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Slicice_ZamjenaModelZamjenaId",
                table: "Slicice",
                column: "ZamjenaModelZamjenaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Slicice_Albumi_AlbumModelAlbumId",
                table: "Slicice",
                column: "AlbumModelAlbumId",
                principalTable: "Albumi",
                principalColumn: "AlbumId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Slicice_Zamjene_ZamjenaModelZamjenaId",
                table: "Slicice",
                column: "ZamjenaModelZamjenaId",
                principalTable: "Zamjene",
                principalColumn: "ZamjenaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
