using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface ICongToHelper
    {
        Task<APIRespone<List<Congto>>> GetListCongTo();
        Task<APIRespone<Bienlai>> GetCongTo(Guid id);
        Task<APIRespone<string>> AddCongTo(Congto CongTo);
        Task<APIRespone<string>> EditCongTo(Guid id,Congto CongTo);
        Task<APIRespone<string>> DeleteCongTo(Guid id);

    }
}
