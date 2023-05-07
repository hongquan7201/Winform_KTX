using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface ILoaiHoaDonHelper
    {
        Task<APIRespone<List<Loaihoadon>>> GetListLoaiHoaDon(string token);
        Task<APIRespone<Loaihoadon>> GetLoaiHoaDon(Guid id, string token);
        Task<APIRespone<string>> AddLoaiHoaDon(Loaihoadon loaiHoaDon, string token);
        Task<APIRespone<string>> EditLoaiHoaDon(Guid id,Loaihoadon loaiHoaDon, string token);
        Task<APIRespone<string>> DeleteLoaiHoaDon(Guid id, string token);
    }
}
