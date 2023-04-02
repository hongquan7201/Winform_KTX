using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface ILoaiXeHelper
    {
        Task GetListLoaiXe();
        Task GetLoaiXe(Guid id);
        Task AddLoaiXe(Loaixe loaiXe);
        Task EditLoaiXe(Loaixe loaiXe);
        Task DeleteLoaiXe(Guid id);
    }
}
