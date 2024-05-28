using ApFpoly_API.Model;

namespace ApFpoly_API.Services.Interfaces
{
    public interface ILopHocChiTietDependency
    {
        List<LopHocChiTiet> LayLopHocChiTiet();
        LopHocChiTiet LayLopHocChiTietTheoMa(string MaLopHocChiTiet);

        List<LopHocChiTiet> LayLopHocChiTietTheoMaLop(string MaLop);

        List<LopHocChiTiet> ThemLopHocChiTiet(List<LopHocChiTiet> lopHocChiTiet);

        Task<LopHocChiTiet> SuaLopHocChiTiet(LopHocChiTiet lopHocChiTiet);

        Task<List<LopHocChiTiet>> XoaLopHocChiTiet(List<LopHocChiTiet> lopHocChiTiet);

        ImportResultLopHocChiTiet ImportSinhVienVaoLopHocChiTiet(string MaLop,IFormFile fileExcel);

        LopHocChiTiet LayLopHocChiTietTheoMaLopVaMaSinhVien(string MaLop, string MaSinhVien);
        Task<IEnumerable<LopHocChiTiet>> LayLopHocChiTietTheoMaSinhVien(string MaSinhVien);
    }
}
