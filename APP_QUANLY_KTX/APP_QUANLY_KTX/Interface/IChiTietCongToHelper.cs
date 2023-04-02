using ProjectQLKTX.APIsHelper.BienLaiHelper;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IChiTietCongToHelper
    {
        Task GetListChiTietCongTo();
        Task GetChiTietCongTo(Guid id);
        Task AddChiTietCongTo(Chitietcongto chiTietCongTo);
        Task EditChiTietCongTo(Guid id,Chitietcongto chiTietCongTo);
        Task DeleteChiTietCongTo(Guid id);
    }
}
