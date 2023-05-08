using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IVatDungHelper
    {
        Task<APIRespone<List<Vatdung>>> GetListVatDung(string token);
        Task<APIRespone<List<Vatdung>>> GetVatDung(Guid? id, string token);
        Task<APIRespone<string>> AddVatDung(Vatdung vatDung, string token);
        Task<APIRespone<string>> EditVatDung(Vatdung vatDung, string token);
        Task<APIRespone<string>> DeleteVatDung(Guid id, string token);
    }
}
