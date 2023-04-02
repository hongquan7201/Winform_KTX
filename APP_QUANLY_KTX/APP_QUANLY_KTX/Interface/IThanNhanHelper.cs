using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IThanNhanHelper
    {
        Task GetListThanNhan();
        Task GetThanNhan(Guid id);
        Task AddThanNhan(Thannhan thanNhan);
        Task EditThanNhan(Thannhan thanNhan);
        Task DeleteThanNhan(Guid id);
    }
}
