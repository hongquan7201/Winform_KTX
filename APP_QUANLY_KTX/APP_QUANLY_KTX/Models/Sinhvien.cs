namespace ProjectQLKTX.Models;

public class Sinhvien
{
    public Guid Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Cccd { get; set; }

    public string? Sdt { get; set; }

    public bool? Gender { get; set; }

    public Guid? IdPhong { get; set; }

    public Guid? IdTruong { get; set; }

    public int? Warning { get; set; }

    public DateTime? BirthDay { get; set; }

    public Guid? IdHopDong { get; set; }

    public bool? Status { get; set; }

    public string? Code { get; set; }

    public DateTime? CreateAt { get; set; }

    public  Hopdong? IdHopDongNavigation { get; set; }

    public  Phong? IdPhongNavigation { get; set; }

    public  Truong? IdTruongNavigation { get; set; }

    public  ICollection<Phieugiahan> Phieugiahans { get; } = new List<Phieugiahan>();

    public  ICollection<Thannhan> Thannhans { get; } = new List<Thannhan>();

    public  ICollection<Xe> Xes { get; } = new List<Xe>();
}
