using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IHopDongHelper
    {
        Task GetListHopDong();
        Task GetHopDong(Guid id);
        Task AddHopDong(Hopdong hopDong);
        Task EditHopDong(Hopdong hopDong);
        Task DeleteHopDong(Guid id);
    }
}
