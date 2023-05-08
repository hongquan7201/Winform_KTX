using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface ISinhVienHelper
    {
        Task<APIRespone<List<Sinhvien>>> GetListSinhVien(string token);
        Task<APIRespone<List<Sinhvien>>> GetSinhVienById(Guid? id, string token);
        Task<Register> AddSinhVien(Sinhvien sinhVien, string token);
        Task<APIRespone<string>> EditSinhVien(Sinhvien sinhVien, string token);
        Task<APIRespone<string>> DeleteSinhVien(Guid? id, string token);
        Task<APIRespone<List<Sinhvien>>> GetSinhVienByName(string name, string token);
        Task<APIRespone<List<Sinhvien>>> GetSinhVienByCCCD(string cccd, string token);
        Task<APIRespone<List<Sinhvien>>> GetSinhVienByEmail(string email, string token);
    }
}
