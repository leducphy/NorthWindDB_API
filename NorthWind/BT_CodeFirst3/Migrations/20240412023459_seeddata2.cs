using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BT_CodeFirst3.Migrations
{
    public partial class seeddata2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Khoas",
                columns: new[] { "MaKH", "SLSV", "TenKH" },
                values: new object[,]
                {
                    { "CNPM", 0, "Công nghệ phần mềm" },
                    { "HTTT", 0, "Hệ thống thông tin" },
                    { "KHMT", 0, "Khoa học máy tính" },
                    { "KTMT", 0, "Kỹ thuật máy tính" },
                    { "MANG", 0, "Mạng và truyền thông" }
                });

            migrationBuilder.InsertData(
                table: "MonHocs",
                columns: new[] { "MaMH", "SoTiet", "TenMH" },
                values: new object[,]
                {
                    { "CSDL", (byte)45, "Cơ sở dữ liệu" },
                    { "CTDL", (byte)60, "Cấu trúc dữ liệu" },
                    { "DHMT", (byte)60, "Đồ họa máy tính" },
                    { "MMT", (byte)45, "Mạng máy tính" },
                    { "TTNT", (byte)45, "Trí tuệ nhân tạo" }
                });

            migrationBuilder.InsertData(
                table: "SinhViens",
                columns: new[] { "MaSV", "DiemTB", "HoSV", "HocBong", "MaKH", "NGSinh", "NoiSinh", "Phai", "TenSV" },
                values: new object[,]
                {
                    { "SV01", 0m, "Lê Kim", 130000m, "HTTT", new DateTime(1990, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "Nữ", "Lan" },
                    { "SV02", 0m, "Trần Minh", 150000m, "MANG", new DateTime(1992, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bình Định", "Nam", "Chánh" },
                    { "SV03", 0m, "Lê An", 170000m, "HTTT", new DateTime(1991, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hải Phòng", "Nữ", "Tuyết" },
                    { "SV04", 0m, "Trần Anh", 80000m, "MANG", new DateTime(1993, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "TpHCM", "Nam", "Tuấn" },
                    { "SV05", 0m, "Trần Thị", 0m, "CNPM", new DateTime(1991, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "TpHCM", "Nữ", "Mai" },
                    { "SV06", 0m, "Lê Thị Thu", 0m, "HTTT", new DateTime(1991, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "An Giang", "Nữ", "Thủy" },
                    { "SV07", 0m, "Nguyễn Kim", 180000m, "CNPM", new DateTime(1990, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "Nữ", "Thư" },
                    { "SV08", 0m, "Lê Văn", 190000m, "HTTT", new DateTime(1992, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "TpHCM", "Nam", "Long" }
                });

            migrationBuilder.InsertData(
                table: "KetQuas",
                columns: new[] { "LanThi", "MaMH", "MaSV", "Diem", "KQ" },
                values: new object[,]
                {
                    { (byte)1, "CSDL", "SV01", 3m, "" },
                    { (byte)2, "CSDL", "SV01", 6m, "" },
                    { (byte)1, "MMT", "SV01", 5m, "" },
                    { (byte)1, "TTNT", "SV01", 5m, "" },
                    { (byte)2, "TTNT", "SV01", 6m, "" },
                    { (byte)1, "CSDL", "SV02", 4m, "" },
                    { (byte)2, "CSDL", "SV02", 7m, "" },
                    { (byte)1, "CTDL", "SV02", 9m, "" },
                    { (byte)1, "MMT", "SV02", 10m, "" },
                    { (byte)1, "CSDL", "SV03", 2m, "" },
                    { (byte)2, "CSDL", "SV03", 5m, "" },
                    { (byte)1, "MMT", "SV03", 2m, "" },
                    { (byte)2, "MMT", "SV03", 4m, "" },
                    { (byte)1, "CSDL", "SV04", 4m, "" },
                    { (byte)1, "CTDL", "SV04", 10m, "" },
                    { (byte)1, "CSDL", "SV05", 7m, "" },
                    { (byte)1, "MMT", "SV05", 2m, "" },
                    { (byte)2, "MMT", "SV05", 5m, "" },
                    { (byte)1, "DHMT", "SV06", 10m, "" },
                    { (byte)1, "TTNT", "SV06", 6m, "" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "KetQuas",
                keyColumns: new[] { "LanThi", "MaMH", "MaSV" },
                keyValues: new object[] { (byte)1, "CSDL", "SV01" });

            migrationBuilder.DeleteData(
                table: "KetQuas",
                keyColumns: new[] { "LanThi", "MaMH", "MaSV" },
                keyValues: new object[] { (byte)2, "CSDL", "SV01" });

            migrationBuilder.DeleteData(
                table: "KetQuas",
                keyColumns: new[] { "LanThi", "MaMH", "MaSV" },
                keyValues: new object[] { (byte)1, "MMT", "SV01" });

            migrationBuilder.DeleteData(
                table: "KetQuas",
                keyColumns: new[] { "LanThi", "MaMH", "MaSV" },
                keyValues: new object[] { (byte)1, "TTNT", "SV01" });

            migrationBuilder.DeleteData(
                table: "KetQuas",
                keyColumns: new[] { "LanThi", "MaMH", "MaSV" },
                keyValues: new object[] { (byte)2, "TTNT", "SV01" });

            migrationBuilder.DeleteData(
                table: "KetQuas",
                keyColumns: new[] { "LanThi", "MaMH", "MaSV" },
                keyValues: new object[] { (byte)1, "CSDL", "SV02" });

            migrationBuilder.DeleteData(
                table: "KetQuas",
                keyColumns: new[] { "LanThi", "MaMH", "MaSV" },
                keyValues: new object[] { (byte)2, "CSDL", "SV02" });

            migrationBuilder.DeleteData(
                table: "KetQuas",
                keyColumns: new[] { "LanThi", "MaMH", "MaSV" },
                keyValues: new object[] { (byte)1, "CTDL", "SV02" });

            migrationBuilder.DeleteData(
                table: "KetQuas",
                keyColumns: new[] { "LanThi", "MaMH", "MaSV" },
                keyValues: new object[] { (byte)1, "MMT", "SV02" });

            migrationBuilder.DeleteData(
                table: "KetQuas",
                keyColumns: new[] { "LanThi", "MaMH", "MaSV" },
                keyValues: new object[] { (byte)1, "CSDL", "SV03" });

            migrationBuilder.DeleteData(
                table: "KetQuas",
                keyColumns: new[] { "LanThi", "MaMH", "MaSV" },
                keyValues: new object[] { (byte)2, "CSDL", "SV03" });

            migrationBuilder.DeleteData(
                table: "KetQuas",
                keyColumns: new[] { "LanThi", "MaMH", "MaSV" },
                keyValues: new object[] { (byte)1, "MMT", "SV03" });

            migrationBuilder.DeleteData(
                table: "KetQuas",
                keyColumns: new[] { "LanThi", "MaMH", "MaSV" },
                keyValues: new object[] { (byte)2, "MMT", "SV03" });

            migrationBuilder.DeleteData(
                table: "KetQuas",
                keyColumns: new[] { "LanThi", "MaMH", "MaSV" },
                keyValues: new object[] { (byte)1, "CSDL", "SV04" });

            migrationBuilder.DeleteData(
                table: "KetQuas",
                keyColumns: new[] { "LanThi", "MaMH", "MaSV" },
                keyValues: new object[] { (byte)1, "CTDL", "SV04" });

            migrationBuilder.DeleteData(
                table: "KetQuas",
                keyColumns: new[] { "LanThi", "MaMH", "MaSV" },
                keyValues: new object[] { (byte)1, "CSDL", "SV05" });

            migrationBuilder.DeleteData(
                table: "KetQuas",
                keyColumns: new[] { "LanThi", "MaMH", "MaSV" },
                keyValues: new object[] { (byte)1, "MMT", "SV05" });

            migrationBuilder.DeleteData(
                table: "KetQuas",
                keyColumns: new[] { "LanThi", "MaMH", "MaSV" },
                keyValues: new object[] { (byte)2, "MMT", "SV05" });

            migrationBuilder.DeleteData(
                table: "KetQuas",
                keyColumns: new[] { "LanThi", "MaMH", "MaSV" },
                keyValues: new object[] { (byte)1, "DHMT", "SV06" });

            migrationBuilder.DeleteData(
                table: "KetQuas",
                keyColumns: new[] { "LanThi", "MaMH", "MaSV" },
                keyValues: new object[] { (byte)1, "TTNT", "SV06" });

            migrationBuilder.DeleteData(
                table: "Khoas",
                keyColumn: "MaKH",
                keyValue: "KHMT");

            migrationBuilder.DeleteData(
                table: "Khoas",
                keyColumn: "MaKH",
                keyValue: "KTMT");

            migrationBuilder.DeleteData(
                table: "SinhViens",
                keyColumn: "MaSV",
                keyValue: "SV07");

            migrationBuilder.DeleteData(
                table: "SinhViens",
                keyColumn: "MaSV",
                keyValue: "SV08");

            migrationBuilder.DeleteData(
                table: "MonHocs",
                keyColumn: "MaMH",
                keyValue: "CSDL");

            migrationBuilder.DeleteData(
                table: "MonHocs",
                keyColumn: "MaMH",
                keyValue: "CTDL");

            migrationBuilder.DeleteData(
                table: "MonHocs",
                keyColumn: "MaMH",
                keyValue: "DHMT");

            migrationBuilder.DeleteData(
                table: "MonHocs",
                keyColumn: "MaMH",
                keyValue: "MMT");

            migrationBuilder.DeleteData(
                table: "MonHocs",
                keyColumn: "MaMH",
                keyValue: "TTNT");

            migrationBuilder.DeleteData(
                table: "SinhViens",
                keyColumn: "MaSV",
                keyValue: "SV01");

            migrationBuilder.DeleteData(
                table: "SinhViens",
                keyColumn: "MaSV",
                keyValue: "SV02");

            migrationBuilder.DeleteData(
                table: "SinhViens",
                keyColumn: "MaSV",
                keyValue: "SV03");

            migrationBuilder.DeleteData(
                table: "SinhViens",
                keyColumn: "MaSV",
                keyValue: "SV04");

            migrationBuilder.DeleteData(
                table: "SinhViens",
                keyColumn: "MaSV",
                keyValue: "SV05");

            migrationBuilder.DeleteData(
                table: "SinhViens",
                keyColumn: "MaSV",
                keyValue: "SV06");

            migrationBuilder.DeleteData(
                table: "Khoas",
                keyColumn: "MaKH",
                keyValue: "CNPM");

            migrationBuilder.DeleteData(
                table: "Khoas",
                keyColumn: "MaKH",
                keyValue: "HTTT");

            migrationBuilder.DeleteData(
                table: "Khoas",
                keyColumn: "MaKH",
                keyValue: "MANG");
        }
    }
}
