using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApFpoly_API.Migrations
{
    /// <inheritdoc />
    public partial class data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV001",
                column: "NgayThem",
                value: new DateTime(2024, 5, 18, 14, 49, 41, 317, DateTimeKind.Local).AddTicks(6954));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV002",
                column: "NgayThem",
                value: new DateTime(2024, 5, 18, 14, 49, 41, 317, DateTimeKind.Local).AddTicks(6957));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV003",
                column: "NgayThem",
                value: new DateTime(2024, 5, 18, 14, 49, 41, 317, DateTimeKind.Local).AddTicks(6960));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV004",
                column: "NgayThem",
                value: new DateTime(2024, 5, 18, 14, 49, 41, 317, DateTimeKind.Local).AddTicks(6962));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV005",
                column: "NgayThem",
                value: new DateTime(2024, 5, 18, 14, 49, 41, 317, DateTimeKind.Local).AddTicks(6964));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV006",
                column: "NgayThem",
                value: new DateTime(2024, 5, 18, 14, 49, 41, 317, DateTimeKind.Local).AddTicks(6966));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV007",
                column: "NgayThem",
                value: new DateTime(2024, 5, 18, 14, 49, 41, 317, DateTimeKind.Local).AddTicks(6968));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV008",
                column: "NgayThem",
                value: new DateTime(2024, 5, 18, 14, 49, 41, 317, DateTimeKind.Local).AddTicks(6971));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV009",
                column: "NgayThem",
                value: new DateTime(2024, 5, 18, 14, 49, 41, 317, DateTimeKind.Local).AddTicks(6973));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV010",
                column: "NgayThem",
                value: new DateTime(2024, 5, 18, 14, 49, 41, 317, DateTimeKind.Local).AddTicks(6975));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH001",
                column: "NgayTao",
                value: new DateTime(2024, 2, 8, 14, 49, 41, 317, DateTimeKind.Local).AddTicks(6618));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH002",
                column: "NgayTao",
                value: new DateTime(2024, 2, 18, 14, 49, 41, 317, DateTimeKind.Local).AddTicks(6633));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH003",
                column: "NgayTao",
                value: new DateTime(2024, 2, 28, 14, 49, 41, 317, DateTimeKind.Local).AddTicks(6635));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH004",
                column: "NgayTao",
                value: new DateTime(2024, 3, 9, 14, 49, 41, 317, DateTimeKind.Local).AddTicks(6636));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH005",
                column: "NgayTao",
                value: new DateTime(2024, 3, 19, 14, 49, 41, 317, DateTimeKind.Local).AddTicks(6637));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH006",
                column: "NgayTao",
                value: new DateTime(2024, 3, 29, 14, 49, 41, 317, DateTimeKind.Local).AddTicks(6639));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH007",
                column: "NgayTao",
                value: new DateTime(2024, 4, 8, 14, 49, 41, 317, DateTimeKind.Local).AddTicks(6640));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH008",
                column: "NgayTao",
                value: new DateTime(2024, 4, 18, 14, 49, 41, 317, DateTimeKind.Local).AddTicks(6641));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH009",
                column: "NgayTao",
                value: new DateTime(2024, 4, 28, 14, 49, 41, 317, DateTimeKind.Local).AddTicks(6642));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH010",
                column: "NgayTao",
                value: new DateTime(2024, 5, 8, 14, 49, 41, 317, DateTimeKind.Local).AddTicks(6643));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV001",
                columns: new[] { "AnhSinhVien", "NgayThem" },
                values: new object[] { "pexels-justin-shaifer-501272-1222271.jpg", new DateTime(2024, 5, 18, 14, 49, 41, 317, DateTimeKind.Local).AddTicks(6813) });

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV002",
                columns: new[] { "AnhSinhVien", "NgayThem" },
                values: new object[] { "360_F_243123463_zTooub557xEWABDLk0jJklDyLSGl2jrr.jpg", new DateTime(2024, 5, 18, 14, 49, 41, 317, DateTimeKind.Local).AddTicks(6817) });

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV003",
                columns: new[] { "AnhSinhVien", "NgayThem" },
                values: new object[] { "pexels-simon-robben-55958-614810.jpg", new DateTime(2024, 5, 18, 14, 49, 41, 317, DateTimeKind.Local).AddTicks(6819) });

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV004",
                columns: new[] { "AnhSinhVien", "NgayThem" },
                values: new object[] { "images.jpg", new DateTime(2024, 5, 18, 14, 49, 41, 317, DateTimeKind.Local).AddTicks(6822) });

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV005",
                columns: new[] { "AnhSinhVien", "NgayThem" },
                values: new object[] { "pexels-simon-robben-55958-614810.jpg", new DateTime(2024, 5, 18, 14, 49, 41, 317, DateTimeKind.Local).AddTicks(6824) });

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV006",
                columns: new[] { "AnhSinhVien", "NgayThem" },
                values: new object[] { "images.jpg", new DateTime(2024, 5, 18, 14, 49, 41, 317, DateTimeKind.Local).AddTicks(6826) });

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV007",
                columns: new[] { "AnhSinhVien", "NgayThem" },
                values: new object[] { "pexels-justin-shaifer-501272-1222271.jpg", new DateTime(2024, 5, 18, 14, 49, 41, 317, DateTimeKind.Local).AddTicks(6829) });

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV008",
                columns: new[] { "AnhSinhVien", "NgayThem" },
                values: new object[] { "360_F_243123463_zTooub557xEWABDLk0jJklDyLSGl2jrr.jpg", new DateTime(2024, 5, 18, 14, 49, 41, 317, DateTimeKind.Local).AddTicks(6831) });

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV009",
                columns: new[] { "AnhSinhVien", "NgayThem" },
                values: new object[] { "pexels-simon-robben-55958-614810.jpg", new DateTime(2024, 5, 18, 14, 49, 41, 317, DateTimeKind.Local).AddTicks(6834) });

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV010",
                columns: new[] { "AnhSinhVien", "NgayThem" },
                values: new object[] { "images.jpg", new DateTime(2024, 5, 18, 14, 49, 41, 317, DateTimeKind.Local).AddTicks(6836) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV001",
                column: "NgayThem",
                value: new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(7084));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV002",
                column: "NgayThem",
                value: new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(7088));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV003",
                column: "NgayThem",
                value: new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(7090));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV004",
                column: "NgayThem",
                value: new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(7092));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV005",
                column: "NgayThem",
                value: new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(7095));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV006",
                column: "NgayThem",
                value: new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(7097));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV007",
                column: "NgayThem",
                value: new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(7099));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV008",
                column: "NgayThem",
                value: new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(7102));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV009",
                column: "NgayThem",
                value: new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(7104));

            migrationBuilder.UpdateData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV010",
                column: "NgayThem",
                value: new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(7106));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH001",
                column: "NgayTao",
                value: new DateTime(2024, 2, 7, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6768));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH002",
                column: "NgayTao",
                value: new DateTime(2024, 2, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6784));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH003",
                column: "NgayTao",
                value: new DateTime(2024, 2, 27, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6786));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH004",
                column: "NgayTao",
                value: new DateTime(2024, 3, 8, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6787));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH005",
                column: "NgayTao",
                value: new DateTime(2024, 3, 18, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6788));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH006",
                column: "NgayTao",
                value: new DateTime(2024, 3, 28, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6790));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH007",
                column: "NgayTao",
                value: new DateTime(2024, 4, 7, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6791));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH008",
                column: "NgayTao",
                value: new DateTime(2024, 4, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6792));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH009",
                column: "NgayTao",
                value: new DateTime(2024, 4, 27, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6793));

            migrationBuilder.UpdateData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH010",
                column: "NgayTao",
                value: new DateTime(2024, 5, 7, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6795));

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV001",
                columns: new[] { "AnhSinhVien", "NgayThem" },
                values: new object[] { "nguyenvana.jpg", new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6915) });

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV002",
                columns: new[] { "AnhSinhVien", "NgayThem" },
                values: new object[] { "tranthib.jpg", new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6919) });

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV003",
                columns: new[] { "AnhSinhVien", "NgayThem" },
                values: new object[] { "levanc.jpg", new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6921) });

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV004",
                columns: new[] { "AnhSinhVien", "NgayThem" },
                values: new object[] { "phamthid.jpg", new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6924) });

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV005",
                columns: new[] { "AnhSinhVien", "NgayThem" },
                values: new object[] { "hoangvane.jpg", new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6926) });

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV006",
                columns: new[] { "AnhSinhVien", "NgayThem" },
                values: new object[] { "dothif.jpg", new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6928) });

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV007",
                columns: new[] { "AnhSinhVien", "NgayThem" },
                values: new object[] { "ngovang.jpg", new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6931) });

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV008",
                columns: new[] { "AnhSinhVien", "NgayThem" },
                values: new object[] { "phanthih.jpg", new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6933) });

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV009",
                columns: new[] { "AnhSinhVien", "NgayThem" },
                values: new object[] { "buivani.jpg", new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6935) });

            migrationBuilder.UpdateData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV010",
                columns: new[] { "AnhSinhVien", "NgayThem" },
                values: new object[] { "vothik.jpg", new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6937) });
        }
    }
}
