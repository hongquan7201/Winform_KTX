using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IVatDungHelper
    {
        Task<APIRespone<List<Vatdung>>> GetListVatDung();
        Task<APIRespone<List<Vatdung>>> GetVatDung(Guid? id);
        Task<APIRespone<string>> AddVatDung(Vatdung vatDung);
        Task<APIRespone<string>> EditVatDung(Vatdung vatDung);
        Task<APIRespone<string>> DeleteVatDung(Guid id);
    }
}
