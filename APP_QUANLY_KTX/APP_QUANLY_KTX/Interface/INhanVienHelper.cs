using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface INhanVienHelper
    {
        Task<APIRespone<List<Nhanvien>>> GetListNhanVien(string token);
        Task< APIRespone<List<Nhanvien>>> GetNhanVienById(Guid? id, string token);
        Task<APIRespone<string>> AddNhanVien(Nhanvien nhanVien, string token);
        Task <APIRespone<string>> EditNhanVien(Nhanvien nhanVien, string token);
        Task<APIRespone<string>> DeleteNhanVien(Guid id, string token);
        Task<APIRespone<List<Nhanvien>>> GetNhanVienByName(string? name, string token);
        Task<APIRespone<List<Nhanvien>>> GetNhanVienByEmail(string? email, string token);
        Task<APIRespone<string>> ResetPassword(string email);
       Task<APIRespone<string>>ChangePassword(ChangePasswordNhanVien changePasswordNhanVien , string token);
    }
}
