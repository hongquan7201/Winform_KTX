using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IPhongHelper
    {
        Task GetListPhong();
        Task GetPhong(Guid id);
        Task AddPhong(Phong phong);
        Task EditPhong(Phong phong);
        Task DeletePhong(Guid id);
    }
}
