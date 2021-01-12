using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_razmjena.Data.Migrations
{
    public partial class AlbumZamjena : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GodinaIzdanja",
                table: "Slicice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Izdavac",
                table: "Slicice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Albumi",
                columns: table => new
                {
                    AlbumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albumi", x => x.AlbumId);
                });

            migrationBuilder.CreateTable(
                name: "Zamjene",
                columns: table => new
                {
                    ZamjenaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Način = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamjene", x => x.ZamjenaId);
                });

            migrationBuilder.CreateTable(
                name: "SliciceModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BrojSlicica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Izdavac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GodinaIzdanja = table.Column<int>(type: "int", nullable: false),
                    AlbumId = table.Column<int>(type: "int", nullable: false),
                    AlbumModelAlbumId = table.Column<int>(type: "int", nullable: true),
                    ZamjenaId = table.Column<int>(type: "int", nullable: false),
                    ZamjenaModelZamjenaId = table.Column<int>(type: "int", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true),
                    Kontakt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Korisnik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DodatneInformacije = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SliciceModelId = table.Column<int>(type: "int", nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GalleryModel");

            migrationBuilder.DropTable(
                name: "SliciceModel");

            migrationBuilder.DropTable(
                name: "Albumi");

            migrationBuilder.DropTable(
                name: "Zamjene");

            migrationBuilder.DropColumn(
                name: "GodinaIzdanja",
                table: "Slicice");

            migrationBuilder.DropColumn(
                name: "Izdavac",
                table: "Slicice");
        }
    }
}
