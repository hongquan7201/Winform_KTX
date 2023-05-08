using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface ITaiSanHelper
    {
        Task<APIRespone<List<Taisan>>> GetListTaiSan(string token);
        Task<APIRespone<List<Taisan>>> GetTaiSan(Guid id, string token);
        Task<APIRespone<string>> AddTaiSan(Taisan taiSan, string token);
        Task<APIRespone<string>> EditTaiSan(Taisan taiSan, string token);
        Task<APIRespone<string>> DeleteTaiSan(Guid id, string token);
    }
}
