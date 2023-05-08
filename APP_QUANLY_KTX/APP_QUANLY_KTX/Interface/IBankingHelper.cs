using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IBankingHelper
    {
        Task<APIRespone<List<Banking>>> GetListBanking(string token);
        Task<APIRespone<string>> AddBanking(Banking banking, string token);
        Task<APIRespone<Banking>> GetBankingByCode(string code, string token);
    }
}
