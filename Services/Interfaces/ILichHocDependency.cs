using ApFpoly_API.DTO;
using ApFpoly_API.Model;
using System;
using System.Collections.Generic;

namespace ApFpoly_API.Services.Interfaces
{
    public interface ILichHocDependency
    {
        List<LichHoc> LayDanhSachLichHoc();
        LichHoc LayLichHocTheoId(string id);
        List<LichHoc> LayLichHocTheoMaHocKyBlockVaLop(HocKyBlockVaLopDTO hocKyBlockVaLopDTO);
        List<LichHoc> ThemLichHoc(List<LichHoc> lichHoc);
        LichHoc SuaLichHoc(LichHoc lichHoc);
        LichHoc XoaLichHoc(string id);
    }
}
