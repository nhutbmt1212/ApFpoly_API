using ApFpoly_API.Model;

namespace ApFpoly_API.Services.Interfaces
{
    public interface IGiangVienDependency
    {
        List<GiangVien> LayGiangVien();
        GiangVien LayGiangVienTheoMaGiangVien(string MaGiangVien);
        GiangVien LayGiangVienTheoEmail(string Email);


        GiangVien ThemGiangVien(GiangVien giangVien);

        Task<GiangVien> SuaGiangVien(GiangVien giangVien);

        Task<GiangVien> XoaGiangVien(string MaGiangVien);
 Task<IEnumerable<GiangVien>> SearchingGiangVien(string searchString);
        int SoLuongGiangVien();
       
        Task<IEnumerable<GiangVien>> SearchingGiangVienForTimKiem(string searchString, int limitItem);
        IEnumerable<GiangVien> GetGiangVien(int page, int pageSize);
        byte[] ExportGiangVienToExcel();
    }
}
