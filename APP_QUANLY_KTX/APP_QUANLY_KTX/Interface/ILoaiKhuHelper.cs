using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface ILoaiKhuHelper
    {
        Task GetListLoaiKhu();
        Task GetLoaiKhu(Guid id);
        Task AddLoaiKhu(Loaikhu loaiKhu);
        Task EditLoaiKhu(Loaikhu loaiKhu);
        Task DeleteLoaiKhu(Guid id);
    }
}
