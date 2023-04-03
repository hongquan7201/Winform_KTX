using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface ISinhVienHelper
    {
        Task<APIRespone<List<Sinhvien>>> GetListSinhVien();
        Task<APIRespone<Sinhvien>> GetSinhVien(Guid id);
        Task<APIRespone<string>> AddSinhVien(Sinhvien sinhVien);
        Task<APIRespone<string>> EditSinhVien(Guid id,Sinhvien sinhVien);
        Task<APIRespone<string>> DeleteSinhVien(Guid id);
    }
}
