using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface ITruongHelper
    {
        Task<APIRespone<List<Truong>>>GetListTruong(string token);
        Task<APIRespone<List<Truong>>> GetTruong(Guid? id, string token);
        Task<APIRespone<string>> AddTruong(Truong truong, string token);
        Task<APIRespone<string>> EditTruong(Truong truong, string token);
        Task<APIRespone<string>> DeleteTruong(Guid id, string token);
    }
}
