using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApFpoly_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataContext : Migration
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
                    TinhTrang = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false)
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
                    { "GV001", "path/to/image.jpg", "123456789", "Giảng viên", "Kinh", "123 Đường ABC, Quận XYZ, TP HCM", "nguyenvana@example.com", "Nam", "Công nghệ thông tin", new DateTime(1980, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(7084), new DateTime(2010, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "0123456789", "Nguyễn Văn A", "Hoạt động" },
                    { "GV002", "path/to/image.jpg", "987654321", "Phó trưởng khoa", "Kinh", "456 Đường XYZ, Quận ABC, TP HCM", "tranthib@example.com", "Nữ", "Kỹ thuật điện tử", new DateTime(1975, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(7088), new DateTime(2008, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "0987654321", "Trần Thị B", "Hoạt động" },
                    { "GV003", "path/to/image.jpg", "987654321", "Trưởng khoa", "Kinh", "789 Đường XYZ, Quận XYZ, TP HCM", "phamthic@example.com", "Nữ", "Quản trị kinh doanh", new DateTime(1985, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(7090), new DateTime(2012, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "0123456789", "Phạm Thị C", "Hoạt động" },
                    { "GV004", "path/to/image.jpg", "123456789", "Phó trưởng khoa", "Kinh", "101 Đường ABC, Quận ABC, TP HCM", "levand@example.com", "Nam", "Kỹ thuật xây dựng", new DateTime(1978, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(7092), new DateTime(2011, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "0987654321", "Lê Văn D", "Hoạt động" },
                    { "GV005", "path/to/image.jpg", "987654321", "Giảng viên", "Kinh", "456 Đường XYZ, Quận XYZ, TP HCM", "hoangthie@example.com", "Nữ", "Ngôn ngữ Anh", new DateTime(1982, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(7095), new DateTime(2015, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "0123456789", "Hoàng Thị E", "Hoạt động" },
                    { "GV006", "path/to/image.jpg", "123456789", "Trưởng khoa", "Kinh", "789 Đường ABC, Quận ABC, TP HCM", "dangvanf@example.com", "Nam", "Kinh tế", new DateTime(1970, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(7097), new DateTime(2005, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "0987654321", "Đặng Văn F", "Hoạt động" },
                    { "GV007", "path/to/image.jpg", "987654321", "Giảng viên", "Kinh", "101 Đường XYZ, Quận ABC, Quận XYZ, TP HCM", "vuthig@example.com", "Nữ", "Mỹ thuật", new DateTime(1973, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(7099), new DateTime(2013, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "0123456789", "Vũ Thị G", "Hoạt động" },
                    { "GV008", "path/to/image.jpg", "123456789", "Phó trưởng khoa", "Kinh", "123 Đường ABC, Quận ABC, TP HCM", "nguyenthanhh@example.com", "Nam", "Tài chính", new DateTime(1976, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(7102), new DateTime(2012, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "0987654321", "Nguyễn Thanh H", "Hoạt động" },
                    { "GV009", "path/to/image.jpg", "987654321", "Giảng viên", "Kinh", "456 Đường XYZ, Quận XYZ, TP HCM", "tranvani@example.com", "Nam", "Luật", new DateTime(1983, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(7104), new DateTime(2010, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "0123456789", "Trần Văn I", "Hoạt động" },
                    { "GV010", "path/to/image.jpg", "123456789", "Trưởng khoa", "Kinh", "101 Đường ABC, Quận ABC, TP HCM", "lethik@example.com", "Nữ", "Khoa học máy tính", new DateTime(1979, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(7106), new DateTime(2013, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "0987654321", "Lê Thị K", "Hoạt động" }
                });

            migrationBuilder.InsertData(
                table: "HocKyBlock",
                columns: new[] { "MaHocKyBlock", "NgayBatDau", "NgayKetThuc", "TenBlock", "TenHocKy", "TinhTrang" },
                values: new object[,]
                {
                    { "FA24BL1", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block 1", "Fall 2024", "Hoạt động" },
                    { "FA24BL2", new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block 2", "Fall 2024", "Hoạt động" },
                    { "SM24BL1", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block 1", "Summer 2024", "Hoạt động" },
                    { "SM24BL2", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block 2", "Summer 2024", "Hoạt động" },
                    { "SP24BL1", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block 1", "Spring 2024", "Hoạt động" },
                    { "SP24BL2", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block 2", "Spring 2024", "Hoạt động" },
                    { "SP25BL1", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block 1", "Spring 2025", "Hoạt động" },
                    { "SP25BL2", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Block 2", "Spring 2025", "Hoạt động" }
                });

            migrationBuilder.InsertData(
                table: "LopHoc",
                columns: new[] { "MaLop", "NgayTao", "SucChua", "TenLop", "TinhTrang" },
                values: new object[,]
                {
                    { "LH001", new DateTime(2024, 2, 7, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6768), (short)30, "Toán cao cấp", "Đang hoạt động" },
                    { "LH002", new DateTime(2024, 2, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6784), (short)25, "Vật lý đại cương", "Đang hoạt động" },
                    { "LH003", new DateTime(2024, 2, 27, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6786), (short)20, "Hóa học cơ bản", "Đang hoạt động" },
                    { "LH004", new DateTime(2024, 3, 8, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6787), (short)35, "Lập trình C#", "Đang hoạt động" },
                    { "LH005", new DateTime(2024, 3, 18, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6788), (short)30, "Lập trình Java", "Đang hoạt động" },
                    { "LH006", new DateTime(2024, 3, 28, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6790), (short)25, "Lập trình Python", "Đang hoạt động" },
                    { "LH007", new DateTime(2024, 4, 7, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6791), (short)20, "Lập trình JavaScript", "Đang hoạt động" },
                    { "LH008", new DateTime(2024, 4, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6792), (short)35, "Lập trình PHP", "Đang hoạt động" },
                    { "LH009", new DateTime(2024, 4, 27, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6793), (short)30, "Lập trình Ruby", "Đang hoạt động" },
                    { "LH010", new DateTime(2024, 5, 7, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6795), (short)25, "Lập trình Swift", "Đang hoạt động" }
                });

            migrationBuilder.InsertData(
                table: "MonHoc",
                columns: new[] { "MaMonHoc", "NgayTao", "NoiDungMonHoc", "SoBuoi", "TaiLieu", "TenMonHoc", "TinChi", "TinhTrang" },
                values: new object[,]
                {
                    { "MH001", new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Toán cao cấp dành cho sinh viên ngành kỹ thuật.", (short)45, "Giáo trình Toán Cao Cấp - Tập 1", "Toán Cao Cấp", (short)3, "Hoạt động" },
                    { "MH002", new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiến thức cơ bản về vật lý cho sinh viên.", (short)60, "Giáo trình Vật Lý Đại Cương", "Vật Lý Đại Cương", (short)4, "Hoạt động" },
                    { "MH003", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiến thức hóa học cơ bản cho sinh viên không chuyên.", (short)45, "Giáo trình Hóa Học Cơ Bản", "Hóa Học Cơ Bản", (short)3, "Hoạt động" },
                    { "MH004", new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giới thiệu về lập trình C.", (short)45, "Giáo trình Lập Trình C", "Lập Trình C", (short)3, "Hoạt động" },
                    { "MH005", new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiến thức cơ bản về cơ sở dữ liệu.", (short)60, "Giáo trình Cơ Sở Dữ Liệu", "Cơ Sở Dữ Liệu", (short)4, "Hoạt động" },
                    { "MH006", new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giới thiệu về hệ điều hành và các khái niệm cơ bản.", (short)45, "Giáo trình Hệ Điều Hành", "Hệ Điều Hành", (short)3, "Hoạt động" },
                    { "MH007", new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiến thức cơ bản về mạng máy tính.", (short)45, "Giáo trình Mạng Máy Tính", "Mạng Máy Tính", (short)3, "Hoạt động" },
                    { "MH008", new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giới thiệu về trí tuệ nhân tạo và các ứng dụng.", (short)60, "Giáo trình Trí Tuệ Nhân Tạo", "Trí Tuệ Nhân Tạo", (short)4, "Hoạt động" },
                    { "MH009", new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giới thiệu về phân tích và thiết kế hệ thống.", (short)45, "Giáo trình Phân Tích Thiết Kế Hệ Thống", "Phân Tích Thiết Kế Hệ Thống", (short)3, "Hoạt động" },
                    { "MH010", new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiến thức cơ bản về kinh tế học.", (short)45, "Giáo trình Kinh Tế Học", "Kinh Tế Học", (short)3, "Hoạt động" }
                });

            migrationBuilder.InsertData(
                table: "PhongHoc",
                columns: new[] { "MaPhong", "LoaiPhong", "NgayTao", "SucChua", "TenPhong", "TinhTrang" },
                values: new object[,]
                {
                    { "P001", "Giảng Đường", new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)100, "Phòng A1", "Hoạt động" },
                    { "P002", "Phòng Thí Nghiệm", new DateTime(2022, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)30, "Phòng B1", "Hoạt động" },
                    { "P003", "Phòng Học Nhóm", new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)20, "Phòng C1", "Hoạt động" },
                    { "P004", "Phòng Máy Tính", new DateTime(2022, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)40, "Phòng D1", "Hoạt động" },
                    { "P005", "Phòng Thực Hành", new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)50, "Phòng E1", "Hoạt động" },
                    { "P006", "Phòng Hội Thảo", new DateTime(2022, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)70, "Phòng F1", "Hoạt động" },
                    { "P007", "Giảng Đường", new DateTime(2022, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)100, "Phòng G1", "Hoạt động" },
                    { "P008", "Phòng Thí Nghiệm", new DateTime(2022, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)30, "Phòng H1", "Hoạt động" },
                    { "P009", "Phòng Học Nhóm", new DateTime(2022, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)20, "Phòng I1", "Hoạt động" },
                    { "P010", "Phòng Máy Tính", new DateTime(2022, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)40, "Phòng J1", "Hoạt động" }
                });

            migrationBuilder.InsertData(
                table: "SinhVien",
                columns: new[] { "MaSinhVien", "AnhSinhVien", "CCCD", "ChuyenNganh", "DanToc", "DiaChi", "Email", "GioiTinh", "Khoa", "NgayNhapHoc", "NgaySinh", "NgayThem", "SoDienThoai", "TenSinhVien", "TinhTrang" },
                values: new object[,]
                {
                    { "SV001", "nguyenvana.jpg", "123456789012", "Khoa Học Máy Tính", "Kinh", "123 Đường A, Quận 1, TP.HCM", "nguyenvana@example.com", "Nam", "CNTT", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6915), "0901234567", "Nguyễn Văn A", "Đang học" },
                    { "SV002", "tranthib.jpg", "234567890123", "Quản Trị Kinh Doanh", "Kinh", "456 Đường B, Quận 2, TP.HCM", "tranthib@example.com", "Nữ", "Kinh Tế", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6919), "0902345678", "Trần Thị B", "Đang học" },
                    { "SV003", "levanc.jpg", "345678901234", "Mạng Máy Tính", "Kinh", "789 Đường C, Quận 3, TP.HCM", "levanc@example.com", "Nam", "CNTT", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6921), "0903456789", "Lê Văn C", "Đang học" },
                    { "SV004", "phamthid.jpg", "456789012345", "Kế Toán", "Kinh", "101 Đường D, Quận 4, TP.HCM", "phamthid@example.com", "Nữ", "Kinh Tế", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6924), "0904567890", "Phạm Thị D", "Đang học" },
                    { "SV005", "hoangvane.jpg", "567890123456", "Khoa Học Máy Tính", "Kinh", "112 Đường E, Quận 5, TP.HCM", "hoangvane@example.com", "Nam", "CNTT", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6926), "0905678901", "Hoàng Văn E", "Đang học" },
                    { "SV006", "dothif.jpg", "678901234567", "Quản Trị Kinh Doanh", "Kinh", "123 Đường F, Quận 6, TP.HCM", "dothif@example.com", "Nữ", "Kinh Tế", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6928), "0906789012", "Đỗ Thị F", "Đang học" },
                    { "SV007", "ngovang.jpg", "789012345678", "Mạng Máy Tính", "Kinh", "234 Đường G, Quận 7, TP.HCM", "ngovang@example.com", "Nam", "CNTT", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6931), "0907890123", "Ngô Văn G", "Đang học" },
                    { "SV008", "phanthih.jpg", "890123456789", "Kế Toán", "Kinh", "345 Đường H, Quận 8, TP.HCM", "phanthih@example.com", "Nữ", "Kinh Tế", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6933), "0908901234", "Phan Thị H", "Đang học" },
                    { "SV009", "buivani.jpg", "901234567890", "Khoa Học Máy Tính", "Kinh", "456 Đường I, Quận 9, TP.HCM", "buivani@example.com", "Nam", "CNTT", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6935), "0909012345", "Bùi Văn I", "Đang học" },
                    { "SV010", "vothik.jpg", "012345678901", "Quản Trị Kinh Doanh", "Kinh", "567 Đường K, Quận 10, TP.HCM", "vothik@example.com", "Nữ", "Kinh Tế", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 16, 47, 24, 875, DateTimeKind.Local).AddTicks(6937), "0900123456", "Võ Thị K", "Đang học" }
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
