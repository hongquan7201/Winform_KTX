using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface ITruongHelper
    {
        Task<APIRespone<List<Truong>>>GetListTruong();
        Task<APIRespone<Truong>>GetTruong(Guid id);
        Task<APIRespone<string>> AddTruong(Truong truong);
        Task<APIRespone<string>> EditTruong(Truong truong);
        Task<APIRespone<string>> DeleteTruong(Guid id);
    }
}
