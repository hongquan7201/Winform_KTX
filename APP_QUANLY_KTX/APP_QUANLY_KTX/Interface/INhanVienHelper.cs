using ProjectQLKTX.APIsHelper;
using ProjectQLKTX.APIsHelper.BienLaiHelper;
using ProjectQLKTX.APIsHelper.NhanVienHelper;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface INhanVienHelper
    {
        Task<NhanVienRespone<List<Nhanvien>>> GetListNhanVien();
        Task< NhanVienRespone<Nhanvien>> GetNhanVien(Guid id);
        Task AddNhanVien(Nhanvien nhanVien);
        Task <APIReponse> EditNhanVien(Guid id,Nhanvien nhanVien);
        Task DeleteNhanVien(Guid id);
    }
}
