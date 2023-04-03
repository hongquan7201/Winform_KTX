using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IKhoHelper
    {
        Task<APIRespone<List<Kho>>> GetListKho();
        Task<APIRespone<Kho>> GetKho(Guid id);
        Task<APIRespone<string>> AddKho(Kho kho);
        Task<APIRespone<string>> EditKho(Guid id,Kho kho);
        Task<APIRespone<string>> DeleteKho(Guid id);
    }
}
