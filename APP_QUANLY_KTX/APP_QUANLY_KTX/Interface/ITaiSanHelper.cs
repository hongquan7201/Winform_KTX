using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface ITaiSanHelper
    {
        Task GetListTaiSan();
        Task GetTaiSan(Guid id);
        Task AddTaiSan(Taisan taiSan);
        Task EditTaiSan(Taisan taiSan);
        Task DeleteTaiSan(Guid id);
    }
}
