using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IChietTietPhieuKhoHelper
    {
        Task<APIRespone<List<Chitietphieukho>>> GetListChietTietPhieuKho();
        Task<APIRespone<Chitietphieukho>> GetChietTietPhieuKho(Guid id);
        Task<APIRespone<string>> AddChietTietPhieuKho(Chitietphieukho chitietphieukho);
        Task<APIRespone<string>> EditChietTietPhieuKho(Guid id ,Chitietphieukho chitietphieukho);
        Task<APIRespone<string>> DeleteChietTietPhieuKho(Guid id);
    }
}
