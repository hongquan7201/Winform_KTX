using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IKhuHelper
    {
        Task GetListKhu();
        Task GetKhu(Guid id);
        Task AddKhu(Khu khu);
        Task EditKhu(Khu khu);
        Task DeleteKhu(Guid id);
    }
}
