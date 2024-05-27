using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApFpoly_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GiangVien",
                columns: table => new
                {
                    MaGiangVien = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    TenGiangVien = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DanToc = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nganh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    NgayVaoLam = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ChucVu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NgayThem = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AnhGiangVien = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiangVien", x => x.MaGiangVien);
                });

            migrationBuilder.CreateTable(
                name: "HocKyBlock",
                columns: table => new
                {
                    MaHocKyBlock = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    TenHocKy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TenBlock = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocKyBlock", x => x.MaHocKyBlock);
                });

            migrationBuilder.CreateTable(
                name: "LopHoc",
                columns: table => new
                {
                    MaLop = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    TenLop = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SucChua = table.Column<short>(type: "smallint", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHoc", x => x.MaLop);
                });

            migrationBuilder.CreateTable(
                name: "MonHoc",
                columns: table => new
                {
                    MaMonHoc = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    TenMonHoc = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinChi = table.Column<short>(type: "smallint", nullable: true),
                    SoBuoi = table.Column<short>(type: "smallint", nullable: false),
                    NoiDungMonHoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiLieu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TinhTrang = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonHoc", x => x.MaMonHoc);
                });

            migrationBuilder.CreateTable(
                name: "PhongHoc",
                columns: table => new
                {
                    MaPhong = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    TenPhong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoaiPhong = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    SucChua = table.Column<short>(type: "smallint", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongHoc", x => x.MaPhong);
                });

            migrationBuilder.CreateTable(
                name: "SinhVien",
                columns: table => new
                {
                    MaSinhVien = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    TenSinhVien = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NgayNhapHoc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Khoa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ChuyenNganh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DanToc = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayThem = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AnhSinhVien = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVien", x => x.MaSinhVien);
                });

            migrationBuilder.CreateTable(
                name: "LichHoc",
                columns: table => new
                {
                    MaLichHoc = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    ThoiGianBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MaLop = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    MaHocKyBlock = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    MaPhong = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    MaGiangVien = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    MaMonHoc = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichHoc", x => x.MaLichHoc);
                    table.ForeignKey(
                        name: "FK_LichHoc_GiangVien_MaGiangVien",
                        column: x => x.MaGiangVien,
                        principalTable: "GiangVien",
                        principalColumn: "MaGiangVien",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LichHoc_HocKyBlock_MaHocKyBlock",
                        column: x => x.MaHocKyBlock,
                        principalTable: "HocKyBlock",
                        principalColumn: "MaHocKyBlock",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LichHoc_LopHoc_MaLop",
                        column: x => x.MaLop,
                        principalTable: "LopHoc",
                        principalColumn: "MaLop",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LichHoc_MonHoc_MaMonHoc",
                        column: x => x.MaMonHoc,
                        principalTable: "MonHoc",
                        principalColumn: "MaMonHoc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LichHoc_PhongHoc_MaPhong",
                        column: x => x.MaPhong,
                        principalTable: "PhongHoc",
                        principalColumn: "MaPhong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LopHocChiTiet",
                columns: table => new
                {
                    MaLopHocChiTiet = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    MaLop = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    MaSinhVien = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHocChiTiet", x => x.MaLopHocChiTiet);
                    table.ForeignKey(
                        name: "FK_LopHocChiTiet_LopHoc_MaLop",
                        column: x => x.MaLop,
                        principalTable: "LopHoc",
                        principalColumn: "MaLop",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LopHocChiTiet_SinhVien_MaSinhVien",
                        column: x => x.MaSinhVien,
                        principalTable: "SinhVien",
                        principalColumn: "MaSinhVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GiangVien",
                columns: new[] { "MaGiangVien", "AnhGiangVien", "CCCD", "ChucVu", "DanToc", "DiaChi", "Email", "GioiTinh", "Nganh", "NgaySinh", "NgayThem", "NgayVaoLam", "SoDienThoai", "TenGiangVien", "TinhTrang" },
                values: new object[,]
                {
                    { "GV001", "path/to/image.jpg", "123456789", "Giảng viên", "Kinh", "123 Đường ABC, Quận XYZ, TP HCM", "nguyenvana@example.com", "Nam", "Công nghệ thông tin", new DateTime(1980, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 27, 15, 15, 50, 503, DateTimeKind.Local).AddTicks(3199), new DateTime(2010, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "0123456789", "Nguyễn Văn A", "Đang hoạt động" },
                    { "GV002", "path/to/image.jpg", "987654321", "Phó trưởng khoa", "Kinh", "456 Đường XYZ, Quận ABC, TP HCM", "tranthib@example.com", "Nữ", "Kỹ thuật điện tử", new DateTime(1975, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 27, 15, 15, 50, 503, DateTimeKind.Local).AddTicks(3206), new DateTime(2008, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "0987654321", "Trần Thị B", "Đang hoạt động" },
                    { "GV003", "path/to/image.jpg", "987654321", "Trưởng khoa", "Kinh", "789 Đường XYZ, Quận XYZ, TP HCM", "phamthic@example.com", "Nữ", "Quản trị kinh doanh", new DateTime(1985, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 27, 15, 15, 50, 503, DateTimeKind.Local).AddTicks(3210), new DateTime(2012, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "0123456789", "Phạm Thị C", "Đang hoạt động" },
                    { "GV004", "path/to/image.jpg", "123456789", "Phó trưởng khoa", "Kinh", "101 Đường ABC, Quận ABC, TP HCM", "levand@example.com", "Nam", "Kỹ thuật xây dựng", new DateTime(1978, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 27, 15, 15, 50, 503, DateTimeKind.Local).AddTicks(3213), new DateTime(2011, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "0987654321", "Lê Văn D", "Đang hoạt động" },
                    { "GV005", "path/to/image.jpg", "987654321", "Giảng viên", "Kinh", "456 Đường XYZ, Quận XYZ, TP HCM", "hoangthie@example.com", "Nữ", "Ngôn ngữ Anh", new DateTime(1982, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 27, 15, 15, 50, 503, DateTimeKind.Local).AddTicks(3216), new DateTime(2015, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "0123456789", "Hoàng Thị E", "Đang hoạt động" },
                    { "GV006", "path/to/image.jpg", "123456789", "Trưởng khoa", "Kinh", "789 Đường ABC, Quận ABC, TP HCM", "dangvanf@example.com", "Nam", "Kinh tế", new DateTime(1970, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 27, 15, 15, 50, 503, DateTimeKind.Local).AddTicks(3219), new DateTime(2005, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "0987654321", "Đặng Văn F", "Đang hoạt động" },
                    { "GV007", "path/to/image.jpg", "987654321", "Giảng viên", "Kinh", "101 Đường XYZ, Quận ABC, Quận XYZ, TP HCM", "vuthig@example.com", "Nữ", "Mỹ thuật", new DateTime(1973, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 27, 15, 15, 50, 503, DateTimeKind.Local).AddTicks(3222), new DateTime(2013, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "0123456789", "Vũ Thị G", "Đang hoạt động" },
                    { "GV008", "path/to/image.jpg", "123456789", "Phó trưởng khoa", "Kinh", "123 Đường ABC, Quận ABC, TP HCM", "nguyenthanhh@example.com", "Nam", "Tài chính", new DateTime(1976, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 27, 15, 15, 50, 503, DateTimeKind.Local).AddTicks(3225), new DateTime(2012, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "0987654321", "Nguyễn Thanh H", "Đang hoạt động" },
                    { "GV009", "path/to/image.jpg", "987654321", "Giảng viên", "Kinh", "456 Đường XYZ, Quận XYZ, TP HCM", "tranvani@example.com", "Nam", "Luật", new DateTime(1983, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 27, 15, 15, 50, 503, DateTimeKind.Local).AddTicks(3228), new DateTime(2010, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "0123456789", "Trần Văn I", "Đang hoạt động" },
                    { "GV010", "path/to/image.jpg", "123456789", "Trưởng khoa", "Kinh", "101 Đường ABC, Quận ABC, TP HCM", "lethik@example.com", "Nữ", "Khoa học máy tính", new DateTime(1979, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 27, 15, 15, 50, 503, DateTimeKind.Local).AddTicks(3269), new DateTime(2013, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "0987654321", "Lê Thị K", "Đang hoạt động" }
                });

            migrationBuilder.InsertData(
                table: "HocKyBlock",
                columns: new[] { "MaHocKyBlock", "NgayBatDau", "NgayKetThuc", "TenBlock", "TenHocKy", "TinhTrang" },
                values: new object[,]
                {
                    { "FA24BL1", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block 1", "Fall 2024", "Đang hoạt động" },
                    { "FA24BL2", new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block 2", "Fall 2024", "Đang hoạt động" },
                    { "SM24BL1", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block 1", "Summer 2024", "Đang hoạt động" },
                    { "SM24BL2", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block 2", "Summer 2024", "Đang hoạt động" },
                    { "SP24BL1", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block 1", "Spring 2024", "Đang hoạt động" },
                    { "SP24BL2", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block 2", "Spring 2024", "Đang hoạt động" },
                    { "SP25BL1", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block 1", "Spring 2025", "Đang hoạt động" },
                    { "SP25BL2", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block 2", "Spring 2025", "Đang hoạt động" }
                });

            migrationBuilder.InsertData(
                table: "LopHoc",
                columns: new[] { "MaLop", "NgayTao", "SucChua", "TenLop", "TinhTrang" },
                values: new object[,]
                {
                    { "LH001", new DateTime(2024, 2, 17, 15, 15, 50, 503, DateTimeKind.Local).AddTicks(2795), (short)30, "Toán cao cấp", "Đang Đang hoạt động" },
                    { "LH002", new DateTime(2024, 2, 27, 15, 15, 50, 503, DateTimeKind.Local).AddTicks(2811), (short)25, "Vật lý đại cương", "Đang Đang hoạt động" },
                    { "LH003", new DateTime(2024, 3, 8, 15, 15, 50, 503, DateTimeKind.Local).AddTicks(2813), (short)20, "Hóa học cơ bản", "Đang Đang hoạt động" },
                    { "LH004", new DateTime(2024, 3, 18, 15, 15, 50, 503, DateTimeKind.Local).AddTicks(2815), (short)35, "Lập trình C#", "Đang Đang hoạt động" },
                    { "LH005", new DateTime(2024, 3, 28, 15, 15, 50, 503, DateTimeKind.Local).AddTicks(2817), (short)30, "Lập trình Java", "Đang Đang hoạt động" },
                    { "LH006", new DateTime(2024, 4, 7, 15, 15, 50, 503, DateTimeKind.Local).AddTicks(2818), (short)25, "Lập trình Python", "Đang Đang hoạt động" },
                    { "LH007", new DateTime(2024, 4, 17, 15, 15, 50, 503, DateTimeKind.Local).AddTicks(2820), (short)20, "Lập trình JavaScript", "Đang Đang hoạt động" },
                    { "LH008", new DateTime(2024, 4, 27, 15, 15, 50, 503, DateTimeKind.Local).AddTicks(2822), (short)35, "Lập trình PHP", "Đang Đang hoạt động" },
                    { "LH009", new DateTime(2024, 5, 7, 15, 15, 50, 503, DateTimeKind.Local).AddTicks(2823), (short)30, "Lập trình Ruby", "Đang Đang hoạt động" },
                    { "LH010", new DateTime(2024, 5, 17, 15, 15, 50, 503, DateTimeKind.Local).AddTicks(2825), (short)25, "Lập trình Swift", "Đang Đang hoạt động" }
                });

            migrationBuilder.InsertData(
                table: "MonHoc",
                columns: new[] { "MaMonHoc", "NgayTao", "NoiDungMonHoc", "SoBuoi", "TaiLieu", "TenMonHoc", "TinChi", "TinhTrang" },
                values: new object[,]
                {
                    { "MH001", new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Toán cao cấp dành cho sinh viên ngành kỹ thuật.", (short)45, "Giáo trình Toán Cao Cấp - Tập 1", "Toán Cao Cấp", (short)3, "Đang hoạt động" },
                    { "MH002", new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiến thức cơ bản về vật lý cho sinh viên.", (short)60, "Giáo trình Vật Lý Đại Cương", "Vật Lý Đại Cương", (short)4, "Đang hoạt động" },
                    { "MH003", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiến thức hóa học cơ bản cho sinh viên không chuyên.", (short)45, "Giáo trình Hóa Học Cơ Bản", "Hóa Học Cơ Bản", (short)3, "Đang hoạt động" },
                    { "MH004", new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giới thiệu về lập trình C.", (short)45, "Giáo trình Lập Trình C", "Lập Trình C", (short)3, "Đang hoạt động" },
                    { "MH005", new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiến thức cơ bản về cơ sở dữ liệu.", (short)60, "Giáo trình Cơ Sở Dữ Liệu", "Cơ Sở Dữ Liệu", (short)4, "Đang hoạt động" },
                    { "MH006", new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giới thiệu về hệ điều hành và các khái niệm cơ bản.", (short)45, "Giáo trình Hệ Điều Hành", "Hệ Điều Hành", (short)3, "Đang hoạt động" },
                    { "MH007", new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiến thức cơ bản về mạng máy tính.", (short)45, "Giáo trình Mạng Máy Tính", "Mạng Máy Tính", (short)3, "Đang hoạt động" },
                    { "MH008", new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giới thiệu về trí tuệ nhân tạo và các ứng dụng.", (short)60, "Giáo trình Trí Tuệ Nhân Tạo", "Trí Tuệ Nhân Tạo", (short)4, "Đang hoạt động" },
                    { "MH009", new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giới thiệu về phân tích và thiết kế hệ thống.", (short)45, "Giáo trình Phân Tích Thiết Kế Hệ Thống", "Phân Tích Thiết Kế Hệ Thống", (short)3, "Đang hoạt động" },
                    { "MH010", new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiến thức cơ bản về kinh tế học.", (short)45, "Giáo trình Kinh Tế Học", "Kinh Tế Học", (short)3, "Đang hoạt động" }
                });

            migrationBuilder.InsertData(
                table: "PhongHoc",
                columns: new[] { "MaPhong", "LoaiPhong", "NgayTao", "SucChua", "TenPhong", "TinhTrang" },
                values: new object[,]
                {
                    { "P001", "Giảng Đường", new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)100, "Phòng A1", "Đang hoạt động" },
                    { "P002", "Phòng Thí Nghiệm", new DateTime(2022, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)30, "Phòng B1", "Đang hoạt động" },
                    { "P003", "Phòng Học Nhóm", new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)20, "Phòng C1", "Đang hoạt động" },
                    { "P004", "Phòng Máy Tính", new DateTime(2022, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)40, "Phòng D1", "Đang hoạt động" },
                    { "P005", "Phòng Thực Hành", new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)50, "Phòng E1", "Đang hoạt động" },
                    { "P006", "Phòng Hội Thảo", new DateTime(2022, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)70, "Phòng F1", "Đang hoạt động" },
                    { "P007", "Giảng Đường", new DateTime(2022, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)100, "Phòng G1", "Đang hoạt động" },
                    { "P008", "Phòng Thí Nghiệm", new DateTime(2022, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)30, "Phòng H1", "Đang hoạt động" },
                    { "P009", "Phòng Học Nhóm", new DateTime(2022, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)20, "Phòng I1", "Đang hoạt động" },
                    { "P010", "Phòng Máy Tính", new DateTime(2022, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)40, "Phòng J1", "Đang hoạt động" }
                });

            migrationBuilder.InsertData(
                table: "SinhVien",
                columns: new[] { "MaSinhVien", "AnhSinhVien", "CCCD", "ChuyenNganh", "DanToc", "DiaChi", "Email", "GioiTinh", "Khoa", "NgayNhapHoc", "NgaySinh", "NgayThem", "SoDienThoai", "TenSinhVien", "TinhTrang" },
                values: new object[,]
                {
                    { "SV001", "pexels-justin-shaifer-501272-1222271.jpg", "123456789012", "Khoa Học Máy Tính", "Kinh", "123 Đường A, Quận 1, TP.HCM", "nguyenvana@example.com", "Nam", "CNTT", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 27, 15, 15, 50, 503, DateTimeKind.Local).AddTicks(2997), "0901234567", "Nguyễn Văn A", "Đang học" },
                    { "SV002", "360_F_243123463_zTooub557xEWABDLk0jJklDyLSGl2jrr.jpg", "234567890123", "Quản Trị Kinh Doanh", "Kinh", "456 Đường B, Quận 2, TP.HCM", "tranthib@example.com", "Nữ", "Kinh Tế", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 27, 15, 15, 50, 503, DateTimeKind.Local).AddTicks(3003), "0902345678", "Trần Thị B", "Đang học" },
                    { "SV003", "pexels-simon-robben-55958-614810.jpg", "345678901234", "Mạng Máy Tính", "Kinh", "789 Đường C, Quận 3, TP.HCM", "levanc@example.com", "Nam", "CNTT", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 27, 15, 15, 50, 503, DateTimeKind.Local).AddTicks(3007), "0903456789", "Lê Văn C", "Đang học" },
                    { "SV004", "images.jpg", "456789012345", "Kế Toán", "Kinh", "101 Đường D, Quận 4, TP.HCM", "phamthid@example.com", "Nữ", "Kinh Tế", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 27, 15, 15, 50, 503, DateTimeKind.Local).AddTicks(3010), "0904567890", "Phạm Thị D", "Đang học" },
                    { "SV005", "pexels-simon-robben-55958-614810.jpg", "567890123456", "Khoa Học Máy Tính", "Kinh", "112 Đường E, Quận 5, TP.HCM", "hoangvane@example.com", "Nam", "CNTT", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 27, 15, 15, 50, 503, DateTimeKind.Local).AddTicks(3013), "0905678901", "Hoàng Văn E", "Đang học" },
                    { "SV006", "images.jpg", "678901234567", "Quản Trị Kinh Doanh", "Kinh", "123 Đường F, Quận 6, TP.HCM", "dothif@example.com", "Nữ", "Kinh Tế", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 27, 15, 15, 50, 503, DateTimeKind.Local).AddTicks(3016), "0906789012", "Đỗ Thị F", "Đang học" },
                    { "SV007", "pexels-justin-shaifer-501272-1222271.jpg", "789012345678", "Mạng Máy Tính", "Kinh", "234 Đường G, Quận 7, TP.HCM", "ngovang@example.com", "Nam", "CNTT", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 27, 15, 15, 50, 503, DateTimeKind.Local).AddTicks(3021), "0907890123", "Ngô Văn G", "Đang học" },
                    { "SV008", "360_F_243123463_zTooub557xEWABDLk0jJklDyLSGl2jrr.jpg", "890123456789", "Kế Toán", "Kinh", "345 Đường H, Quận 8, TP.HCM", "phanthih@example.com", "Nữ", "Kinh Tế", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 27, 15, 15, 50, 503, DateTimeKind.Local).AddTicks(3024), "0908901234", "Phan Thị H", "Đang học" },
                    { "SV009", "pexels-simon-robben-55958-614810.jpg", "901234567890", "Khoa Học Máy Tính", "Kinh", "456 Đường I, Quận 9, TP.HCM", "buivani@example.com", "Nam", "CNTT", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 27, 15, 15, 50, 503, DateTimeKind.Local).AddTicks(3028), "0909012345", "Bùi Văn I", "Đang học" },
                    { "SV010", "images.jpg", "012345678901", "Quản Trị Kinh Doanh", "Kinh", "567 Đường K, Quận 10, TP.HCM", "vothik@example.com", "Nữ", "Kinh Tế", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 27, 15, 15, 50, 503, DateTimeKind.Local).AddTicks(3031), "0900123456", "Võ Thị K", "Đang học" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LichHoc_MaGiangVien",
                table: "LichHoc",
                column: "MaGiangVien");

            migrationBuilder.CreateIndex(
                name: "IX_LichHoc_MaHocKyBlock",
                table: "LichHoc",
                column: "MaHocKyBlock");

            migrationBuilder.CreateIndex(
                name: "IX_LichHoc_MaLop",
                table: "LichHoc",
                column: "MaLop");

            migrationBuilder.CreateIndex(
                name: "IX_LichHoc_MaMonHoc",
                table: "LichHoc",
                column: "MaMonHoc");

            migrationBuilder.CreateIndex(
                name: "IX_LichHoc_MaPhong",
                table: "LichHoc",
                column: "MaPhong");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocChiTiet_MaLop",
                table: "LopHocChiTiet",
                column: "MaLop");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocChiTiet_MaSinhVien",
                table: "LopHocChiTiet",
                column: "MaSinhVien");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LichHoc");

            migrationBuilder.DropTable(
                name: "LopHocChiTiet");

            migrationBuilder.DropTable(
                name: "GiangVien");

            migrationBuilder.DropTable(
                name: "HocKyBlock");

            migrationBuilder.DropTable(
                name: "MonHoc");

            migrationBuilder.DropTable(
                name: "PhongHoc");

            migrationBuilder.DropTable(
                name: "LopHoc");

            migrationBuilder.DropTable(
                name: "SinhVien");
        }
    }
}
