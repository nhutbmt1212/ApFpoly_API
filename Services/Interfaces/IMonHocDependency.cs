using ApFpoly_API.Model;

namespace ApFpoly_API.Services.Interfaces
{
    public interface IMonHocDependency
    {
        List<MonHoc> LayMonHoc();
        MonHoc LayMonHocTheoMaMonHoc(string MaMonHoc);

        MonHoc ThemMonHoc(MonHoc monhoc);

        Task<MonHoc> SuaMonHoc(MonHoc monhoc);

        Task<MonHoc> XoaMonHoc(string MaMonHoc);
        Task<IEnumerable<MonHoc>> SearchingMonHoc(string searchString);
        int SoLuongMonHoc();


    }
}
