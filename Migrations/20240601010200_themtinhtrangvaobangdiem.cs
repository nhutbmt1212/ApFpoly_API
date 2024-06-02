using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApFpoly_API.Migrations
{
    /// <inheritdoc />
    public partial class themtinhtrangvaobangdiem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TinhTrang",
                table: "BangDiem",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV001",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 8, 1, 58, 509, DateTimeKind.Local).AddTicks(6583));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV002",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 8, 1, 58, 509, DateTimeKind.Local).AddTicks(6586));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV003",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 8, 1, 58, 509, DateTimeKind.Local).AddTicks(6589));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV004",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 8, 1, 58, 509, DateTimeKind.Local).AddTicks(6591));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV005",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 8, 1, 58, 509, DateTimeKind.Local).AddTicks(6593));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV006",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 8, 1, 58, 509, DateTimeKind.Local).AddTicks(6596));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV007",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 8, 1, 58, 509, DateTimeKind.Local).AddTicks(6598));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV008",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 8, 1, 58, 509, DateTimeKind.Local).AddTicks(6600));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV009",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 8, 1, 58, 509, DateTimeKind.Local).AddTicks(6602));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV010",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 8, 1, 58, 509, DateTimeKind.Local).AddTicks(6604));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH001",
                column: "NgayTao",
                value: new DateTime(2024, 2, 22, 8, 1, 58, 509, DateTimeKind.Local).AddTicks(6242));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH002",
                column: "NgayTao",
                value: new DateTime(2024, 3, 3, 8, 1, 58, 509, DateTimeKind.Local).AddTicks(6264));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH003",
                column: "NgayTao",
                value: new DateTime(2024, 3, 13, 8, 1, 58, 509, DateTimeKind.Local).AddTicks(6266));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH004",
                column: "NgayTao",
                value: new DateTime(2024, 3, 23, 8, 1, 58, 509, DateTimeKind.Local).AddTicks(6267));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH005",
                column: "NgayTao",
                value: new DateTime(2024, 4, 2, 8, 1, 58, 509, DateTimeKind.Local).AddTicks(6268));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH006",
                column: "NgayTao",
                value: new DateTime(2024, 4, 12, 8, 1, 58, 509, DateTimeKind.Local).AddTicks(6269));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH007",
                column: "NgayTao",
                value: new DateTime(2024, 4, 22, 8, 1, 58, 509, DateTimeKind.Local).AddTicks(6270));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH008",
                column: "NgayTao",
                value: new DateTime(2024, 5, 2, 8, 1, 58, 509, DateTimeKind.Local).AddTicks(6272));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH009",
                column: "NgayTao",
                value: new DateTime(2024, 5, 12, 8, 1, 58, 509, DateTimeKind.Local).AddTicks(6273));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH010",
                column: "NgayTao",
                value: new DateTime(2024, 5, 22, 8, 1, 58, 509, DateTimeKind.Local).AddTicks(6274));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV001",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 8, 1, 58, 509, DateTimeKind.Local).AddTicks(6406));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV002",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 8, 1, 58, 509, DateTimeKind.Local).AddTicks(6409));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV003",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 8, 1, 58, 509, DateTimeKind.Local).AddTicks(6412));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV004",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 8, 1, 58, 509, DateTimeKind.Local).AddTicks(6414));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV005",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 8, 1, 58, 509, DateTimeKind.Local).AddTicks(6417));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV006",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 8, 1, 58, 509, DateTimeKind.Local).AddTicks(6420));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV007",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 8, 1, 58, 509, DateTimeKind.Local).AddTicks(6422));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV008",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 8, 1, 58, 509, DateTimeKind.Local).AddTicks(6424));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV009",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 8, 1, 58, 509, DateTimeKind.Local).AddTicks(6426));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV010",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 8, 1, 58, 509, DateTimeKind.Local).AddTicks(6429));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TinhTrang",
                table: "BangDiem");

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV001",
                column: "NgayThem",
                value: new DateTime(2024, 5, 31, 13, 56, 14, 702, DateTimeKind.Local).AddTicks(5219));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV002",
                column: "NgayThem",
                value: new DateTime(2024, 5, 31, 13, 56, 14, 702, DateTimeKind.Local).AddTicks(5223));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV003",
                column: "NgayThem",
                value: new DateTime(2024, 5, 31, 13, 56, 14, 702, DateTimeKind.Local).AddTicks(5225));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV004",
                column: "NgayThem",
                value: new DateTime(2024, 5, 31, 13, 56, 14, 702, DateTimeKind.Local).AddTicks(5228));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV005",
                column: "NgayThem",
                value: new DateTime(2024, 5, 31, 13, 56, 14, 702, DateTimeKind.Local).AddTicks(5230));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV006",
                column: "NgayThem",
                value: new DateTime(2024, 5, 31, 13, 56, 14, 702, DateTimeKind.Local).AddTicks(5232));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV007",
                column: "NgayThem",
                value: new DateTime(2024, 5, 31, 13, 56, 14, 702, DateTimeKind.Local).AddTicks(5234));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV008",
                column: "NgayThem",
                value: new DateTime(2024, 5, 31, 13, 56, 14, 702, DateTimeKind.Local).AddTicks(5237));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV009",
                column: "NgayThem",
                value: new DateTime(2024, 5, 31, 13, 56, 14, 702, DateTimeKind.Local).AddTicks(5239));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV010",
                column: "NgayThem",
                value: new DateTime(2024, 5, 31, 13, 56, 14, 702, DateTimeKind.Local).AddTicks(5241));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH001",
                column: "NgayTao",
                value: new DateTime(2024, 2, 21, 13, 56, 14, 702, DateTimeKind.Local).AddTicks(4889));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH002",
                column: "NgayTao",
                value: new DateTime(2024, 3, 2, 13, 56, 14, 702, DateTimeKind.Local).AddTicks(4904));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH003",
                column: "NgayTao",
                value: new DateTime(2024, 3, 12, 13, 56, 14, 702, DateTimeKind.Local).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH004",
                column: "NgayTao",
                value: new DateTime(2024, 3, 22, 13, 56, 14, 702, DateTimeKind.Local).AddTicks(4907));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH005",
                column: "NgayTao",
                value: new DateTime(2024, 4, 1, 13, 56, 14, 702, DateTimeKind.Local).AddTicks(4908));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH006",
                column: "NgayTao",
                value: new DateTime(2024, 4, 11, 13, 56, 14, 702, DateTimeKind.Local).AddTicks(4910));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH007",
                column: "NgayTao",
                value: new DateTime(2024, 4, 21, 13, 56, 14, 702, DateTimeKind.Local).AddTicks(4911));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH008",
                column: "NgayTao",
                value: new DateTime(2024, 5, 1, 13, 56, 14, 702, DateTimeKind.Local).AddTicks(4912));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH009",
                column: "NgayTao",
                value: new DateTime(2024, 5, 11, 13, 56, 14, 702, DateTimeKind.Local).AddTicks(4913));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH010",
                column: "NgayTao",
                value: new DateTime(2024, 5, 21, 13, 56, 14, 702, DateTimeKind.Local).AddTicks(4914));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV001",
                column: "NgayThem",
                value: new DateTime(2024, 5, 31, 13, 56, 14, 702, DateTimeKind.Local).AddTicks(5029));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV002",
                column: "NgayThem",
                value: new DateTime(2024, 5, 31, 13, 56, 14, 702, DateTimeKind.Local).AddTicks(5033));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV003",
                column: "NgayThem",
                value: new DateTime(2024, 5, 31, 13, 56, 14, 702, DateTimeKind.Local).AddTicks(5036));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV004",
                column: "NgayThem",
                value: new DateTime(2024, 5, 31, 13, 56, 14, 702, DateTimeKind.Local).AddTicks(5039));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV005",
                column: "NgayThem",
                value: new DateTime(2024, 5, 31, 13, 56, 14, 702, DateTimeKind.Local).AddTicks(5042));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV006",
                column: "NgayThem",
                value: new DateTime(2024, 5, 31, 13, 56, 14, 702, DateTimeKind.Local).AddTicks(5045));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV007",
                column: "NgayThem",
                value: new DateTime(2024, 5, 31, 13, 56, 14, 702, DateTimeKind.Local).AddTicks(5047));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV008",
                column: "NgayThem",
                value: new DateTime(2024, 5, 31, 13, 56, 14, 702, DateTimeKind.Local).AddTicks(5050));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV009",
                column: "NgayThem",
                value: new DateTime(2024, 5, 31, 13, 56, 14, 702, DateTimeKind.Local).AddTicks(5052));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV010",
                column: "NgayThem",
                value: new DateTime(2024, 5, 31, 13, 56, 14, 702, DateTimeKind.Local).AddTicks(5054));
        }
    }
}
