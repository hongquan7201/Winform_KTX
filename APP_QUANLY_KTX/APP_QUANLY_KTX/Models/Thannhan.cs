namespace ProjectQLKTX.Models;

public  class Thannhan
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Sdt { get; set; } = null!;

    public bool? Gender { get; set; }

    public Guid? IdUser { get; set; }

    public Guid? IdQuanHe { get; set; }

    public  Quanhe? IdQuanHeNavigation { get; set; }

    public  Sinhvien? IdUserNavigation { get; set; }
}
