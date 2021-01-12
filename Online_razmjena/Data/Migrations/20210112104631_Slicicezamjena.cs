using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_razmjena.Data.Migrations
{
    public partial class Slicicezamjena : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GalleryModel");

            migrationBuilder.DropTable(
                name: "SliciceModel");

            migrationBuilder.AddColumn<int>(
                name: "AlbumId",
                table: "Slicice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AlbumModelAlbumId",
                table: "Slicice",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZamjenaId",
                table: "Slicice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ZamjenaModelZamjenaId",
                table: "Slicice",
                type: "int",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "AlbumId",
                table: "Slicice");

            migrationBuilder.DropColumn(
                name: "AlbumModelAlbumId",
                table: "Slicice");

            migrationBuilder.DropColumn(
                name: "ZamjenaId",
                table: "Slicice");

            migrationBuilder.DropColumn(
                name: "ZamjenaModelZamjenaId",
                table: "Slicice");

            migrationBuilder.CreateTable(
                name: "SliciceModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumId = table.Column<int>(type: "int", nullable: false),
                    AlbumModelAlbumId = table.Column<int>(type: "int", nullable: true),
                    BrojSlicica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DodatneInformacije = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GodinaIzdanja = table.Column<int>(type: "int", nullable: false),
                    Izdavac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kontakt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Korisnik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Naziv = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true),
                    ZamjenaId = table.Column<int>(type: "int", nullable: false),
                    ZamjenaModelZamjenaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SliciceModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SliciceModel_Albumi_AlbumModelAlbumId",
                        column: x => x.AlbumModelAlbumId,
                        principalTable: "Albumi",
                        principalColumn: "AlbumId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SliciceModel_Zamjene_ZamjenaModelZamjenaId",
                        column: x => x.ZamjenaModelZamjenaId,
                        principalTable: "Zamjene",
                        principalColumn: "ZamjenaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GalleryModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SliciceModelId = table.Column<int>(type: "int", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GalleryModel_SliciceModel_SliciceModelId",
                        column: x => x.SliciceModelId,
                        principalTable: "SliciceModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GalleryModel_SliciceModelId",
                table: "GalleryModel",
                column: "SliciceModelId");

            migrationBuilder.CreateIndex(
                name: "IX_SliciceModel_AlbumModelAlbumId",
                table: "SliciceModel",
                column: "AlbumModelAlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_SliciceModel_ZamjenaModelZamjenaId",
                table: "SliciceModel",
                column: "ZamjenaModelZamjenaId");
        }
    }
}
