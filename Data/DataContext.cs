using ApFpoly_API.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApFpoly_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<SinhVien> SinhVien { get; set;}
        public DbSet<GiangVien> GiangVien { get; set; }
        public DbSet<MonHoc> MonHoc { get; set; }
        public DbSet<PhongHoc> PhongHoc { get; set; }
        public DbSet<HocKyBlock> HocKyBlock { get; set; }
        public DbSet<MonHocChiTiet> MonHocChiTiet { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelbuilder)
        //{
        //    modelbuilder.Entity<MonHocChiTiet>()
        //    .HasKey(m => new { m.MaSinhVien, m.MaMonHoc, m.MaPhong, m.MaGiangVien });


        //}
    }
}
