﻿using ApFpoly_API.DTO;
using ApFpoly_API.Model;
using System;
using System.Collections.Generic;

namespace ApFpoly_API.Services.Interfaces
{
    public interface ILichHocDependency
    {
        List<LichHoc> LayDanhSachLichHoc();
        LichHoc LayLichHocTheoId(string id);
        Task<IEnumerable<LichHoc>> LayLichHocTheoIdLop(string id);

        List<LichHoc> LayLichHocTheoMaHocKyBlockVaLop(HocKyBlockVaLopDTO hocKyBlockVaLopDTO);
        List<LichHoc> ThemLichHoc(List<LichHoc> lichHoc);

        Task<IEnumerable<LichHoc>> SuaLichHoc(List<LichHoc> lichHoc);

        Task<List<LichHoc>> CheckByIdLopIdHocKyBlockIdMonAndNgayLichHoc(List<LichHoc> lichHoc);
        Task<IEnumerable<LichHoc>> XoaLichHoc(List<LichHoc> lichHoc);
        Task<IEnumerable<LichHoc>> LayLichHocTheoMaLopVaMaHocKyBlock(string MaLop, string MaHocKyBlock);
    }
}
