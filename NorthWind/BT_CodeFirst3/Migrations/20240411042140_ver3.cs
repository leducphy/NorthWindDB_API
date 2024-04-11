using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BT_CodeFirst3.Migrations
{
    public partial class ver3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NgaySinh",
                table: "SinhViens",
                newName: "NGSinh");

            migrationBuilder.RenameColumn(
                name: "MaKhoa",
                table: "SinhViens",
                newName: "MaKH");

            migrationBuilder.RenameIndex(
                name: "IX_SinhViens_MaKhoa",
                table: "SinhViens",
                newName: "IX_SinhViens_MaKH");

            migrationBuilder.RenameColumn(
                name: "TenKhoa",
                table: "Khoas",
                newName: "TenKH");

            migrationBuilder.RenameColumn(
                name: "SoLuongSinhVien",
                table: "Khoas",
                newName: "SLSV");

            migrationBuilder.RenameColumn(
                name: "MaKhoa",
                table: "Khoas",
                newName: "MaKH");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NGSinh",
                table: "SinhViens",
                newName: "NgaySinh");

            migrationBuilder.RenameColumn(
                name: "MaKH",
                table: "SinhViens",
                newName: "MaKhoa");

            migrationBuilder.RenameIndex(
                name: "IX_SinhViens_MaKH",
                table: "SinhViens",
                newName: "IX_SinhViens_MaKhoa");

            migrationBuilder.RenameColumn(
                name: "TenKH",
                table: "Khoas",
                newName: "TenKhoa");

            migrationBuilder.RenameColumn(
                name: "SLSV",
                table: "Khoas",
                newName: "SoLuongSinhVien");

            migrationBuilder.RenameColumn(
                name: "MaKH",
                table: "Khoas",
                newName: "MaKhoa");
        }
    }
}
