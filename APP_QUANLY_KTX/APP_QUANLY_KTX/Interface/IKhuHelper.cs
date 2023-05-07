using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IKhuHelper
    {
        Task<APIRespone<List<Khu>>> GetListKhu(string token);
        Task<APIRespone<List<Khu>>> GetKhu(Guid? id, string token);
        Task<APIRespone<string>> AddKhu(Khu khu, string token);
        Task<APIRespone<string>> EditKhu(Guid id,Khu khu, string token);
        Task<APIRespone<string>> DeleteKhu(Guid id, string token);
    }
}
