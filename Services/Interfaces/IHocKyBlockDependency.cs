using ApFpoly_API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApFpoly_API.Services.Interfaces
{
    public interface IHocKyBlockDependency
    {
        List<HocKyBlock> LayHocKyBlock();
        HocKyBlock LayHocKyBlockTheoMa(string MaHocKyBlock);

        HocKyBlock ThemHocKyBlock(HocKyBlock hocKyBlock);

        Task<HocKyBlock> SuaHocKyBlock(HocKyBlock hocKyBlock);

        Task<HocKyBlock> XoaHocKyBlock(string MaHocKyBlock);
    }
}
