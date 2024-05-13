using ApFpoly_API.Model;

namespace ApFpoly_API.Services.Interfaces
{
    public interface IMonHocChiTietDependency
    {
        List<MonHocChiTiet> LayMonHocChiTiet();
        MonHocChiTiet LayMonHocChiTietTheoMonHocChiTiet(string MaMonHocChiTiet);

        MonHocChiTiet ThemMonHocChiTiet(MonHocChiTiet monHocChiTiet);

        Task<MonHocChiTiet> SuaMonHocChiTiet(MonHocChiTiet monHocChiTiet);

        Task<MonHocChiTiet> XoaMonHocChiTiet(string MaMonHocChiTiet);
    }
}
