using ProjectQLKTX.Models;

namespace ProjectQLKTX.Interface
{
    public interface IVatDungHelper
    {
        Task GetListVatDung();
        Task GetVatDung(Guid id);
        Task AddVatDung(Vatdung vatDung);
        Task EditVatDung(Vatdung vatDung);
        Task DeleteVatDung(Guid id);
    }
}
