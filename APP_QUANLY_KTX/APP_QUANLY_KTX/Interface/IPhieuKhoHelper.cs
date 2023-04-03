using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IPhieuKhoHelper
    {
        Task<APIRespone<List<Phieukho>>> GetListPhieuKho();
        Task<APIRespone<Phieukho>> GetPhieuKho(Guid id);
        Task<APIRespone<string>> AddPhieuKho(Phieukho phieuKho);
        Task<APIRespone<string>> EditPhieuKho(Guid id, Phieukho phieuKho);
        Task<APIRespone<string>> DeletePhieuKho(Guid id);
    }
}
