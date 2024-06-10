using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelloMvc.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblDersler",
                columns: table => new
                {
                    DersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DersAd = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    DersKodu = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDersler", x => x.DersId);
                });

            migrationBuilder.CreateTable(
                name: "tblOgrenciDersleri",
                columns: table => new
                {
                    Ogrenciid = table.Column<int>(type: "int", nullable: false),
                    Dersid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOgrenciDersleri", x => new { x.Ogrenciid, x.Dersid });
                    table.ForeignKey(
                        name: "FK_tblOgrenciDersleri_TblOgrenciler_Ogrenciid",
                        column: x => x.Ogrenciid,
                        principalTable: "TblOgrenciler",
                        principalColumn: "Ogrenciid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblOgrenciDersleri_tblDersler_Dersid",
                        column: x => x.Dersid,
                        principalTable: "tblDersler",
                        principalColumn: "DersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblOgrenciDersleri_Dersid",
                table: "tblOgrenciDersleri",
                column: "Dersid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblOgrenciDersleri");

            migrationBuilder.DropTable(
                name: "tblDersler");
        }
    }
}
