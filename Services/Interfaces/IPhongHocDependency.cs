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

        int SoLuongPhongHoc();
        IEnumerable<PhongHoc> GetPhongHoc(int page, int pageSize);

        Task<IEnumerable<PhongHoc>> SearchingPhongHocForTimKiem(string searchString, int limitItem);
        byte[] ExportPhongHocToExcel();
    }
}
