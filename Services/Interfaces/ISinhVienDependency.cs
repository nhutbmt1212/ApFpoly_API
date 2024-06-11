using ApFpoly_API.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApFpoly_API.Services.Interfaces
{
    public interface ISinhVienDependency
    {
        List<SinhVien> LaySinhVien();
        SinhVien LaySinhVienTheoMaSinhVien(string MaSinhVien);

        SinhVien LaySinhVienTheoEmail(string Email);

        SinhVien ThemSinhVien(SinhVien sinhvien);

        Task<SinhVien> SuaSinhVien(SinhVien sinhvien);

        Task<SinhVien> XoaSinhVien(string MaSinhVien);
        int SoLuongSinhVien();
        IEnumerable<SinhVien> GetSinhVien(int page, int pageSize);

        Task<IEnumerable<SinhVien>> SearchingSinhVien(string searchString, int limitItem);

        public byte[] ExportSinhVienToExcel();

    }
}


