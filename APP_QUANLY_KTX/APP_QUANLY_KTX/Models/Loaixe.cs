namespace ProjectQLKTX.Models;

public  class Loaixe
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public  ICollection<Xe> Xes { get; } = new List<Xe>();
}
