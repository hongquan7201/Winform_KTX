using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IPhieuGiaHanHelper
    {
        Task GetListPhieuGiaHan();
        Task GetPhieuGiaHan(Guid id);
        Task AddPhieuGiaHan(Phieugiahan phieuGiaHan);
        Task EditPhieuGiaHan(Phieugiahan phieuGiaHan);
        Task DeletePhieuGiaHan(Guid id);
    }
}
