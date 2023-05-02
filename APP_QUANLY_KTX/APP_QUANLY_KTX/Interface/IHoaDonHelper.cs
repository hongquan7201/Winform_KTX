using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IHoaDonHelper
    {
        Task<APIRespone<List<Hoadon>>> GetListHoaDon();
        Task<APIRespone<Hoadon>> GetHoaDon(Guid id);
        Task<APIRespone<string>> AddHoaDon(Hoadon hoaDon);
        Task<APIRespone<string>> EditHoaDon(Hoadon hoaDon);
        Task<APIRespone<string>> DeleteHoaDon(Guid id);
    }
}
