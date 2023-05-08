using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Logins
{
    public interface ILoginHelper
    {
        Task<LoginRespone<List<Nhanvien>>> Login(Account account);
    }
}
