using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class deneme12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblTarifler_TblKategoriler_KategoriId",
                table: "TblTarifler");

            migrationBuilder.DropIndex(
                name: "IX_TblTarifler_KategoriId",
                table: "TblTarifler");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TblTarifler_KategoriId",
                table: "TblTarifler",
                column: "KategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblTarifler_TblKategoriler_KategoriId",
                table: "TblTarifler",
                column: "KategoriId",
                principalTable: "TblKategoriler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
