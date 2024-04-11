using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BT_CodeFirst3.Migrations
{
    public partial class ver2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TENSV",
                table: "SinhViens",
                newName: "TenSV");

            migrationBuilder.RenameColumn(
                name: "PHAI",
                table: "SinhViens",
                newName: "Phai");

            migrationBuilder.RenameColumn(
                name: "NOISINH",
                table: "SinhViens",
                newName: "NoiSinh");

            migrationBuilder.RenameColumn(
                name: "HOSV",
                table: "SinhViens",
                newName: "HoSV");

            migrationBuilder.RenameColumn(
                name: "HOCBONG",
                table: "SinhViens",
                newName: "HocBong");

            migrationBuilder.RenameColumn(
                name: "DIEMTB",
                table: "SinhViens",
                newName: "DiemTB");

            migrationBuilder.RenameColumn(
                name: "MASV",
                table: "SinhViens",
                newName: "MaSV");

            migrationBuilder.RenameColumn(
                name: "NGSINH",
                table: "SinhViens",
                newName: "NgaySinh");

            migrationBuilder.RenameColumn(
                name: "MAKH",
                table: "SinhViens",
                newName: "MaKhoa");

            migrationBuilder.RenameIndex(
                name: "IX_SinhViens_MAKH",
                table: "SinhViens",
                newName: "IX_SinhViens_MaKhoa");

            migrationBuilder.RenameColumn(
                name: "TENMH",
                table: "MonHocs",
                newName: "TenMH");

            migrationBuilder.RenameColumn(
                name: "SOTIET",
                table: "MonHocs",
                newName: "SoTiet");

            migrationBuilder.RenameColumn(
                name: "MAMH",
                table: "MonHocs",
                newName: "MaMH");

            migrationBuilder.RenameColumn(
                name: "TENKH",
                table: "Khoas",
                newName: "TenKhoa");

            migrationBuilder.RenameColumn(
                name: "SLSV",
                table: "Khoas",
                newName: "SoLuongSinhVien");

            migrationBuilder.RenameColumn(
                name: "MAKH",
                table: "Khoas",
                newName: "MaKhoa");

            migrationBuilder.RenameColumn(
                name: "DIEM",
                table: "KetQuas",
                newName: "Diem");

            migrationBuilder.RenameColumn(
                name: "LANTHI",
                table: "KetQuas",
                newName: "LanThi");

            migrationBuilder.RenameColumn(
                name: "MAMH",
                table: "KetQuas",
                newName: "MaMH");

            migrationBuilder.RenameColumn(
                name: "MASV",
                table: "KetQuas",
                newName: "MaSV");

            migrationBuilder.RenameIndex(
                name: "IX_KetQuas_MAMH",
                table: "KetQuas",
                newName: "IX_KetQuas_MaMH");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TenSV",
                table: "SinhViens",
                newName: "TENSV");

            migrationBuilder.RenameColumn(
                name: "Phai",
                table: "SinhViens",
                newName: "PHAI");

            migrationBuilder.RenameColumn(
                name: "NoiSinh",
                table: "SinhViens",
                newName: "NOISINH");

            migrationBuilder.RenameColumn(
                name: "HocBong",
                table: "SinhViens",
                newName: "HOCBONG");

            migrationBuilder.RenameColumn(
                name: "HoSV",
                table: "SinhViens",
                newName: "HOSV");

            migrationBuilder.RenameColumn(
                name: "DiemTB",
                table: "SinhViens",
                newName: "DIEMTB");

            migrationBuilder.RenameColumn(
                name: "MaSV",
                table: "SinhViens",
                newName: "MASV");

            migrationBuilder.RenameColumn(
                name: "NgaySinh",
                table: "SinhViens",
                newName: "NGSINH");

            migrationBuilder.RenameColumn(
                name: "MaKhoa",
                table: "SinhViens",
                newName: "MAKH");

            migrationBuilder.RenameIndex(
                name: "IX_SinhViens_MaKhoa",
                table: "SinhViens",
                newName: "IX_SinhViens_MAKH");

            migrationBuilder.RenameColumn(
                name: "TenMH",
                table: "MonHocs",
                newName: "TENMH");

            migrationBuilder.RenameColumn(
                name: "SoTiet",
                table: "MonHocs",
                newName: "SOTIET");

            migrationBuilder.RenameColumn(
                name: "MaMH",
                table: "MonHocs",
                newName: "MAMH");

            migrationBuilder.RenameColumn(
                name: "TenKhoa",
                table: "Khoas",
                newName: "TENKH");

            migrationBuilder.RenameColumn(
                name: "SoLuongSinhVien",
                table: "Khoas",
                newName: "SLSV");

            migrationBuilder.RenameColumn(
                name: "MaKhoa",
                table: "Khoas",
                newName: "MAKH");

            migrationBuilder.RenameColumn(
                name: "Diem",
                table: "KetQuas",
                newName: "DIEM");

            migrationBuilder.RenameColumn(
                name: "LanThi",
                table: "KetQuas",
                newName: "LANTHI");

            migrationBuilder.RenameColumn(
                name: "MaMH",
                table: "KetQuas",
                newName: "MAMH");

            migrationBuilder.RenameColumn(
                name: "MaSV",
                table: "KetQuas",
                newName: "MASV");

            migrationBuilder.RenameIndex(
                name: "IX_KetQuas_MaMH",
                table: "KetQuas",
                newName: "IX_KetQuas_MAMH");
        }
    }
}
