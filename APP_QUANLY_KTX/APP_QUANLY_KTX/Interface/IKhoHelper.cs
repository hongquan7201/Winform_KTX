using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IKhoHelper
    {
        Task GetListKho();
        Task GetKho(Guid id);
        Task AddKho(Kho kho);
        Task EditKho(Kho kho);
        Task DeleteKho(Guid id);
    }
}
