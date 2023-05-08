using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IThanNhanHelper
    {
        Task<APIRespone<List<Thannhan>>> GetListThanNhan(string token);
        Task<APIRespone<List<Thannhan>>> GetThanNhan(Guid? id, string token);
        Task<APIRespone<string>> AddThanNhan(Thannhan thanNhan, string token);
        Task<APIRespone<string>> EditThanNhan(Thannhan thanNhan, string token);
        Task<APIRespone<string>> DeleteThanNhan(Guid? id, string token);
    }
}
