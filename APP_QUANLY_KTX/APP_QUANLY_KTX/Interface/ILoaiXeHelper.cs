using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface ILoaiXeHelper
    {
        Task<APIRespone<List<Loaixe>>> GetListLoaiXe();
        Task<APIRespone<Loaixe>> GetLoaiXe(Guid id);
        Task<APIRespone<string>> AddLoaiXe(Loaixe loaiXe);
        Task<APIRespone<string>> EditLoaiXe(Guid id,Loaixe loaiXe);
        Task<APIRespone<string>> DeleteLoaiXe(Guid id);
    }
}
