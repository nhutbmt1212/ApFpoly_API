﻿// <auto-generated />
using System;
using ApFpoly_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApFpoly_API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApFpoly_API.Model.GiangVien", b =>
                {
                    b.Property<string>("MaGiangVien")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("AnhGiangVien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CCCD")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("ChucVu")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("DanToc")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("GioiTinh")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Nganh")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayThem")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayVaoLam")
                        .HasColumnType("datetime2");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("TenGiangVien")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<string>("TinhTrang")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("MaGiangVien");

                    b.ToTable("GiangVien");
                });

            modelBuilder.Entity("ApFpoly_API.Model.MonHoc", b =>
                {
                    b.Property<string>("MaMonHoc")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDungMonHoc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaiLieu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenMonHoc")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<short?>("ThoiGianHoc")
                        .HasColumnType("smallint");

                    b.Property<short?>("TinChi")
                        .HasColumnType("smallint");

                    b.Property<string>("TinhTrang")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("MaMonHoc");

                    b.ToTable("MonHoc");
                });

            modelBuilder.Entity("ApFpoly_API.Model.MonHocChiTiet", b =>
                {
                    b.Property<string>("MaMonHocChiTiet")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<short>("Block")
                        .HasMaxLength(1)
                        .HasColumnType("smallint");

                    b.Property<short?>("DiemSo")
                        .HasColumnType("smallint");

                    b.Property<short>("HocKy")
                        .HasColumnType("smallint");

                    b.Property<string>("Lop")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("MaGiangVien")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("MaMonHoc")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("MaPhong")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("MaSinhVien")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<DateTime>("NgayBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<string>("TinhTrang")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("MaMonHocChiTiet");

                    b.HasIndex("MaGiangVien");

                    b.HasIndex("MaMonHoc");

                    b.HasIndex("MaPhong");

                    b.HasIndex("MaSinhVien");

                    b.ToTable("MonHocChiTiet");
                });

            modelBuilder.Entity("ApFpoly_API.Model.PhongHoc", b =>
                {
                    b.Property<string>("MaPhong")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("LoaiPhong")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<short>("SucChua")
                        .HasColumnType("smallint");

                    b.Property<string>("TenPhong")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TinhTrang")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("MaPhong");

                    b.ToTable("PhongHoc");
                });

            modelBuilder.Entity("ApFpoly_API.Model.SinhVien", b =>
                {
                    b.Property<string>("MaSinhVien")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("AnhSinhVien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CCCD")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("ChuyenNganh")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DanToc")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("GioiTinh")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Khoa")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("NgayNhapHoc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayThem")
                        .HasColumnType("datetime2");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("TenSinhVien")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<string>("TinhTrang")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("MaSinhVien");

                    b.ToTable("SinhVien");
                });

            modelBuilder.Entity("ApFpoly_API.Model.MonHocChiTiet", b =>
                {
                    b.HasOne("ApFpoly_API.Model.GiangVien", "GiangVien")
                        .WithMany()
                        .HasForeignKey("MaGiangVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApFpoly_API.Model.MonHoc", "MonHoc")
                        .WithMany()
                        .HasForeignKey("MaMonHoc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApFpoly_API.Model.PhongHoc", "PhongHoc")
                        .WithMany()
                        .HasForeignKey("MaPhong")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApFpoly_API.Model.SinhVien", "SinhVien")
                        .WithMany()
                        .HasForeignKey("MaSinhVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GiangVien");

                    b.Navigation("MonHoc");

                    b.Navigation("PhongHoc");

                    b.Navigation("SinhVien");
                });
#pragma warning restore 612, 618
        }
    }
}
