namespace ProjectQLKTX.Models;

public  class Loaivatdung
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public  ICollection<Vatdung> Vatdungs { get; } = new List<Vatdung>();
}
