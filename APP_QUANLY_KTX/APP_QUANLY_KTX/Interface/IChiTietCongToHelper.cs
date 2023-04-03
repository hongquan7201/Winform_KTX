using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IChiTietCongToHelper
    {
        Task<APIRespone<List<Chitietcongto>>> GetListChiTietCongTo();
        Task<APIRespone<Chitietcongto>> GetChiTietCongTo(Guid id);
        Task<APIRespone<string>> AddChiTietCongTo(Chitietcongto chiTietCongTo);
        Task<APIRespone<string>> EditChiTietCongTo(Guid id,Chitietcongto chiTietCongTo);
        Task<APIRespone<string>> DeleteChiTietCongTo(Guid id);
    }
}
