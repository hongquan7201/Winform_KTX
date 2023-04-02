using ProjectQLKTX.Models;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IHoaDonHelper
    {
        Task GetListHoaDon();
        Task GetHoaDon(Guid id);
        Task AddHoaDon(Hoadon hoaDon);
        Task EditHoaDon(Congto hoaDon);
        Task DeleteHoaDon(Guid id);
    }
}
