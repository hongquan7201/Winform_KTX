using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IQuanHeHelper
    {
        Task<APIRespone<List<Quanhe>>> GetListQuanHe();
        Task<APIRespone<List<Quanhe>>> GetQuanHe(Guid? id);
        Task<APIRespone<string>> AddQuanHe(Quanhe quanHe);
        Task<APIRespone<string>> EditQuanHe(Guid id,Quanhe quanHe);
        Task<APIRespone<string>> DeleteQuanHe(Guid id);
    }
}
