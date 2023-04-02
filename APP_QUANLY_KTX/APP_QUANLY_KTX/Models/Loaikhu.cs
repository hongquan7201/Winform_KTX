namespace ProjectQLKTX.Models;

public class Loaikhu
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public  ICollection<Khu> Khus { get; } = new List<Khu>();
}
