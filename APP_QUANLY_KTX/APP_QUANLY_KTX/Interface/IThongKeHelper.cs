using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IThongKeHelper
    {
        Task<APIRespone<ResponeThongKe>> GetThongKe(string url, int yearFind);
    }
}
