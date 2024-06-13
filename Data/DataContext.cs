﻿using ApFpoly_API.Model;
using Microsoft.EntityFrameworkCore;

namespace ApFpoly_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<SinhVien> SinhVien { get; set; }
        public DbSet<GiangVien> GiangVien { get; set; }
        public DbSet<MonHoc> MonHoc { get; set; }
        public DbSet<PhongHoc> PhongHoc { get; set; }
        public DbSet<HocKyBlock> HocKyBlock { get; set; }
        public DbSet<LopHoc> LopHoc { get; set; }
        public DbSet<LopHocChiTiet> LopHocChiTiet { get; set; }
        public DbSet<LichHoc> LichHoc { get; set; }
        public DbSet<DiemDanh> DiemDanh { get; set; }
        public DbSet<BangDiem> BangDiem { get; set; }
        public DbSet<NopBai> NopBai { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiemDanh>()
       .HasOne(d => d.LichHoc)
       .WithMany()
       .HasForeignKey(d => d.MaLichHoc)
       .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DiemDanh>()
                .HasOne(d => d.SinhVien)
                .WithMany()
                .HasForeignKey(d => d.MaSinhVien)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DiemDanh>()
                .HasOne(d => d.MonHoc)
                .WithMany()
                .HasForeignKey(d => d.MaMonHoc)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DiemDanh>()
                .HasOne(d => d.GiangVien)
                .WithMany()
                .HasForeignKey(d => d.MaGiangVien)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<LopHoc>().HasData(
        new LopHoc { MaLop = "LH00001", TenLop = "Toán cao cấp", NgayTao = DateTime.Now.AddDays(-100), SucChua = 30, TinhTrang = "Đang Đang hoạt động" },
        new LopHoc { MaLop = "LH00002", TenLop = "Vật lý đại cương", NgayTao = DateTime.Now.AddDays(-90), SucChua = 25, TinhTrang = "Đang Đang hoạt động" },
        new LopHoc { MaLop = "LH00003", TenLop = "Hóa học cơ bản", NgayTao = DateTime.Now.AddDays(-80), SucChua = 20, TinhTrang = "Đang Đang hoạt động" },
        new LopHoc { MaLop = "LH00004", TenLop = "Lập trình C#", NgayTao = DateTime.Now.AddDays(-70), SucChua = 35, TinhTrang = "Đang Đang hoạt động" },
        new LopHoc { MaLop = "LH00005", TenLop = "Lập trình Java", NgayTao = DateTime.Now.AddDays(-60), SucChua = 30, TinhTrang = "Đang Đang hoạt động" },
        new LopHoc { MaLop = "LH00006", TenLop = "Lập trình Python", NgayTao = DateTime.Now.AddDays(-50), SucChua = 25, TinhTrang = "Đang Đang hoạt động" },
        new LopHoc { MaLop = "LH00007", TenLop = "Lập trình JavaScript", NgayTao = DateTime.Now.AddDays(-40), SucChua = 20, TinhTrang = "Đang Đang hoạt động" },
        new LopHoc { MaLop = "LH00008", TenLop = "Lập trình PHP", NgayTao = DateTime.Now.AddDays(-30), SucChua = 35, TinhTrang = "Đang Đang hoạt động" },
        new LopHoc { MaLop = "LH00009", TenLop = "Lập trình Ruby", NgayTao = DateTime.Now.AddDays(-20), SucChua = 30, TinhTrang = "Đang Đang hoạt động" },
        new LopHoc { MaLop = "LH00010", TenLop = "Lập trình Swift", NgayTao = DateTime.Now.AddDays(-10), SucChua = 25, TinhTrang = "Đang Đang hoạt động" }
    );
            modelBuilder.Entity<SinhVien>().HasData(
           new SinhVien
           {
               MaSinhVien = "SV00001",
               TenSinhVien = "Nguyễn Văn A",
               SoDienThoai = "0901234567",
               GioiTinh = "Nam",
               DiaChi = "123 Đường A, Quận 1, TP.HCM",
               NgayNhapHoc = new DateTime(2021, 9, 1),
               CCCD = "123456789012",
               Email = "nhutbmt82@gmail.com",
               Khoa = "CNTT",
               ChuyenNganh = "Khoa Học Máy Tính",
               DanToc = "Kinh",
               NgaySinh = new DateTime(2000, 5, 20),
               NgayThem = DateTime.Now,
               TinhTrang = "Đang học",
               AnhSinhVien = "pexels-justin-shaifer-501272-1222271.jpg"
           },
           new SinhVien
           {
               MaSinhVien = "SV00002",
               TenSinhVien = "Trần Thị B",
               SoDienThoai = "0902345678",
               GioiTinh = "Nữ",
               DiaChi = "456 Đường B, Quận 2, TP.HCM",
               NgayNhapHoc = new DateTime(2021, 9, 1),
               CCCD = "234567890123",
               Email = "tranthib@sinhvien.com",
               Khoa = "Kinh Tế",
               ChuyenNganh = "Quản Trị Kinh Doanh",
               DanToc = "Kinh",
               NgaySinh = new DateTime(2001, 6, 15),
               NgayThem = DateTime.Now,
               TinhTrang = "Đang học",
               AnhSinhVien = "Image_PK0002.jpeg"
           },
           new SinhVien
           {
               MaSinhVien = "SV00003",
               TenSinhVien = "Lê Văn C",
               SoDienThoai = "0903456789",
               GioiTinh = "Nam",
               DiaChi = "789 Đường C, Quận 3, TP.HCM",
               NgayNhapHoc = new DateTime(2021, 9, 1),
               CCCD = "345678901234",
               Email = "levanc@sinhvien.com",
               Khoa = "CNTT",
               ChuyenNganh = "Mạng Máy Tính",
               DanToc = "Kinh",
               NgaySinh = new DateTime(2000, 7, 10),
               NgayThem = DateTime.Now,
               TinhTrang = "Đang học",
               AnhSinhVien = "Image_PK0002.jpeg"
           },
           new SinhVien
           {
               MaSinhVien = "SV00004",
               TenSinhVien = "Phạm Thị D",
               SoDienThoai = "0904567890",
               GioiTinh = "Nữ",
               DiaChi = "101 Đường D, Quận 4, TP.HCM",
               NgayNhapHoc = new DateTime(2021, 9, 1),
               CCCD = "456789012345",
               Email = "phamthid@sinhvien.com",
               Khoa = "Kinh Tế",
               ChuyenNganh = "Kế Toán",
               DanToc = "Kinh",
               NgaySinh = new DateTime(2001, 8, 5),
               NgayThem = DateTime.Now,
               TinhTrang = "Đang học",
               AnhSinhVien = "images.jpg"
           },
           new SinhVien
           {
               MaSinhVien = "SV00005",
               TenSinhVien = "Hoàng Văn E",
               SoDienThoai = "0905678901",
               GioiTinh = "Nam",
               DiaChi = "112 Đường E, Quận 5, TP.HCM",
               NgayNhapHoc = new DateTime(2021, 9, 1),
               CCCD = "567890123456",
               Email = "hoangvane@sinhvien.com",
               Khoa = "CNTT",
               ChuyenNganh = "Khoa Học Máy Tính",
               DanToc = "Kinh",
               NgaySinh = new DateTime(2000, 9, 25),
               NgayThem = DateTime.Now,
               TinhTrang = "Đang học",
               AnhSinhVien = "Image_PK0002.jpeg"
           },
           new SinhVien
           {
               MaSinhVien = "SV00006",
               TenSinhVien = "Đỗ Thị F",
               SoDienThoai = "0906789012",
               GioiTinh = "Nữ",
               DiaChi = "123 Đường F, Quận 6, TP.HCM",
               NgayNhapHoc = new DateTime(2021, 9, 1),
               CCCD = "678901234567",
               Email = "dothif@sinhvien.com",
               Khoa = "Kinh Tế",
               ChuyenNganh = "Quản Trị Kinh Doanh",
               DanToc = "Kinh",
               NgaySinh = new DateTime(2001, 10, 30),
               NgayThem = DateTime.Now,
               TinhTrang = "Đang học",
               AnhSinhVien = "Image_PK0002.jpeg"
           },
           new SinhVien
           {
               MaSinhVien = "SV00007",
               TenSinhVien = "Ngô Văn G",
               SoDienThoai = "0907890123",
               GioiTinh = "Nam",
               DiaChi = "234 Đường G, Quận 7, TP.HCM",
               NgayNhapHoc = new DateTime(2021, 9, 1),
               CCCD = "789012345678",
               Email = "ngovang@sinhvien.com",
               Khoa = "CNTT",
               ChuyenNganh = "Mạng Máy Tính",
               DanToc = "Kinh",
               NgaySinh = new DateTime(2000, 11, 15),
               NgayThem = DateTime.Now,
               TinhTrang = "Đang học",
               AnhSinhVien = "Image_PK0002.jpeg"
           },
           new SinhVien
           {
               MaSinhVien = "SV00008",
               TenSinhVien = "Phan Thị H",
               SoDienThoai = "0908901234",
               GioiTinh = "Nữ",
               DiaChi = "345 Đường H, Quận 8, TP.HCM",
               NgayNhapHoc = new DateTime(2021, 9, 1),
               CCCD = "890123456789",
               Email = "phanthih@sinhvien.com",
               Khoa = "Kinh Tế",
               ChuyenNganh = "Kế Toán",
               DanToc = "Kinh",
               NgaySinh = new DateTime(2001, 12, 5),
               NgayThem = DateTime.Now,
               TinhTrang = "Đang học",
               AnhSinhVien = "Image_PK0002.jpeg"
           },
           new SinhVien
           {
               MaSinhVien = "SV00009",
               TenSinhVien = "Bùi Văn I",
               SoDienThoai = "0909012345",
               GioiTinh = "Nam",
               DiaChi = "456 Đường I, Quận 9, TP.HCM",
               NgayNhapHoc = new DateTime(2021, 9, 1),
               CCCD = "901234567890",
               Email = "buivani@sinhvien.com",
               Khoa = "CNTT",
               ChuyenNganh = "Khoa Học Máy Tính",
               DanToc = "Kinh",
               NgaySinh = new DateTime(2000, 1, 20),
               NgayThem = DateTime.Now,
               TinhTrang = "Đang học",
               AnhSinhVien = "Image_PK0002.jpeg"
           },
           new SinhVien
           {
               MaSinhVien = "SV00010",
               TenSinhVien = "Võ Thị K",
               SoDienThoai = "0900123456",
               GioiTinh = "Nữ",
               DiaChi = "567 Đường K, Quận 10, TP.HCM",
               NgayNhapHoc = new DateTime(2021, 9, 1),
               CCCD = "012345678901",
               Email = "vothik@sinhvien.com",
               Khoa = "Kinh Tế",
               ChuyenNganh = "Quản Trị Kinh Doanh",
               DanToc = "Kinh",
               NgaySinh = new DateTime(2001, 2, 10),
               NgayThem = DateTime.Now,
               TinhTrang = "Đang học",
               AnhSinhVien = "Image_PK0002.jpeg"
           }
       );
            modelBuilder.Entity<PhongHoc>().HasData(
           new PhongHoc
           {
               MaPhong = "P000001",
               TenPhong = "Phòng A1",
               NgayTao = new DateTime(2022, 1, 10),
               LoaiPhong = "Giảng Đường",
               SucChua = 100,
               TinhTrang = "Đang hoạt động"
           },
           new PhongHoc
           {
               MaPhong = "P000002",
               TenPhong = "Phòng B1",
               NgayTao = new DateTime(2022, 1, 12),
               LoaiPhong = "Phòng Thí Nghiệm",
               SucChua = 30,
               TinhTrang = "Đang hoạt động"
           },
           new PhongHoc
           {
               MaPhong = "P000003",
               TenPhong = "Phòng C1",
               NgayTao = new DateTime(2022, 1, 15),
               LoaiPhong = "Phòng Học Nhóm",
               SucChua = 20,
               TinhTrang = "Đang hoạt động"
           },
           new PhongHoc
           {
               MaPhong = "P000004",
               TenPhong = "Phòng D1",
               NgayTao = new DateTime(2022, 1, 18),
               LoaiPhong = "Phòng Máy Tính",
               SucChua = 40,
               TinhTrang = "Đang hoạt động"
           },
           new PhongHoc
           {
               MaPhong = "P000005",
               TenPhong = "Phòng E1",
               NgayTao = new DateTime(2022, 1, 20),
               LoaiPhong = "Phòng Thực Hành",
               SucChua = 50,
               TinhTrang = "Đang hoạt động"
           },
           new PhongHoc
           {
               MaPhong = "P000006",
               TenPhong = "Phòng F1",
               NgayTao = new DateTime(2022, 1, 22),
               LoaiPhong = "Phòng Hội Thảo",
               SucChua = 70,
               TinhTrang = "Đang hoạt động"
           },
           new PhongHoc
           {
               MaPhong = "P000007",
               TenPhong = "Phòng G1",
               NgayTao = new DateTime(2022, 1, 25),
               LoaiPhong = "Giảng Đường",
               SucChua = 100,
               TinhTrang = "Đang hoạt động"
           },
           new PhongHoc
           {
               MaPhong = "P000008",
               TenPhong = "Phòng H1",
               NgayTao = new DateTime(2022, 1, 27),
               LoaiPhong = "Phòng Thí Nghiệm",
               SucChua = 30,
               TinhTrang = "Đang hoạt động"
           },
           new PhongHoc
           {
               MaPhong = "P000009",
               TenPhong = "Phòng I1",
               NgayTao = new DateTime(2022, 1, 29),
               LoaiPhong = "Phòng Học Nhóm",
               SucChua = 20,
               TinhTrang = "Đang hoạt động"
           },
           new PhongHoc
           {
               MaPhong = "P000010",
               TenPhong = "Phòng J1",
               NgayTao = new DateTime(2022, 1, 31),
               LoaiPhong = "Phòng Máy Tính",
               SucChua = 40,
               TinhTrang = "Đang hoạt động"
           }
       );
            modelBuilder.Entity<MonHoc>().HasData(
          new MonHoc
          {
              MaMonHoc = "MH00001",
              TenMonHoc = "Toán Cao Cấp",
              NgayTao = new DateTime(2023, 1, 10),
              TinChi = 3,
              SoBuoi = 5,
              NoiDungMonHoc = "Toán cao cấp dành cho sinh viên ngành kỹ thuật.",
              TaiLieu = "Giáo trình Toán Cao Cấp - Tập 1",
              TinhTrang = "Đang hoạt động"
          },
          new MonHoc
          {
              MaMonHoc = "MH00002",
              TenMonHoc = "Vật Lý Đại Cương",
              NgayTao = new DateTime(2023, 1, 12),
              TinChi = 4,
              SoBuoi = 4,
              NoiDungMonHoc = "Kiến thức cơ bản về vật lý cho sinh viên.",
              TaiLieu = "Giáo trình Vật Lý Đại Cương",
              TinhTrang = "Đang hoạt động"
          },
          new MonHoc
          {
              MaMonHoc = "MH00003",
              TenMonHoc = "Hóa Học Cơ Bản",
              NgayTao = new DateTime(2023, 1, 15),
              TinChi = 3,
              SoBuoi = 5,
              NoiDungMonHoc = "Kiến thức hóa học cơ bản cho sinh viên không chuyên.",
              TaiLieu = "Giáo trình Hóa Học Cơ Bản",
              TinhTrang = "Đang hoạt động"
          },
          new MonHoc
          {
              MaMonHoc = "MH00004",
              TenMonHoc = "Lập Trình C",
              NgayTao = new DateTime(2023, 1, 18),
              TinChi = 3,
              SoBuoi = 4,
              NoiDungMonHoc = "Giới thiệu về lập trình C.",
              TaiLieu = "Giáo trình Lập Trình C",
              TinhTrang = "Đang hoạt động"
          },
          new MonHoc
          {
              MaMonHoc = "MH00005",
              TenMonHoc = "Cơ Sở Dữ Liệu",
              NgayTao = new DateTime(2023, 1, 20),
              TinChi = 4,
              SoBuoi = 6,
              NoiDungMonHoc = "Kiến thức cơ bản về cơ sở dữ liệu.",
              TaiLieu = "Giáo trình Cơ Sở Dữ Liệu",
              TinhTrang = "Đang hoạt động"
          },
          new MonHoc
          {
              MaMonHoc = "MH00006",
              TenMonHoc = "Hệ Điều Hành",
              NgayTao = new DateTime(2023, 1, 22),
              TinChi = 3,
              SoBuoi = 4,
              NoiDungMonHoc = "Giới thiệu về hệ điều hành và các khái niệm cơ bản.",
              TaiLieu = "Giáo trình Hệ Điều Hành",
              TinhTrang = "Đang hoạt động"
          },
          new MonHoc
          {
              MaMonHoc = "MH00007",
              TenMonHoc = "Mạng Máy Tính",
              NgayTao = new DateTime(2023, 1, 25),
              TinChi = 3,
              SoBuoi = 4,
              NoiDungMonHoc = "Kiến thức cơ bản về mạng máy tính.",
              TaiLieu = "Giáo trình Mạng Máy Tính",
              TinhTrang = "Đang hoạt động"
          },
          new MonHoc
          {
              MaMonHoc = "MH00008",
              TenMonHoc = "Trí Tuệ Nhân Tạo",
              NgayTao = new DateTime(2023, 1, 27),
              TinChi = 4,
              SoBuoi = 7,
              NoiDungMonHoc = "Giới thiệu về trí tuệ nhân tạo và các ứng dụng.",
              TaiLieu = "Giáo trình Trí Tuệ Nhân Tạo",
              TinhTrang = "Đang hoạt động"
          },
          new MonHoc
          {
              MaMonHoc = "MH00009",
              TenMonHoc = "Phân Tích Thiết Kế Hệ Thống",
              NgayTao = new DateTime(2023, 1, 29),
              TinChi = 3,
              SoBuoi = 4,
              NoiDungMonHoc = "Giới thiệu về phân tích và thiết kế hệ thống.",
              TaiLieu = "Giáo trình Phân Tích Thiết Kế Hệ Thống",
              TinhTrang = "Đang hoạt động"
          },
          new MonHoc
          {
              MaMonHoc = "MH00010",
              TenMonHoc = "Kinh Tế Học",
              NgayTao = new DateTime(2023, 1, 31),
              TinChi = 3,
              SoBuoi = 4,
              NoiDungMonHoc = "Kiến thức cơ bản về kinh tế học.",
              TaiLieu = "Giáo trình Kinh Tế Học",
              TinhTrang = "Đang hoạt động"
          }
      );
            modelBuilder.Entity<HocKyBlock>().HasData(
                // Spring 2024
                new HocKyBlock
                {
                    MaHocKyBlock = "SP24BL1",
                    TenHocKy = "Spring 2024",
                    TenBlock = "Block 1",
                    NgayBatDau = new DateTime(2024, 1, 1),
                    NgayKetThuc = new DateTime(2024, 2, 29),
                    TinhTrang = "Đang hoạt động"
                },
                new HocKyBlock
                {
                    MaHocKyBlock = "SP24BL2",
                    TenHocKy = "Spring 2024",
                    TenBlock = "Block 2",
                    NgayBatDau = new DateTime(2024, 3, 1),
                    NgayKetThuc = new DateTime(2024, 4, 30),
                    TinhTrang = "Đang hoạt động"
                },

                // Summer 2024
                new HocKyBlock
                {
                    MaHocKyBlock = "SM24BL1",
                    TenHocKy = "Summer 2024",
                    TenBlock = "Block 1",
                    NgayBatDau = new DateTime(2024, 5, 1),
                    NgayKetThuc = new DateTime(2024, 6, 30),
                    TinhTrang = "Đang hoạt động"
                },
                new HocKyBlock
                {
                    MaHocKyBlock = "SM24BL2",
                    TenHocKy = "Summer 2024",
                    TenBlock = "Block 2",
                    NgayBatDau = new DateTime(2024, 7, 1),
                    NgayKetThuc = new DateTime(2024, 8, 31),
                    TinhTrang = "Đang hoạt động"
                },

                // Fall 2024
                new HocKyBlock
                {
                    MaHocKyBlock = "FA24BL1",
                    TenHocKy = "Fall 2024",
                    TenBlock = "Block 1",
                    NgayBatDau = new DateTime(2024, 9, 1),
                    NgayKetThuc = new DateTime(2024, 10, 31),
                    TinhTrang = "Đang hoạt động"
                },
                new HocKyBlock
                {
                    MaHocKyBlock = "FA24BL2",
                    TenHocKy = "Fall 2024",
                    TenBlock = "Block 2",
                    NgayBatDau = new DateTime(2024, 11, 1),
                    NgayKetThuc = new DateTime(2024, 12, 31),
                    TinhTrang = "Đang hoạt động"
                },

                // Spring 2025
                new HocKyBlock
                {
                    MaHocKyBlock = "SP25BL1",
                    TenHocKy = "Spring 2025",
                    TenBlock = "Block 1",
                    NgayBatDau = new DateTime(2025, 1, 1),
                    NgayKetThuc = new DateTime(2025, 2, 28),
                    TinhTrang = "Đang hoạt động"
                },
                new HocKyBlock
                {
                    MaHocKyBlock = "SP25BL2",
                    TenHocKy = "Spring 2025",
                    TenBlock = "Block 2",
                    NgayBatDau = new DateTime(2025, 3, 1),
                    NgayKetThuc = new DateTime(2025, 4, 30),
                    TinhTrang = "Đang hoạt động"
                }
            );
            modelBuilder.Entity<GiangVien>().HasData(
    new GiangVien
    {
        MaGiangVien = "GV00001",
        TenGiangVien = "Nguyễn Văn A",
        GioiTinh = "Nam",
        SoDienThoai = "0123456789",
        NgaySinh = new DateTime(1980, 5, 15),
        DanToc = "Kinh",
        Nganh = "Công nghệ thông tin",
        Email = "nhuttmpk02967@fpt.edu.vn",
        CCCD = "123456789",
        NgayVaoLam = new DateTime(2010, 8, 20),
        DiaChi = "123 Đường ABC, Quận XYZ, TP HCM",
        ChucVu = "Giảng viên",
        NgayThem = DateTime.Now,
        TinhTrang = "Đang hoạt động",
        AnhGiangVien = "Image_PK0002.jpeg"
    },
    new GiangVien
    {
        MaGiangVien = "GV00002",
        TenGiangVien = "Trần Thị B",
        GioiTinh = "Nữ",
        SoDienThoai = "0987654321",
        NgaySinh = new DateTime(1975, 9, 10),
        DanToc = "Kinh",
        Nganh = "Kỹ thuật điện tử",
        Email = "tranthib@giangvien.com",
        CCCD = "987654321",
        NgayVaoLam = new DateTime(2008, 7, 15),
        DiaChi = "456 Đường XYZ, Quận ABC, TP HCM",
        ChucVu = "Phó trưởng khoa",
        NgayThem = DateTime.Now,
        TinhTrang = "Đang hoạt động",
        AnhGiangVien = "Image_PK0002.jpeg"
    },
    new GiangVien
    {
        MaGiangVien = "GV00003",
        TenGiangVien = "Phạm Thị C",
        GioiTinh = "Nữ",
        SoDienThoai = "0123456789",
        NgaySinh = new DateTime(1985, 3, 20),
        DanToc = "Kinh",
        Nganh = "Quản trị kinh doanh",
        Email = "phamthic@giangvien.com",
        CCCD = "987654321",
        NgayVaoLam = new DateTime(2012, 5, 10),
        DiaChi = "789 Đường XYZ, Quận XYZ, TP HCM",
        ChucVu = "Trưởng khoa",
        NgayThem = DateTime.Now,
        TinhTrang = "Đang hoạt động",
        AnhGiangVien = "Image_PK0002.jpeg"
    },
    new GiangVien
    {
        MaGiangVien = "GV00004",
        TenGiangVien = "Lê Văn D",
        GioiTinh = "Nam",
        SoDienThoai = "0987654321",
        NgaySinh = new DateTime(1978, 8, 25),
        DanToc = "Kinh",
        Nganh = "Kỹ thuật xây dựng",
        Email = "levand@giangvien.com",
        CCCD = "123456789",
        NgayVaoLam = new DateTime(2011, 6, 15),
        DiaChi = "101 Đường ABC, Quận ABC, TP HCM",
        ChucVu = "Phó trưởng khoa",
        NgayThem = DateTime.Now,
        TinhTrang = "Đang hoạt động",
        AnhGiangVien = "Image_PK0002.jpeg"
    },
    new GiangVien
    {
        MaGiangVien = "GV00005",
        TenGiangVien = "Hoàng Thị E",
        GioiTinh = "Nữ",
        SoDienThoai = "0123456789",
        NgaySinh = new DateTime(1982, 10, 5),
        DanToc = "Kinh",
        Nganh = "Ngôn ngữ Anh",
        Email = "hoangthie@giangvien.com",
        CCCD = "987654321",
        NgayVaoLam = new DateTime(2015, 9, 20),
        DiaChi = "456 Đường XYZ, Quận XYZ, TP HCM",
        ChucVu = "Giảng viên",
        NgayThem = DateTime.Now,
        TinhTrang = "Đang hoạt động",
        AnhGiangVien = "Image_PK0002.jpeg"
    },
    new GiangVien
    {
        MaGiangVien = "GV00006",
        TenGiangVien = "Đặng Văn F",
        GioiTinh = "Nam",
        SoDienThoai = "0987654321",
        NgaySinh = new DateTime(1970, 12, 12),
        DanToc = "Kinh",
        Nganh = "Kinh tế",
        Email = "dangvanf@giangvien.com",
        CCCD = "123456789",
        NgayVaoLam = new DateTime(2005, 11, 10),
        DiaChi = "789 Đường ABC, Quận ABC, TP HCM",
        ChucVu = "Trưởng khoa",
        NgayThem = DateTime.Now,
        TinhTrang = "Đang hoạt động",
        AnhGiangVien = "Image_PK0002.jpeg"
    },
    new GiangVien
    {
        MaGiangVien = "GV00007",
        TenGiangVien = "Vũ Thị G",
        GioiTinh = "Nữ",
        SoDienThoai = "0123456789",
        NgaySinh = new DateTime(1973, 6, 30),
        DanToc = "Kinh",
        Nganh = "Mỹ thuật",
        Email = "vuthig@giangvien.com",
        CCCD = "987654321",
        NgayVaoLam = new DateTime(2013, 7, 15),
        DiaChi = "101 Đường XYZ, Quận ABC, Quận XYZ, TP HCM",
        ChucVu = "Giảng viên",
        NgayThem = DateTime.Now,
        TinhTrang = "Đang hoạt động",
        AnhGiangVien = "Image_PK0002.jpeg"
    },
new GiangVien
{
    MaGiangVien = "GV00008",
    TenGiangVien = "Nguyễn Thanh H",
    GioiTinh = "Nam",
    SoDienThoai = "0987654321",
    NgaySinh = new DateTime(1976, 4, 25),
    DanToc = "Kinh",
    Nganh = "Tài chính",
    Email = "nguyenthanhh@giangvien.com",
    CCCD = "123456789",
    NgayVaoLam = new DateTime(2012, 8, 20),
    DiaChi = "123 Đường ABC, Quận ABC, TP HCM",
    ChucVu = "Phó trưởng khoa",
    NgayThem = DateTime.Now,
    TinhTrang = "Đang hoạt động",
    AnhGiangVien = "Image_PK0002.jpeg"
},
new GiangVien
{
    MaGiangVien = "GV00009",
    TenGiangVien = "Trần Văn I",
    GioiTinh = "Nam",
    SoDienThoai = "0123456789",
    NgaySinh = new DateTime(1983, 9, 8),
    DanToc = "Kinh",
    Nganh = "Luật",
    Email = "tranvani@giangvien.com",
    CCCD = "987654321",
    NgayVaoLam = new DateTime(2010, 5, 15),
    DiaChi = "456 Đường XYZ, Quận XYZ, TP HCM",
    ChucVu = "Giảng viên",
    NgayThem = DateTime.Now,
    TinhTrang = "Đang hoạt động",
    AnhGiangVien = "Image_PK0002.jpeg"
},
new GiangVien
{
    MaGiangVien = "GV00010",
    TenGiangVien = "Lê Thị K",
    GioiTinh = "Nữ",
    SoDienThoai = "0987654321",
    NgaySinh = new DateTime(1979, 11, 20),
    DanToc = "Kinh",
    Nganh = "Khoa học máy tính",
    Email = "lethik@giangvien.com",
    CCCD = "123456789",
    NgayVaoLam = new DateTime(2013, 7, 10),
    DiaChi = "101 Đường ABC, Quận ABC, TP HCM",
    ChucVu = "Trưởng khoa",
    NgayThem = DateTime.Now,
    TinhTrang = "Đang hoạt động",
    AnhGiangVien = "Image_PK0002.jpeg"
}
);
        }
    }
}
