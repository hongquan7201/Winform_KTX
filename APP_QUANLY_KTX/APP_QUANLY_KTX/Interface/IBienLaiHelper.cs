using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IBienLaiHelper
    {
        Task<APIRespone<List<Bienlai>>> GetListBienLai();
        Task<APIRespone<Bienlai>> GetBienLai(Guid id);
        Task<APIRespone<string>> AddBienLai(Bienlai bienLai);
        Task<APIRespone<string>> EditBienLai(Guid id,Bienlai bienLai);
        Task<APIRespone<string>> DeleteBienLai(Guid id);
    }
}
