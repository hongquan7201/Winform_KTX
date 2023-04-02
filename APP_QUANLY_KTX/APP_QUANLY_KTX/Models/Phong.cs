namespace ProjectQLKTX.Models;

public  class Phong
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? Status { get; set; }

    public int? QuatityPeople { get; set; }

    public Guid? IdHoaDon { get; set; }

    public Guid? IdKhu { get; set; }

    public  ICollection<Hoadon> Hoadons { get; } = new List<Hoadon>();

    public  Congto? IdHoaDonNavigation { get; set; }

    public  Khu? IdKhuNavigation { get; set; }

    public  ICollection<Sinhvien> Sinhviens { get; } = new List<Sinhvien>();
}
