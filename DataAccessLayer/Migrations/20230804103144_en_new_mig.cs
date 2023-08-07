using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class en_new_mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblContact_TblKullanici_Kullanici1Id",
                table: "TblContact");

            migrationBuilder.DropForeignKey(
                name: "FK_TblYorumlar_TblKullanici_KullaniciId",
                table: "TblYorumlar");

            migrationBuilder.DropForeignKey(
                name: "FK_TblYorumlar_TblTarifler_TarifId",
                table: "TblYorumlar");

            migrationBuilder.DropIndex(
                name: "IX_TblYorumlar_KullaniciId",
                table: "TblYorumlar");

            migrationBuilder.DropIndex(
                name: "IX_TblYorumlar_TarifId",
                table: "TblYorumlar");

            migrationBuilder.DropIndex(
                name: "IX_TblContact_Kullanici1Id",
                table: "TblContact");

            migrationBuilder.RenameColumn(
                name: "Kullanici1Id",
                table: "TblContact",
                newName: "kullaniciId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "kullaniciId",
                table: "TblContact",
                newName: "Kullanici1Id");

            migrationBuilder.CreateIndex(
                name: "IX_TblYorumlar_KullaniciId",
                table: "TblYorumlar",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_TblYorumlar_TarifId",
                table: "TblYorumlar",
                column: "TarifId");

            migrationBuilder.CreateIndex(
                name: "IX_TblContact_Kullanici1Id",
                table: "TblContact",
                column: "Kullanici1Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TblContact_TblKullanici_Kullanici1Id",
                table: "TblContact",
                column: "Kullanici1Id",
                principalTable: "TblKullanici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblYorumlar_TblKullanici_KullaniciId",
                table: "TblYorumlar",
                column: "KullaniciId",
                principalTable: "TblKullanici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblYorumlar_TblTarifler_TarifId",
                table: "TblYorumlar",
                column: "TarifId",
                principalTable: "TblTarifler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
