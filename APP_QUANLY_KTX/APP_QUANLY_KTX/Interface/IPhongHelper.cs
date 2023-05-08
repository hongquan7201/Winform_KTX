using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IPhongHelper
    {
        Task<APIRespone<List<Phong>>> GetListPhong(string token);
        Task<APIRespone<List<Phong>>> GetPhong(Guid? id, string token);
        Task<APIRespone<string>> AddPhong(Phong phong, string token);
        Task<APIRespone<string>> EditPhong(Phong phong, string token);
        Task<APIRespone<string>> DeletePhong(Guid id, string token);
        Task<APIRespone<string>> AddSinhVien(SVP sVP, string token);
        Task<APIRespone<string>> DeleteSinhVien(Guid? id, string token);
    }
}
