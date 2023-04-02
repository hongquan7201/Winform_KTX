namespace ProjectQLKTX.Models;

public class Phieugiahan
{
    public Guid Id { get; set; }

    public DateTime? DayStart { get; set; }

    public DateTime? DayEnd { get; set; }

    public bool? Status { get; set; }

    public Guid? IdUser { get; set; }

    public Guid? IdHopDong { get; set; }

    public  ICollection<Congto> HoaDons { get; } = new List<Congto>();

    public  Hopdong? IdHopDongNavigation { get; set; }

    public  Sinhvien? IdUserNavigation { get; set; }
}
