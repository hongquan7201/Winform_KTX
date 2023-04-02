namespace ProjectQLKTX.Models;

public  class Role
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public  ICollection<Nhanvien> Nhanviens { get; } = new List<Nhanvien>();
}
