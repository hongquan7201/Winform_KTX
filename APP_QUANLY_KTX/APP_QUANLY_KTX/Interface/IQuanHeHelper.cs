using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IQuanHeHelper
    {
        Task GetListQuanHe();
        Task GetQuanHe(Guid id);
        Task AddQuanHe(Quanhe quanHe);
        Task EditQuanHe(Quanhe quanHe);
        Task DeleteQuanHe(Guid id);
    }
}
