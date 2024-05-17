using ApFpoly_API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApFpoly_API.Services.Interfaces
{
    public interface ILopHocDependency
    {
        List<LopHoc> LayLopHoc();
        LopHoc LayLopHocTheoMa(string MaLopHoc);

        LopHoc ThemLopHoc(LopHoc lopHoc);

        Task<LopHoc> SuaLopHoc(LopHoc lopHoc);

        Task<LopHoc> XoaLopHoc(string MaLopHoc);
    }
}
