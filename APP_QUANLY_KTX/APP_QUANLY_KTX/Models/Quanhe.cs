namespace ProjectQLKTX.Models;

public class Quanhe
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public  ICollection<Thannhan> Thannhans { get; } = new List<Thannhan>();
}
