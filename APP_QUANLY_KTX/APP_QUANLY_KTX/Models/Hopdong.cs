namespace ProjectQLKTX.Models;

public  class Hopdong
{
    public Guid Id { get; set; }

    public DateTime? CreateAt { get; set; }

    public Guid? IdNhanVien { get; set; }

    public  Nhanvien? IdNhanVienNavigation { get; set; }

    public  ICollection<Phieugiahan> Phieugiahans { get; } = new List<Phieugiahan>();

    public  ICollection<Sinhvien> Sinhviens { get; } = new List<Sinhvien>();
}
