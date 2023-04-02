namespace ProjectQLKTX.Models;

public  class Vatdung
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Quatity { get; set; }

    public bool? Status { get; set; }

    public Guid? IdLoaiVatDung { get; set; }

    public Guid? IdKho { get; set; }

    public  ICollection<Chitietphieukho> Chitietphieukhos { get; } = new List<Chitietphieukho>();

    public  Kho? IdKhoNavigation { get; set; }

    public  Loaivatdung? IdLoaiVatDungNavigation { get; set; }

    public  ICollection<Taisan> Taisans { get; } = new List<Taisan>();
}
