using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IPhieuKhoHelper
    {

        Task GetListPhieuKho();
        Task GetPhieuKho(Guid id);
        Task AddPhieuKho(Phieukho phieuKho);
        Task EditPhieuKho(Phieukho phieuKho);
        Task DeletePhieuKho(Guid id);
    }
}
