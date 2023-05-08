using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IQuanHeHelper
    {
        Task<APIRespone<List<Quanhe>>> GetListQuanHe(string token);
        Task<APIRespone<List<Quanhe>>> GetQuanHe(Guid? id, string token);
        Task<APIRespone<string>> AddQuanHe(Quanhe quanHe, string token);
        Task<APIRespone<string>> EditQuanHe(Guid id,Quanhe quanHe, string token);
        Task<APIRespone<string>> DeleteQuanHe(Guid id, string token);
    }
}
