using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BT_CodeFirst3.Migrations
{
    public partial class ver1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Khoas",
                columns: table => new
                {
                    MAKH = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    TENKH = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    SLSV = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoas", x => x.MAKH);
                });

            migrationBuilder.CreateTable(
                name: "MonHocs",
                columns: table => new
                {
                    MAMH = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    TENMH = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: false),
                    SOTIET = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonHocs", x => x.MAMH);
                });

            migrationBuilder.CreateTable(
                name: "SinhViens",
                columns: table => new
                {
                    MASV = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    HOSV = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    TENSV = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    PHAI = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    NGSINH = table.Column<DateTime>(type: "datetime", nullable: false),
                    NOISINH = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    MAKH = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    HOCBONG = table.Column<decimal>(type: "money", nullable: false),
                    DIEMTB = table.Column<decimal>(type: "numeric(4,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhViens", x => x.MASV);
                    table.ForeignKey(
                        name: "FK_SinhVien_Khoa",
                        column: x => x.MAKH,
                        principalTable: "Khoas",
                        principalColumn: "MAKH",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KetQuas",
                columns: table => new
                {
                    MASV = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    MAMH = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    LANTHI = table.Column<byte>(type: "tinyint", nullable: false),
                    DIEM = table.Column<decimal>(type: "numeric(4,2)", nullable: false),
                    KQ = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KetQuas", x => new { x.MASV, x.MAMH, x.LANTHI });
                    table.ForeignKey(
                        name: "FK_KetQua_MonHoc",
                        column: x => x.MAMH,
                        principalTable: "MonHocs",
                        principalColumn: "MAMH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KetQua_SinhVien",
                        column: x => x.MASV,
                        principalTable: "SinhViens",
                        principalColumn: "MASV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KetQuas_MAMH",
                table: "KetQuas",
                column: "MAMH");

            migrationBuilder.CreateIndex(
                name: "IX_SinhViens_MAKH",
                table: "SinhViens",
                column: "MAKH");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KetQuas");

            migrationBuilder.DropTable(
                name: "MonHocs");

            migrationBuilder.DropTable(
                name: "SinhViens");

            migrationBuilder.DropTable(
                name: "Khoas");
        }
    }
}
