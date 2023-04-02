namespace ProjectQLKTX.Models;

public class Congto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public  ICollection<Chitietcongto> Chitietcongtos { get; } = new List<Chitietcongto>();

    public  ICollection<Congto> Congtos { get; } = new List<Congto>();

    public  ICollection<Phong> Phongs { get; } = new List<Phong>();
}
