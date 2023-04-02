using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface ISinhVienHelper
    {
        Task GetListSinhVien();
        Task GetSinhVien(Guid id);
        Task AddSinhVien(Sinhvien sinhVien);
        Task EditSinhVien(Sinhvien sinhVien);
        Task DeleteSinhVien(Guid id);
    }
}
