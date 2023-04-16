using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IPhongHelper
    {
        Task<APIRespone<List<Phong>>> GetListPhong();
        Task<APIRespone<Phong>> GetPhong(Guid? id);
        Task<APIRespone<string>> AddPhong(Phong phong);
        Task<APIRespone<string>> EditPhong(Guid id,Phong phong);
        Task<APIRespone<string>> DeletePhong(Guid id);
    }
}
