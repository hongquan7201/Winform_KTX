using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IHoaDonHelper
    {
        Task<APIRespone<List<Hoadon>>> GetListHoaDon(string token);
        Task<APIRespone<List<Hoadon>>> GetHoaDon(Guid id, string token);
        Task<APIRespone<string>> AddHoaDon(Hoadon hoaDon, string token);
        Task<APIRespone<string>> EditHoaDon(Hoadon hoaDon, string token);
        Task<APIRespone<string>> DeleteHoaDon(Guid id, string token);
    }
}
