using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IHopDongHelper
    {
        Task<APIRespone<List<Hopdong>>> GetListHopDong();
        Task<APIRespone<Hopdong>> GetHopDong(Guid id);
        Task<APIRespone<string>> AddHopDong(Hopdong hopDong);
        Task<APIRespone<string>> EditHopDong(Guid id,Hopdong hopDong);
        Task<APIRespone<string>> DeleteHopDong(Guid id);
    }
}
