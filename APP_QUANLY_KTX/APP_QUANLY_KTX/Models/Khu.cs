namespace ProjectQLKTX.Models;

public class Khu
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? Status { get; set; }

    public Guid? IdLoaiKhu { get; set; }

    public  Loaikhu? IdLoaiKhuNavigation { get; set; }

    public  ICollection<Phong> Phongs { get; } = new List<Phong>();

    public  ICollection<Xe> Xes { get; } = new List<Xe>();
}
