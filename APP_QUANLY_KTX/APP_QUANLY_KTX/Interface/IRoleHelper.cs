using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IRoleHelper
    {
        Task<APIRespone<List<Role>>> GetListRole();
        Task<APIRespone<List<Role>>> GetRole(Guid? id);
        Task<APIRespone<List<Role>>> AddRole(Role role);
        Task<APIRespone<string>> EditRole(Role role);
        Task<APIRespone<string>> DeleteRole(Guid id);
    }
}
