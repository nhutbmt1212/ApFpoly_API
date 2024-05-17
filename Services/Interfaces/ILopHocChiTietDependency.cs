using ApFpoly_API.Model;

namespace ApFpoly_API.Services.Interfaces
{
    public interface ILopHocChiTietDependency
    {
        List<LopHocChiTiet> LayLopHocChiTiet();
        LopHocChiTiet LayLopHocChiTietTheoMa(string MaLopHocChiTiet);

        LopHocChiTiet ThemLopHocChiTiet(LopHocChiTiet lopHocChiTiet);

        Task<LopHocChiTiet> SuaLopHocChiTiet(LopHocChiTiet lopHocChiTiet);

        Task<LopHocChiTiet> XoaLopHocChiTiet(string MaLopHocChiTiet);
    }
}
