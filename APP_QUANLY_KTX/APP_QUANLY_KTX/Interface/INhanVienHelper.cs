using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface INhanVienHelper
    {
        Task<APIRespone<List<Nhanvien>>> GetListNhanVien();
        Task< APIRespone<List<Nhanvien>>> GetNhanVienById(Guid? id);
        Task<APIRespone<string>> AddNhanVien(Nhanvien nhanVien);
        Task <APIRespone<string>> EditNhanVien(Nhanvien nhanVien);
        Task<APIRespone<string>> DeleteNhanVien(Guid id);
        Task<APIRespone<List<Nhanvien>>> GetNhanVienByName(string? name);
        Task<APIRespone<List<Nhanvien>>> GetNhanVienByEmail(string? email);
    }
}
