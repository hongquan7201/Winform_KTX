using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Logins
{
    public interface ILoginHelper
    {
        Task<APIRespone<Nhanvien>> Login(Account account);
    }
}
