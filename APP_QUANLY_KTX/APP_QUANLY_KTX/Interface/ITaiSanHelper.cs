using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface ITaiSanHelper
    {
        Task<APIRespone<List<Taisan>>> GetListTaiSan();
        Task<APIRespone<List<Taisan>>> GetTaiSan(Guid id);
        Task<APIRespone<string>> AddTaiSan(Taisan taiSan);
        Task<APIRespone<string>> EditTaiSan(Taisan taiSan);
        Task<APIRespone<string>> DeleteTaiSan(Guid id);
    }
}
