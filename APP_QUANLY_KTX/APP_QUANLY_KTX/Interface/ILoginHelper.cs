using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface ILoginHelper
    {
        Task<APIRespone<string>> Login(string email,string password);
        Task Register(string email, string password);
    }
}
