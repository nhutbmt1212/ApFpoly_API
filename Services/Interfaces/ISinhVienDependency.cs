using ApFpoly_API.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApFpoly_API.Services.Interfaces
{
    public interface ISinhVienDependency
    {
        List<SinhVien> LaySinhVien();
        SinhVien LaySinhVienTheoMaSinhVien(string MaSinhVien);

        SinhVien ThemSinhVien(SinhVien sinhvien);

        Task<SinhVien> SuaSinhVien(SinhVien sinhvien);

        Task<SinhVien> XoaSinhVien(string MaSinhVien);
        int SoLuongSinhVien();
    }
}


