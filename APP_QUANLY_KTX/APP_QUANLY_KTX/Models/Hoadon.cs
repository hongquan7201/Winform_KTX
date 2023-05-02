namespace ProjectQLKTX.Models;

public partial class Hoadon
{
    public Guid Id { get; set; }

    public Guid? IdSinhVien { get; set; }

    public Guid? IdNhanVien { get; set; }

    public Guid? IdPhong { get; set; }

    public Guid? IdChiTietCongTo { get; set; }

    public DateTime? CreateAt { get; set; }

    public decimal? Total { get; set; }

    public bool? Status { get; set; }
    public string? TrangThai { get; set; }
    public string? NameSinhVien { get; set; }
    public string? NameNhanVien { get; set; }
    public string? NamePhong { get; set; }
    public string? NameKhu { get;set; }
    public string? EmailSinhVien { get; set; }
    public string? MaSinhVien { get; set; }
    public string? EmailNhanVien { get; set; }
    public int? STT { get; set; }
}
