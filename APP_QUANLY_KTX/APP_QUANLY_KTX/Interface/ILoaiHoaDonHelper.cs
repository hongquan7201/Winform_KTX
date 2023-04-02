using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface ILoaiHoaDonHelper
    {
        Task GetListLoaiHoaDon();
        Task GetLoaiHoaDon(Guid id);
        Task AddLoaiHoaDon(Loaihoadon loaiHoaDon);
        Task EditLoaiHoaDon(Loaihoadon loaiHoaDon);
        Task DeleteLoaiHoaDon(Guid id);
    }
}
