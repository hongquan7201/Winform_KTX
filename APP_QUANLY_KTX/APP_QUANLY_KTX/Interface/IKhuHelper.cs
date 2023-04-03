using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IKhuHelper
    {
        Task<APIRespone<List<Khu>>> GetListKhu();
        Task<APIRespone<Khu>> GetKhu(Guid id);
        Task<APIRespone<string>> AddKhu(Khu khu);
        Task<APIRespone<string>> EditKhu(Guid id,Khu khu);
        Task<APIRespone<string>> DeleteKhu(Guid id);
    }
}
