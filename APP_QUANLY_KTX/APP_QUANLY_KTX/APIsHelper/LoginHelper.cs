using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Interface;

namespace ProjectQLKTX.APIsHelper
{
    public class LoginHelper : ILoginHelper
    {
        public Task<APIRespone<string>> Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task Register(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
