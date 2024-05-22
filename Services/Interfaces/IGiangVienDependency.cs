using ApFpoly_API.Model;

namespace ApFpoly_API.Services.Interfaces
{
    public interface IGiangVienDependency
    {
        List<GiangVien> LayGiangVien();
        GiangVien LayGiangVienTheoMaGiangVien(string MaGiangVien);

        GiangVien ThemGiangVien(GiangVien giangVien);

        Task<GiangVien> SuaGiangVien(GiangVien giangVien);

        Task<GiangVien> XoaGiangVien(string MaGiangVien);

        int SoLuongGiangVien();
    }
}
