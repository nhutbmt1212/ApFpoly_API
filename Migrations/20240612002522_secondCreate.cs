using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApFpoly_API.Migrations
{
    /// <inheritdoc />
    public partial class secondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV00001",
                column: "NgayThem",
                value: new DateTime(2024, 6, 12, 7, 25, 20, 257, DateTimeKind.Local).AddTicks(3547));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV00002",
                column: "NgayThem",
                value: new DateTime(2024, 6, 12, 7, 25, 20, 257, DateTimeKind.Local).AddTicks(3553));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV00003",
                column: "NgayThem",
                value: new DateTime(2024, 6, 12, 7, 25, 20, 257, DateTimeKind.Local).AddTicks(3556));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV00004",
                column: "NgayThem",
                value: new DateTime(2024, 6, 12, 7, 25, 20, 257, DateTimeKind.Local).AddTicks(3559));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV00005",
                column: "NgayThem",
                value: new DateTime(2024, 6, 12, 7, 25, 20, 257, DateTimeKind.Local).AddTicks(3562));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV00006",
                column: "NgayThem",
                value: new DateTime(2024, 6, 12, 7, 25, 20, 257, DateTimeKind.Local).AddTicks(3565));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV00007",
                column: "NgayThem",
                value: new DateTime(2024, 6, 12, 7, 25, 20, 257, DateTimeKind.Local).AddTicks(3568));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV00008",
                column: "NgayThem",
                value: new DateTime(2024, 6, 12, 7, 25, 20, 257, DateTimeKind.Local).AddTicks(3572));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV00009",
                column: "NgayThem",
                value: new DateTime(2024, 6, 12, 7, 25, 20, 257, DateTimeKind.Local).AddTicks(3575));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV00010",
                column: "NgayThem",
                value: new DateTime(2024, 6, 12, 7, 25, 20, 257, DateTimeKind.Local).AddTicks(3578));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH00001",
                column: "NgayTao",
                value: new DateTime(2024, 3, 4, 7, 25, 20, 257, DateTimeKind.Local).AddTicks(3114));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH00002",
                column: "NgayTao",
                value: new DateTime(2024, 3, 14, 7, 25, 20, 257, DateTimeKind.Local).AddTicks(3131));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH00003",
                column: "NgayTao",
                value: new DateTime(2024, 3, 24, 7, 25, 20, 257, DateTimeKind.Local).AddTicks(3134));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH00004",
                column: "NgayTao",
                value: new DateTime(2024, 4, 3, 7, 25, 20, 257, DateTimeKind.Local).AddTicks(3135));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH00005",
                column: "NgayTao",
                value: new DateTime(2024, 4, 13, 7, 25, 20, 257, DateTimeKind.Local).AddTicks(3138));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH00006",
                column: "NgayTao",
                value: new DateTime(2024, 4, 23, 7, 25, 20, 257, DateTimeKind.Local).AddTicks(3140));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH00007",
                column: "NgayTao",
                value: new DateTime(2024, 5, 3, 7, 25, 20, 257, DateTimeKind.Local).AddTicks(3141));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH00008",
                column: "NgayTao",
                value: new DateTime(2024, 5, 13, 7, 25, 20, 257, DateTimeKind.Local).AddTicks(3143));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH00009",
                column: "NgayTao",
                value: new DateTime(2024, 5, 23, 7, 25, 20, 257, DateTimeKind.Local).AddTicks(3144));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH00010",
                column: "NgayTao",
                value: new DateTime(2024, 6, 2, 7, 25, 20, 257, DateTimeKind.Local).AddTicks(3146));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV00001",
                columns: new[] { "Email", "NgayThem" },
                values: new object[] { "nhutbmt82@gmail.com", new DateTime(2024, 6, 12, 7, 25, 20, 257, DateTimeKind.Local).AddTicks(3344) });

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV00002",
                column: "NgayThem",
                value: new DateTime(2024, 6, 12, 7, 25, 20, 257, DateTimeKind.Local).AddTicks(3349));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV00003",
                column: "NgayThem",
                value: new DateTime(2024, 6, 12, 7, 25, 20, 257, DateTimeKind.Local).AddTicks(3353));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV00004",
                column: "NgayThem",
                value: new DateTime(2024, 6, 12, 7, 25, 20, 257, DateTimeKind.Local).AddTicks(3358));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV00005",
                column: "NgayThem",
                value: new DateTime(2024, 6, 12, 7, 25, 20, 257, DateTimeKind.Local).AddTicks(3361));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV00006",
                column: "NgayThem",
                value: new DateTime(2024, 6, 12, 7, 25, 20, 257, DateTimeKind.Local).AddTicks(3365));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV00007",
                column: "NgayThem",
                value: new DateTime(2024, 6, 12, 7, 25, 20, 257, DateTimeKind.Local).AddTicks(3371));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV00008",
                column: "NgayThem",
                value: new DateTime(2024, 6, 12, 7, 25, 20, 257, DateTimeKind.Local).AddTicks(3375));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV00009",
                column: "NgayThem",
                value: new DateTime(2024, 6, 12, 7, 25, 20, 257, DateTimeKind.Local).AddTicks(3378));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV00010",
                column: "NgayThem",
                value: new DateTime(2024, 6, 12, 7, 25, 20, 257, DateTimeKind.Local).AddTicks(3383));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV00001",
                column: "NgayThem",
                value: new DateTime(2024, 6, 10, 8, 46, 26, 343, DateTimeKind.Local).AddTicks(190));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV00002",
                column: "NgayThem",
                value: new DateTime(2024, 6, 10, 8, 46, 26, 343, DateTimeKind.Local).AddTicks(195));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV00003",
                column: "NgayThem",
                value: new DateTime(2024, 6, 10, 8, 46, 26, 343, DateTimeKind.Local).AddTicks(199));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV00004",
                column: "NgayThem",
                value: new DateTime(2024, 6, 10, 8, 46, 26, 343, DateTimeKind.Local).AddTicks(202));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV00005",
                column: "NgayThem",
                value: new DateTime(2024, 6, 10, 8, 46, 26, 343, DateTimeKind.Local).AddTicks(205));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV00006",
                column: "NgayThem",
                value: new DateTime(2024, 6, 10, 8, 46, 26, 343, DateTimeKind.Local).AddTicks(208));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV00007",
                column: "NgayThem",
                value: new DateTime(2024, 6, 10, 8, 46, 26, 343, DateTimeKind.Local).AddTicks(211));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV00008",
                column: "NgayThem",
                value: new DateTime(2024, 6, 10, 8, 46, 26, 343, DateTimeKind.Local).AddTicks(214));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV00009",
                column: "NgayThem",
                value: new DateTime(2024, 6, 10, 8, 46, 26, 343, DateTimeKind.Local).AddTicks(217));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV00010",
                column: "NgayThem",
                value: new DateTime(2024, 6, 10, 8, 46, 26, 343, DateTimeKind.Local).AddTicks(220));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH00001",
                column: "NgayTao",
                value: new DateTime(2024, 3, 2, 8, 46, 26, 342, DateTimeKind.Local).AddTicks(9790));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH00002",
                column: "NgayTao",
                value: new DateTime(2024, 3, 12, 8, 46, 26, 342, DateTimeKind.Local).AddTicks(9805));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH00003",
                column: "NgayTao",
                value: new DateTime(2024, 3, 22, 8, 46, 26, 342, DateTimeKind.Local).AddTicks(9811));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH00004",
                column: "NgayTao",
                value: new DateTime(2024, 4, 1, 8, 46, 26, 342, DateTimeKind.Local).AddTicks(9813));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH00005",
                column: "NgayTao",
                value: new DateTime(2024, 4, 11, 8, 46, 26, 342, DateTimeKind.Local).AddTicks(9814));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH00006",
                column: "NgayTao",
                value: new DateTime(2024, 4, 21, 8, 46, 26, 342, DateTimeKind.Local).AddTicks(9816));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH00007",
                column: "NgayTao",
                value: new DateTime(2024, 5, 1, 8, 46, 26, 342, DateTimeKind.Local).AddTicks(9817));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH00008",
                column: "NgayTao",
                value: new DateTime(2024, 5, 11, 8, 46, 26, 342, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH00009",
                column: "NgayTao",
                value: new DateTime(2024, 5, 21, 8, 46, 26, 342, DateTimeKind.Local).AddTicks(9821));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH00010",
                column: "NgayTao",
                value: new DateTime(2024, 5, 31, 8, 46, 26, 342, DateTimeKind.Local).AddTicks(9822));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV00001",
                columns: new[] { "Email", "NgayThem" },
                values: new object[] { "nhutbmt82@gmai.com", new DateTime(2024, 6, 10, 8, 46, 26, 342, DateTimeKind.Local).AddTicks(9967) });

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV00002",
                column: "NgayThem",
                value: new DateTime(2024, 6, 10, 8, 46, 26, 342, DateTimeKind.Local).AddTicks(9972));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV00003",
                column: "NgayThem",
                value: new DateTime(2024, 6, 10, 8, 46, 26, 342, DateTimeKind.Local).AddTicks(9975));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV00004",
                column: "NgayThem",
                value: new DateTime(2024, 6, 10, 8, 46, 26, 342, DateTimeKind.Local).AddTicks(9979));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV00005",
                column: "NgayThem",
                value: new DateTime(2024, 6, 10, 8, 46, 26, 342, DateTimeKind.Local).AddTicks(9982));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV00006",
                column: "NgayThem",
                value: new DateTime(2024, 6, 10, 8, 46, 26, 342, DateTimeKind.Local).AddTicks(9985));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV00007",
                column: "NgayThem",
                value: new DateTime(2024, 6, 10, 8, 46, 26, 342, DateTimeKind.Local).AddTicks(9988));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV00008",
                column: "NgayThem",
                value: new DateTime(2024, 6, 10, 8, 46, 26, 343, DateTimeKind.Local).AddTicks(30));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV00009",
                column: "NgayThem",
                value: new DateTime(2024, 6, 10, 8, 46, 26, 343, DateTimeKind.Local).AddTicks(34));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV00010",
                column: "NgayThem",
                value: new DateTime(2024, 6, 10, 8, 46, 26, 343, DateTimeKind.Local).AddTicks(37));
        }
    }
}
