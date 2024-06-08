using ApFpoly_API.DTO;
using ApFpoly_API.Model;

namespace ApFpoly_API.Services.Interfaces
{
    public interface INopBaiDependency
    {
        Task<NopBai> ThemNopBai(NopBai nopBai);
        Task<IEnumerable<NopBai>> GetNopBaiTheoIdLopVaMonHoc(string MaLop, string MaMonHoc);
        Task<NopBai> SuaNopBai(NopBai nopBai);
        Task<NopBai> LayBaiNopTheoSinhVien(string MaSinhVien, string MaLop, string MaMonHoc);
        Task<NopBai> SuaBaiDaNopCuaSinhVien(NopBai nopBai);
    }
}
