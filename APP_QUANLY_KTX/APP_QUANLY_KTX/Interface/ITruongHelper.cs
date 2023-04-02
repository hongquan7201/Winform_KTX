using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface ITruongHelper
    {
        Task GetListTruong();
        Task GetTruong(Guid id);
        Task AddTruong(Truong truong);
        Task EditTruong(Truong truong);
        Task DeleteTruong(Guid id);
    }
}
