using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface ISinhVienHelper
    {
        Task<APIRespone<List<Sinhvien>>> GetListSinhVien();
        Task<APIRespone<List<Sinhvien>>> GetSinhVienById(Guid? id);
        Task<APIRespone<string>> AddSinhVien(Sinhvien sinhVien);
        Task<APIRespone<string>> EditSinhVien(Guid id,Sinhvien sinhVien);
        Task<APIRespone<string>> DeleteSinhVien(Guid id);
        Task<APIRespone<List<Sinhvien>>> GetSinhVienByName(string name);
        Task<APIRespone<List<Sinhvien>>> GetSinhVienByCCCD(string cccd);
    }
}
