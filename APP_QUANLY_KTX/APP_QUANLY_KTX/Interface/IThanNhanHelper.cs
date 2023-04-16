using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IThanNhanHelper
    {
        Task<APIRespone<List<Thannhan>>> GetListThanNhan();
        Task<APIRespone<List<Thannhan>>> GetThanNhan(Guid? id);
        Task<APIRespone<string>> AddThanNhan(Thannhan thanNhan);
        Task<APIRespone<string>> EditThanNhan(Thannhan thanNhan);
        Task<APIRespone<string>> DeleteThanNhan(Guid? id);
    }
}
