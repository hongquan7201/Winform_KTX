using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface ILoaiVatDungHelper
    {
        Task<APIRespone<List<Loaivatdung>>> GetListLoaiVatDung();
        Task<APIRespone<Loaivatdung>> GetLoaiVatDung(Guid id);
        Task<APIRespone<string>> AddLoaiVatDung(Loaivatdung loaiVatDung);
        Task<APIRespone<string>> EditLoaiVatDung(Guid id, Loaivatdung loaiVatDung);
        Task<APIRespone<string>> DeleteLoaiVatDung(Guid id);
    }
}
