using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IRoleHelper
    {
        Task GetListRole();
        Task GetRole(Guid id);
        Task AddRole(Role rle);
        Task EditRole(Role role);
        Task DeleteRole(Guid id);
    }
}
