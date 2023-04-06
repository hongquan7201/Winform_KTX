using ProjectQLKTX.Models;

namespace ProjectQLKTX.CallApis
{
    public class ICallApiHelper : CallApiHelper
    {
        private async void test()
        {
            var s = await GetList<Bienlai>("api/edit");
        }
    }
}
