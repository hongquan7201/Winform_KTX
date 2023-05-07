using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IPhieuGiaHanHelper
    {
        Task<APIRespone<List<Phieugiahan>>> GetListPhieuGiaHan(string token);
        Task<APIRespone<Phieugiahan>> GetPhieuGiaHan(Guid id, string token);
        Task<APIRespone<string>> AddPhieuGiaHan(Phieugiahan phieuGiaHan, string token);
        Task<APIRespone<string>> EditPhieuGiaHan(Guid id,Phieugiahan phieuGiaHan, string token);
        Task<APIRespone<string>> DeletePhieuGiaHan(Guid id, string token);
    }
}
