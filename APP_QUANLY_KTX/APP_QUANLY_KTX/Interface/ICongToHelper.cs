using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface ICongToHelper
    {
        Task<APIRespone<List<Congto>>> GetListCongTo(string token);
        Task<APIRespone<List<Congto>>> GetCongTo(Guid? id, string token);
        Task<APIRespone<string>> AddCongTo(Congto CongTo, string token);
        Task<APIRespone<string>> EditCongTo(Guid id,Congto CongTo, string token);
        Task<APIRespone<string>> DeleteCongTo(Guid id, string token);

    }
}
