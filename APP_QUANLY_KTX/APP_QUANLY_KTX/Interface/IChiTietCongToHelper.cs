using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IChiTietCongToHelper
    {
        Task<APIRespone<List<Chitietcongto>>> GetListChiTietCongTo(string token);
        Task<APIRespone<List<Chitietcongto>>> GetChiTietCongTo(Guid? id, string token);
        Task<APIRespone<string>> AddChiTietCongTo(Chitietcongto chiTietCongTo, string token);
        Task<APIRespone<string>> EditChiTietCongTo(Guid id,Chitietcongto chiTietCongTo, string token);
        Task<APIRespone<string>> DeleteChiTietCongTo(Guid id, string token);
    }
}
