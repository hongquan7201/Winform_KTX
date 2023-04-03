using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IPhieuGiaHanHelper
    {
        Task<APIRespone<List<Phieugiahan>>> GetListPhieuGiaHan();
        Task<APIRespone<Phieugiahan>> GetPhieuGiaHan(Guid id);
        Task<APIRespone<string>> AddPhieuGiaHan(Phieugiahan phieuGiaHan);
        Task<APIRespone<string>> EditPhieuGiaHan(Guid id,Phieugiahan phieuGiaHan);
        Task<APIRespone<string>> DeletePhieuGiaHan(Guid id);
    }
}
