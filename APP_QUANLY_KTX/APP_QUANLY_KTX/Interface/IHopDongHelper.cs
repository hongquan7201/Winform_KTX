using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IHopDongHelper
    {
        Task<APIRespone<List<Hopdong>>> GetListHopDong(string token);
        Task<APIRespone<Hopdong>> GetHopDong(Guid id, string token);
        Task<APIRespone<string>> AddHopDong(Hopdong hopDong, string token);
        Task<APIRespone<string>> EditHopDong(Guid id,Hopdong hopDong, string token);
        Task<APIRespone<string>> DeleteHopDong(Guid id, string token);
    }
}
