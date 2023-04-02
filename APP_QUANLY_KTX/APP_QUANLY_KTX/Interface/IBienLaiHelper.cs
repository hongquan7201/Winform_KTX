using ProjectQLKTX.APIsHelper;
using ProjectQLKTX.APIsHelper.BienLaiHelper;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IBienLaiHelper
    {
        Task<BienLaiResponse<ListBienLaiResult>> GetListBienLai();
        Task<BienLaiResponse<Bienlai>> GetBienLai(Guid id);
        Task<APIReponse> AddBienLai(Bienlai bienLai);
        Task<APIReponse> EditBienLai(Guid id,Bienlai bienLai);
        Task<APIReponse> DeleteBienLai(Guid id);
    }
}
