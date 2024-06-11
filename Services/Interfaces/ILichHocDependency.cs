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
        Task<IEnumerable<LichHoc>> LayLichHocTheoIdLop(string id);

        List<LichHoc> LayLichHocTheoMaHocKyBlockVaLop(HocKyBlockVaLopDTO hocKyBlockVaLopDTO);
        List<LichHoc> ThemLichHoc(List<LichHoc> lichHoc);

        Task<IEnumerable<LichHoc>> SuaLichHoc(List<LichHoc> lichHoc);

        Task<List<LichHoc>> CheckByIdLopIdHocKyBlockIdMonAndNgayLichHoc(List<LichHoc> lichHoc);
        Task<IEnumerable<LichHoc>> XoaLichHoc(List<LichHoc> lichHoc);
        Task<IEnumerable<LichHoc>> LayLichHocTheoMaLopVaMaHocKyBlock(string MaLop, string MaHocKyBlock);
        Task<IEnumerable<LichHoc>> LayLichHocUniqueMonHocTheoMaLop(string MaLop, string MaHocKyBlock);
        Task<IEnumerable<LichHoc>> LayLichHoctheoIdMonHocIdLopVaIdHocKyBlock(string MaLop,string MaMonHoc, string MaHocKyBlock);
        Task<IEnumerable<LichHoc>> LayLichHocTheoMaGiangVien(string MaGiangVien, string MaHocKyBlock);

        Task<IEnumerable<LichHoc>> LayCacLichHocDaTrung(LichHoc lichHoc);
        Task<IEnumerable<LichHoc>> LayCacLichHocDaTrungTruMaLichTarget(LichHoc lichHoc);

        byte[] ExportLichHocToExcel();
    }
}
