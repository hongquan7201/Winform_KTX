using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IChietTietPhieuKhoHelper
    {
        Task GetListChietTietPhieuKho();
        Task GetChietTietPhieuKho(Guid id);
        Task AddChietTietPhieuKho(Chitietphieukho chitietphieukho);
        Task EditChietTietPhieuKho(Chitietphieukho chitietphieukho);
        Task DeleteChietTietPhieuKho(Guid id);
    }
}
