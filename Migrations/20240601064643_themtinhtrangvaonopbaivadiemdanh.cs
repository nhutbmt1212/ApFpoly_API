using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApFpoly_API.Migrations
{
    /// <inheritdoc />
    public partial class themtinhtrangvaonopbaivadiemdanh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TinhTrang",
                table: "NopBai",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TinhTrang",
                table: "DiemDanh",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV001",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 13, 46, 41, 563, DateTimeKind.Local).AddTicks(3661));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV002",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 13, 46, 41, 563, DateTimeKind.Local).AddTicks(3664));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV003",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 13, 46, 41, 563, DateTimeKind.Local).AddTicks(3667));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV004",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 13, 46, 41, 563, DateTimeKind.Local).AddTicks(3669));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV005",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 13, 46, 41, 563, DateTimeKind.Local).AddTicks(3671));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV006",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 13, 46, 41, 563, DateTimeKind.Local).AddTicks(3673));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV007",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 13, 46, 41, 563, DateTimeKind.Local).AddTicks(3676));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV008",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 13, 46, 41, 563, DateTimeKind.Local).AddTicks(3678));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV009",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 13, 46, 41, 563, DateTimeKind.Local).AddTicks(3680));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV010",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 13, 46, 41, 563, DateTimeKind.Local).AddTicks(3683));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH001",
                column: "NgayTao",
                value: new DateTime(2024, 2, 22, 13, 46, 41, 563, DateTimeKind.Local).AddTicks(3323));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH002",
                column: "NgayTao",
                value: new DateTime(2024, 3, 3, 13, 46, 41, 563, DateTimeKind.Local).AddTicks(3344));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH003",
                column: "NgayTao",
                value: new DateTime(2024, 3, 13, 13, 46, 41, 563, DateTimeKind.Local).AddTicks(3346));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH004",
                column: "NgayTao",
                value: new DateTime(2024, 3, 23, 13, 46, 41, 563, DateTimeKind.Local).AddTicks(3347));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH005",
                column: "NgayTao",
                value: new DateTime(2024, 4, 2, 13, 46, 41, 563, DateTimeKind.Local).AddTicks(3348));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH006",
                column: "NgayTao",
                value: new DateTime(2024, 4, 12, 13, 46, 41, 563, DateTimeKind.Local).AddTicks(3349));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH007",
                column: "NgayTao",
                value: new DateTime(2024, 4, 22, 13, 46, 41, 563, DateTimeKind.Local).AddTicks(3351));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH008",
                column: "NgayTao",
                value: new DateTime(2024, 5, 2, 13, 46, 41, 563, DateTimeKind.Local).AddTicks(3352));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH009",
                column: "NgayTao",
                value: new DateTime(2024, 5, 12, 13, 46, 41, 563, DateTimeKind.Local).AddTicks(3353));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH010",
                column: "NgayTao",
                value: new DateTime(2024, 5, 22, 13, 46, 41, 563, DateTimeKind.Local).AddTicks(3354));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV001",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 13, 46, 41, 563, DateTimeKind.Local).AddTicks(3468));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV002",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 13, 46, 41, 563, DateTimeKind.Local).AddTicks(3471));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV003",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 13, 46, 41, 563, DateTimeKind.Local).AddTicks(3474));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV004",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 13, 46, 41, 563, DateTimeKind.Local).AddTicks(3476));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV005",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 13, 46, 41, 563, DateTimeKind.Local).AddTicks(3479));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV006",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 13, 46, 41, 563, DateTimeKind.Local).AddTicks(3481));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV007",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 13, 46, 41, 563, DateTimeKind.Local).AddTicks(3483));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV008",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 13, 46, 41, 563, DateTimeKind.Local).AddTicks(3485));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV009",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 13, 46, 41, 563, DateTimeKind.Local).AddTicks(3487));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV010",
                column: "NgayThem",
                value: new DateTime(2024, 6, 1, 13, 46, 41, 563, DateTimeKind.Local).AddTicks(3489));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TinhTrang",
                table: "NopBai");

            migrationBuilder.DropColumn(
                name: "TinhTrang",
                table: "DiemDanh");

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
    }
}
