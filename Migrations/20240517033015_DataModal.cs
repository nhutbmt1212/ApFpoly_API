using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApFpoly_API.Migrations
{
    /// <inheritdoc />
    public partial class DataModal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GiangVien",
                columns: new[] { "MaGiangVien", "AnhGiangVien", "CCCD", "ChucVu", "DanToc", "DiaChi", "Email", "GioiTinh", "Nganh", "NgaySinh", "NgayThem", "NgayVaoLam", "SoDienThoai", "TenGiangVien", "TinhTrang" },
                values: new object[,]
                {
                    { "GV001", "path/to/image.jpg", "123456789", "Giảng viên", "Kinh", "123 Đường ABC, Quận XYZ, TP HCM", "nguyenvana@example.com", "Nam", "Công nghệ thông tin", new DateTime(1980, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 10, 30, 14, 980, DateTimeKind.Local).AddTicks(5822), new DateTime(2010, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "0123456789", "Nguyễn Văn A", "Hoạt động" },
                    { "GV002", "path/to/image.jpg", "987654321", "Phó trưởng khoa", "Kinh", "456 Đường XYZ, Quận ABC, TP HCM", "tranthib@example.com", "Nữ", "Kỹ thuật điện tử", new DateTime(1975, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 10, 30, 14, 980, DateTimeKind.Local).AddTicks(5827), new DateTime(2008, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "0987654321", "Trần Thị B", "Hoạt động" },
                    { "GV003", "path/to/image.jpg", "987654321", "Trưởng khoa", "Kinh", "789 Đường XYZ, Quận XYZ, TP HCM", "phamthic@example.com", "Nữ", "Quản trị kinh doanh", new DateTime(1985, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 10, 30, 14, 980, DateTimeKind.Local).AddTicks(5829), new DateTime(2012, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "0123456789", "Phạm Thị C", "Hoạt động" },
                    { "GV004", "path/to/image.jpg", "123456789", "Phó trưởng khoa", "Kinh", "101 Đường ABC, Quận ABC, TP HCM", "levand@example.com", "Nam", "Kỹ thuật xây dựng", new DateTime(1978, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 10, 30, 14, 980, DateTimeKind.Local).AddTicks(5832), new DateTime(2011, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "0987654321", "Lê Văn D", "Hoạt động" },
                    { "GV005", "path/to/image.jpg", "987654321", "Giảng viên", "Kinh", "456 Đường XYZ, Quận XYZ, TP HCM", "hoangthie@example.com", "Nữ", "Ngôn ngữ Anh", new DateTime(1982, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 10, 30, 14, 980, DateTimeKind.Local).AddTicks(5834), new DateTime(2015, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "0123456789", "Hoàng Thị E", "Hoạt động" },
                    { "GV006", "path/to/image.jpg", "123456789", "Trưởng khoa", "Kinh", "789 Đường ABC, Quận ABC, TP HCM", "dangvanf@example.com", "Nam", "Kinh tế", new DateTime(1970, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 10, 30, 14, 980, DateTimeKind.Local).AddTicks(5874), new DateTime(2005, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "0987654321", "Đặng Văn F", "Hoạt động" },
                    { "GV007", "path/to/image.jpg", "987654321", "Giảng viên", "Kinh", "101 Đường XYZ, Quận ABC, Quận XYZ, TP HCM", "vuthig@example.com", "Nữ", "Mỹ thuật", new DateTime(1973, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 10, 30, 14, 980, DateTimeKind.Local).AddTicks(5876), new DateTime(2013, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "0123456789", "Vũ Thị G", "Hoạt động" },
                    { "GV008", "path/to/image.jpg", "123456789", "Phó trưởng khoa", "Kinh", "123 Đường ABC, Quận ABC, TP HCM", "nguyenthanhh@example.com", "Nam", "Tài chính", new DateTime(1976, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 10, 30, 14, 980, DateTimeKind.Local).AddTicks(5879), new DateTime(2012, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "0987654321", "Nguyễn Thanh H", "Hoạt động" },
                    { "GV009", "path/to/image.jpg", "987654321", "Giảng viên", "Kinh", "456 Đường XYZ, Quận XYZ, TP HCM", "tranvani@example.com", "Nam", "Luật", new DateTime(1983, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 10, 30, 14, 980, DateTimeKind.Local).AddTicks(5884), new DateTime(2010, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "0123456789", "Trần Văn I", "Hoạt động" },
                    { "GV010", "path/to/image.jpg", "123456789", "Trưởng khoa", "Kinh", "101 Đường ABC, Quận ABC, TP HCM", "lethik@example.com", "Nữ", "Khoa học máy tính", new DateTime(1979, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 10, 30, 14, 980, DateTimeKind.Local).AddTicks(5887), new DateTime(2013, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "0987654321", "Lê Thị K", "Hoạt động" }
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
                    { "LH001", new DateTime(2024, 2, 7, 10, 30, 14, 980, DateTimeKind.Local).AddTicks(5507), (short)30, "Toán cao cấp", "Đang hoạt động" },
                    { "LH002", new DateTime(2024, 2, 17, 10, 30, 14, 980, DateTimeKind.Local).AddTicks(5525), (short)25, "Vật lý đại cương", "Đang hoạt động" },
                    { "LH003", new DateTime(2024, 2, 27, 10, 30, 14, 980, DateTimeKind.Local).AddTicks(5526), (short)20, "Hóa học cơ bản", "Đang hoạt động" },
                    { "LH004", new DateTime(2024, 3, 8, 10, 30, 14, 980, DateTimeKind.Local).AddTicks(5527), (short)35, "Lập trình C#", "Đang hoạt động" },
                    { "LH005", new DateTime(2024, 3, 18, 10, 30, 14, 980, DateTimeKind.Local).AddTicks(5528), (short)30, "Lập trình Java", "Đang hoạt động" },
                    { "LH006", new DateTime(2024, 3, 28, 10, 30, 14, 980, DateTimeKind.Local).AddTicks(5530), (short)25, "Lập trình Python", "Đang hoạt động" },
                    { "LH007", new DateTime(2024, 4, 7, 10, 30, 14, 980, DateTimeKind.Local).AddTicks(5531), (short)20, "Lập trình JavaScript", "Đang hoạt động" },
                    { "LH008", new DateTime(2024, 4, 17, 10, 30, 14, 980, DateTimeKind.Local).AddTicks(5532), (short)35, "Lập trình PHP", "Đang hoạt động" },
                    { "LH009", new DateTime(2024, 4, 27, 10, 30, 14, 980, DateTimeKind.Local).AddTicks(5533), (short)30, "Lập trình Ruby", "Đang hoạt động" },
                    { "LH010", new DateTime(2024, 5, 7, 10, 30, 14, 980, DateTimeKind.Local).AddTicks(5534), (short)25, "Lập trình Swift", "Đang hoạt động" }
                });

            migrationBuilder.InsertData(
                table: "MonHoc",
                columns: new[] { "MaMonHoc", "NgayTao", "NoiDungMonHoc", "TaiLieu", "TenMonHoc", "ThoiGianHoc", "TinChi", "TinhTrang" },
                values: new object[,]
                {
                    { "MH001", new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Toán cao cấp dành cho sinh viên ngành kỹ thuật.", "Giáo trình Toán Cao Cấp - Tập 1", "Toán Cao Cấp", (short)45, (short)3, "Hoạt động" },
                    { "MH002", new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiến thức cơ bản về vật lý cho sinh viên.", "Giáo trình Vật Lý Đại Cương", "Vật Lý Đại Cương", (short)60, (short)4, "Hoạt động" },
                    { "MH003", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiến thức hóa học cơ bản cho sinh viên không chuyên.", "Giáo trình Hóa Học Cơ Bản", "Hóa Học Cơ Bản", (short)45, (short)3, "Hoạt động" },
                    { "MH004", new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giới thiệu về lập trình C.", "Giáo trình Lập Trình C", "Lập Trình C", (short)45, (short)3, "Hoạt động" },
                    { "MH005", new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiến thức cơ bản về cơ sở dữ liệu.", "Giáo trình Cơ Sở Dữ Liệu", "Cơ Sở Dữ Liệu", (short)60, (short)4, "Hoạt động" },
                    { "MH006", new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giới thiệu về hệ điều hành và các khái niệm cơ bản.", "Giáo trình Hệ Điều Hành", "Hệ Điều Hành", (short)45, (short)3, "Hoạt động" },
                    { "MH007", new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiến thức cơ bản về mạng máy tính.", "Giáo trình Mạng Máy Tính", "Mạng Máy Tính", (short)45, (short)3, "Hoạt động" },
                    { "MH008", new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giới thiệu về trí tuệ nhân tạo và các ứng dụng.", "Giáo trình Trí Tuệ Nhân Tạo", "Trí Tuệ Nhân Tạo", (short)60, (short)4, "Hoạt động" },
                    { "MH009", new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giới thiệu về phân tích và thiết kế hệ thống.", "Giáo trình Phân Tích Thiết Kế Hệ Thống", "Phân Tích Thiết Kế Hệ Thống", (short)45, (short)3, "Hoạt động" },
                    { "MH010", new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiến thức cơ bản về kinh tế học.", "Giáo trình Kinh Tế Học", "Kinh Tế Học", (short)45, (short)3, "Hoạt động" }
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
                    { "SV001", "nguyenvana.jpg", "123456789012", "Khoa Học Máy Tính", "Kinh", "123 Đường A, Quận 1, TP.HCM", "nguyenvana@example.com", "Nam", "CNTT", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 10, 30, 14, 980, DateTimeKind.Local).AddTicks(5681), "0901234567", "Nguyễn Văn A", "Đang học" },
                    { "SV002", "tranthib.jpg", "234567890123", "Quản Trị Kinh Doanh", "Kinh", "456 Đường B, Quận 2, TP.HCM", "tranthib@example.com", "Nữ", "Kinh Tế", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 10, 30, 14, 980, DateTimeKind.Local).AddTicks(5686), "0902345678", "Trần Thị B", "Đang học" },
                    { "SV003", "levanc.jpg", "345678901234", "Mạng Máy Tính", "Kinh", "789 Đường C, Quận 3, TP.HCM", "levanc@example.com", "Nam", "CNTT", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 10, 30, 14, 980, DateTimeKind.Local).AddTicks(5688), "0903456789", "Lê Văn C", "Đang học" },
                    { "SV004", "phamthid.jpg", "456789012345", "Kế Toán", "Kinh", "101 Đường D, Quận 4, TP.HCM", "phamthid@example.com", "Nữ", "Kinh Tế", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 10, 30, 14, 980, DateTimeKind.Local).AddTicks(5691), "0904567890", "Phạm Thị D", "Đang học" },
                    { "SV005", "hoangvane.jpg", "567890123456", "Khoa Học Máy Tính", "Kinh", "112 Đường E, Quận 5, TP.HCM", "hoangvane@example.com", "Nam", "CNTT", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 10, 30, 14, 980, DateTimeKind.Local).AddTicks(5693), "0905678901", "Hoàng Văn E", "Đang học" },
                    { "SV006", "dothif.jpg", "678901234567", "Quản Trị Kinh Doanh", "Kinh", "123 Đường F, Quận 6, TP.HCM", "dothif@example.com", "Nữ", "Kinh Tế", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 10, 30, 14, 980, DateTimeKind.Local).AddTicks(5695), "0906789012", "Đỗ Thị F", "Đang học" },
                    { "SV007", "ngovang.jpg", "789012345678", "Mạng Máy Tính", "Kinh", "234 Đường G, Quận 7, TP.HCM", "ngovang@example.com", "Nam", "CNTT", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 10, 30, 14, 980, DateTimeKind.Local).AddTicks(5697), "0907890123", "Ngô Văn G", "Đang học" },
                    { "SV008", "phanthih.jpg", "890123456789", "Kế Toán", "Kinh", "345 Đường H, Quận 8, TP.HCM", "phanthih@example.com", "Nữ", "Kinh Tế", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 10, 30, 14, 980, DateTimeKind.Local).AddTicks(5700), "0908901234", "Phan Thị H", "Đang học" },
                    { "SV009", "buivani.jpg", "901234567890", "Khoa Học Máy Tính", "Kinh", "456 Đường I, Quận 9, TP.HCM", "buivani@example.com", "Nam", "CNTT", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 10, 30, 14, 980, DateTimeKind.Local).AddTicks(5702), "0909012345", "Bùi Văn I", "Đang học" },
                    { "SV010", "vothik.jpg", "012345678901", "Quản Trị Kinh Doanh", "Kinh", "567 Đường K, Quận 10, TP.HCM", "vothik@example.com", "Nữ", "Kinh Tế", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 10, 30, 14, 980, DateTimeKind.Local).AddTicks(5704), "0900123456", "Võ Thị K", "Đang học" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV001");

            migrationBuilder.DeleteData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV002");

            migrationBuilder.DeleteData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV003");

            migrationBuilder.DeleteData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV004");

            migrationBuilder.DeleteData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV005");

            migrationBuilder.DeleteData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV006");

            migrationBuilder.DeleteData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV007");

            migrationBuilder.DeleteData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV008");

            migrationBuilder.DeleteData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV009");

            migrationBuilder.DeleteData(
                table: "GiangVien",
                keyColumn: "MaGiangVien",
                keyValue: "GV010");

            migrationBuilder.DeleteData(
                table: "HocKyBlock",
                keyColumn: "MaHocKyBlock",
                keyValue: "FA24BL1");

            migrationBuilder.DeleteData(
                table: "HocKyBlock",
                keyColumn: "MaHocKyBlock",
                keyValue: "FA24BL2");

            migrationBuilder.DeleteData(
                table: "HocKyBlock",
                keyColumn: "MaHocKyBlock",
                keyValue: "SM24BL1");

            migrationBuilder.DeleteData(
                table: "HocKyBlock",
                keyColumn: "MaHocKyBlock",
                keyValue: "SM24BL2");

            migrationBuilder.DeleteData(
                table: "HocKyBlock",
                keyColumn: "MaHocKyBlock",
                keyValue: "SP24BL1");

            migrationBuilder.DeleteData(
                table: "HocKyBlock",
                keyColumn: "MaHocKyBlock",
                keyValue: "SP24BL2");

            migrationBuilder.DeleteData(
                table: "HocKyBlock",
                keyColumn: "MaHocKyBlock",
                keyValue: "SP25BL1");

            migrationBuilder.DeleteData(
                table: "HocKyBlock",
                keyColumn: "MaHocKyBlock",
                keyValue: "SP25BL2");

            migrationBuilder.DeleteData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH001");

            migrationBuilder.DeleteData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH002");

            migrationBuilder.DeleteData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH003");

            migrationBuilder.DeleteData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH004");

            migrationBuilder.DeleteData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH005");

            migrationBuilder.DeleteData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH006");

            migrationBuilder.DeleteData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH007");

            migrationBuilder.DeleteData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH008");

            migrationBuilder.DeleteData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH009");

            migrationBuilder.DeleteData(
                table: "LopHoc",
                keyColumn: "MaLop",
                keyValue: "LH010");

            migrationBuilder.DeleteData(
                table: "MonHoc",
                keyColumn: "MaMonHoc",
                keyValue: "MH001");

            migrationBuilder.DeleteData(
                table: "MonHoc",
                keyColumn: "MaMonHoc",
                keyValue: "MH002");

            migrationBuilder.DeleteData(
                table: "MonHoc",
                keyColumn: "MaMonHoc",
                keyValue: "MH003");

            migrationBuilder.DeleteData(
                table: "MonHoc",
                keyColumn: "MaMonHoc",
                keyValue: "MH004");

            migrationBuilder.DeleteData(
                table: "MonHoc",
                keyColumn: "MaMonHoc",
                keyValue: "MH005");

            migrationBuilder.DeleteData(
                table: "MonHoc",
                keyColumn: "MaMonHoc",
                keyValue: "MH006");

            migrationBuilder.DeleteData(
                table: "MonHoc",
                keyColumn: "MaMonHoc",
                keyValue: "MH007");

            migrationBuilder.DeleteData(
                table: "MonHoc",
                keyColumn: "MaMonHoc",
                keyValue: "MH008");

            migrationBuilder.DeleteData(
                table: "MonHoc",
                keyColumn: "MaMonHoc",
                keyValue: "MH009");

            migrationBuilder.DeleteData(
                table: "MonHoc",
                keyColumn: "MaMonHoc",
                keyValue: "MH010");

            migrationBuilder.DeleteData(
                table: "PhongHoc",
                keyColumn: "MaPhong",
                keyValue: "P001");

            migrationBuilder.DeleteData(
                table: "PhongHoc",
                keyColumn: "MaPhong",
                keyValue: "P002");

            migrationBuilder.DeleteData(
                table: "PhongHoc",
                keyColumn: "MaPhong",
                keyValue: "P003");

            migrationBuilder.DeleteData(
                table: "PhongHoc",
                keyColumn: "MaPhong",
                keyValue: "P004");

            migrationBuilder.DeleteData(
                table: "PhongHoc",
                keyColumn: "MaPhong",
                keyValue: "P005");

            migrationBuilder.DeleteData(
                table: "PhongHoc",
                keyColumn: "MaPhong",
                keyValue: "P006");

            migrationBuilder.DeleteData(
                table: "PhongHoc",
                keyColumn: "MaPhong",
                keyValue: "P007");

            migrationBuilder.DeleteData(
                table: "PhongHoc",
                keyColumn: "MaPhong",
                keyValue: "P008");

            migrationBuilder.DeleteData(
                table: "PhongHoc",
                keyColumn: "MaPhong",
                keyValue: "P009");

            migrationBuilder.DeleteData(
                table: "PhongHoc",
                keyColumn: "MaPhong",
                keyValue: "P010");

            migrationBuilder.DeleteData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV001");

            migrationBuilder.DeleteData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV002");

            migrationBuilder.DeleteData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV003");

            migrationBuilder.DeleteData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV004");

            migrationBuilder.DeleteData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV005");

            migrationBuilder.DeleteData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV006");

            migrationBuilder.DeleteData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV007");

            migrationBuilder.DeleteData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV008");

            migrationBuilder.DeleteData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV009");

            migrationBuilder.DeleteData(
                table: "SinhVien",
                keyColumn: "MaSinhVien",
                keyValue: "SV010");
        }
    }
}
