namespace ProjectQLKTX.Models;

public class Loaihoadon
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public  ICollection<Hoadon> Hoadons { get; } = new List<Hoadon>();
}
