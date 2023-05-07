using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IKhoHelper
    {
        Task<APIRespone<List<Kho>>> GetListKho(string token);
        Task<APIRespone<Kho>> GetKho(Guid id, string token);
        Task<APIRespone<string>> AddKho(Kho kho, string token);
        Task<APIRespone<string>> EditKho(Guid id,Kho kho,string token);
        Task<APIRespone<string>> DeleteKho(Guid id, string token);
    }
}
