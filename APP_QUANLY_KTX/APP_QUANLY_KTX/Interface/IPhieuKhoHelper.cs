using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IPhieuKhoHelper
    {
        Task<APIRespone<List<Phieukho>>> GetListPhieuKho(string token);
        Task<APIRespone<Phieukho>> GetPhieuKho(Guid id, string token);
        Task<APIRespone<string>> AddPhieuKho(Phieukho phieuKho, string token);
        Task<APIRespone<string>> EditPhieuKho(Guid id, Phieukho phieuKho, string token);
        Task<APIRespone<string>> DeletePhieuKho(Guid id, string token);
    }
}
