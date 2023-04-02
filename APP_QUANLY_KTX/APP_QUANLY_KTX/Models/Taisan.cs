namespace ProjectQLKTX.Models;

public class Taisan
{
    public Guid Id { get; set; }

    public int? Quatity { get; set; }

    public bool? Status { get; set; }

    public Guid? IdVatDung { get; set; }

    public  Vatdung? IdVatDungNavigation { get; set; }
}
