namespace ProjectQLKTX.Models;

public  class Truong
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public  ICollection<Sinhvien> Sinhviens { get; } = new List<Sinhvien>();
}
