using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface ILoaiKhuHelper
    {
        Task<APIRespone<List<Loaikhu>>> GetListLoaiKhu();
        Task<APIRespone<Loaikhu>> GetLoaiKhu(Guid id);
        Task<APIRespone<string>> AddLoaiKhu(Loaikhu loaiKhu);
        Task<APIRespone<string>> EditLoaiKhu(Guid id,Loaikhu loaiKhu);
        Task<APIRespone<string>> DeleteLoaiKhu(Guid id);
    }
}
