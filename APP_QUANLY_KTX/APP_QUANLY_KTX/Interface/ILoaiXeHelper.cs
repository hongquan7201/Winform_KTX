using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface ILoaiXeHelper
    {
        Task<APIRespone<List<Loaixe>>> GetListLoaiXe(string token);
        Task<APIRespone<Loaixe>> GetLoaiXe(Guid id, string token);
        Task<APIRespone<string>> AddLoaiXe(Loaixe loaiXe, string token);
        Task<APIRespone<string>> EditLoaiXe(Guid id,Loaixe loaiXe, string token);
        Task<APIRespone<string>> DeleteLoaiXe(Guid id, string token);
    }
}
