using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface ILoaiHoaDonHelper
    {
        Task<APIRespone<List<Loaihoadon>>> GetListLoaiHoaDon();
        Task<APIRespone<Loaihoadon>> GetLoaiHoaDon(Guid id);
        Task<APIRespone<string>> AddLoaiHoaDon(Loaihoadon loaiHoaDon);
        Task<APIRespone<string>> EditLoaiHoaDon(Guid id,Loaihoadon loaiHoaDon);
        Task<APIRespone<string>> DeleteLoaiHoaDon(Guid id);
    }
}
