using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IChietTietPhieuKhoHelper
    {
        Task<APIRespone<List<Chitietphieukho>>> GetListChietTietPhieuKho(string token);
        Task<APIRespone<Chitietphieukho>> GetChietTietPhieuKho(Guid id, string token);
        Task<APIRespone<string>> AddChietTietPhieuKho(Chitietphieukho chitietphieukho, string token);
        Task<APIRespone<string>> EditChietTietPhieuKho(Guid id ,Chitietphieukho chitietphieukho, string token);
        Task<APIRespone<string>> DeleteChietTietPhieuKho(Guid id, string token);
    }
}
