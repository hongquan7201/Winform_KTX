using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface INhanVienHelper
    {
        Task<APIRespone<List<Nhanvien>>> GetListNhanVien();
        Task< APIRespone<Nhanvien>> GetNhanVien(Guid id);
        Task<APIRespone<string>> AddNhanVien(Nhanvien nhanVien);
        Task <APIRespone<string>> EditNhanVien(Nhanvien nhanVien);
        Task<APIRespone<string>> DeleteNhanVien(Guid id);
    }
}
