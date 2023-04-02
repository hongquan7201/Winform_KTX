namespace ProjectQLKTX.Models;

public class Phieukho
{
    public Guid Id { get; set; }

    public bool? Status { get; set; }

    public bool? Type { get; set; }

    public Guid? IdKho { get; set; }

    public  ICollection<Chitietphieukho> Chitietphieukhos { get; } = new List<Chitietphieukho>();

    public  Kho? IdKhoNavigation { get; set; }
}
