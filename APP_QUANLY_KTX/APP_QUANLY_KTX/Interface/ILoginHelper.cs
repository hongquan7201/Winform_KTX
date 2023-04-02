using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface ILoginHelper
    {
        Task Login(string email,string password);
        Task Register(string email, string password);
    }
}
