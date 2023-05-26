using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IBienLaiHelper
    {
        Task<APIRespone<List<Bienlai>>> GetListBienLai(string token);
        Task<APIRespone<List<Bienlai>>> GetBienLai(Guid id, string token);
        Task<APIRespone<string>> AddBienLai(Bienlai bienLai, string token);
        Task<APIRespone<string>> EditBienLai(Bienlai bienLai, string token);
        Task<APIRespone<string>> DeleteBienLai(Guid id, string token);
    }
}
