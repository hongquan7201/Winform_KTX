namespace ProjectQLKTX.Models;

public class Kho
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? Status { get; set; }

    public  ICollection<Phieukho> Phieukhos { get; } = new List<Phieukho>();

    public  ICollection<Vatdung> Vatdungs { get; } = new List<Vatdung>();
}
