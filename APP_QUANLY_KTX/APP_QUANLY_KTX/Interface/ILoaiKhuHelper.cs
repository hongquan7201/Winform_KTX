using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface ILoaiKhuHelper
    {
        Task<APIRespone<List<Loaikhu>>> GetListLoaiKhu(string token);
        Task<APIRespone<Loaikhu>> GetLoaiKhu(Guid id, string token);
        Task<APIRespone<string>> AddLoaiKhu(Loaikhu loaiKhu, string token);
        Task<APIRespone<string>> EditLoaiKhu(Guid id,Loaikhu loaiKhu, string token);
        Task<APIRespone<string>> DeleteLoaiKhu(Guid id, string token);
    }
}
