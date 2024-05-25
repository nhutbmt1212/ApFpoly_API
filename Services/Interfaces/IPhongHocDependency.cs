using ApFpoly_API.Model;

namespace ApFpoly_API.Services.Interfaces
{
    public interface IPhongHocDependency
    {
        List<PhongHoc> LayPhongHoc();
        PhongHoc LayPhongHocTheoMaPhongHoc(string MaPhongHoc);

        PhongHoc ThemPhongHoc(PhongHoc PhongHoc);

        Task<PhongHoc> SuaPhongHoc(PhongHoc PhongHoc);

        Task<PhongHoc> XoaPhongHoc(string MaPhongHoc);

        Task<IEnumerable<PhongHoc>> SearchingPhongHoc(string searchString);
    }
}
