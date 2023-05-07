using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface ILoaiVatDungHelper
    {
        Task<APIRespone<List<Loaivatdung>>> GetListLoaiVatDung(string token);
        Task<APIRespone<Loaivatdung>> GetLoaiVatDung(Guid id, string token);
        Task<APIRespone<string>> AddLoaiVatDung(Loaivatdung loaiVatDung , string token);
        Task<APIRespone<string>> EditLoaiVatDung(Guid id, Loaivatdung loaiVatDung, string token);
        Task<APIRespone<string>> DeleteLoaiVatDung(Guid id, string token);
    }
}
