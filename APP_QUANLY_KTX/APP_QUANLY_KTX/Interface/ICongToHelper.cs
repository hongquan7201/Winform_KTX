using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IHoaDonHelpers
    {
        Task GetListHoaDon();
        Task GetHoaDon(Guid id);
        Task AddHoaDon(Congto HoaDon);
        Task EditHoaDon(Congto HoaDon);
        Task DeleteHoaDon(Guid id);

    }
}
