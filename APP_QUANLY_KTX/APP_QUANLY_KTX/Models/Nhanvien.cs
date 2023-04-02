namespace ProjectQLKTX.Models;

public  class Nhanvien
{
    public Guid id { get; set; }

    public string email { get; set; } = null!;

    public string password { get; set; } = null!;

    public string name { get; set; } = null!;

    public string address { get; set; } = null!;

    public string cccd { get; set; } = null!;

    public string sdt { get; set; } = null!;

    public bool? gender { get; set; }

    public DateTime? createAt { get; set; }

    public bool? status { get; set; }

    public Guid? idRole { get; set; }

    public  ICollection<Bienlai> bienlais { get; } = new List<Bienlai>();

    public  ICollection<Chitietphieukho> chitietphieukhos { get; } = new List<Chitietphieukho>();

    public  ICollection<Hopdong> hopdongs { get; } = new List<Hopdong>();

    public  Role? idRoleNavigation { get; set; }
}
