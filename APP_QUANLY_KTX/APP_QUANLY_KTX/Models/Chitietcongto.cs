namespace ProjectQLKTX.Models;

public partial class Chitietcongto
{
    public Guid Id { get; set; }
    public int? STT { get; set; }
    public int ChiSoDienDauThang { get; set; }

    public int ChiSoDienCuoiThang { get; set; }

    public int ChiSoNuocDauThang { get; set; }

    public int ChiSoNuocCuoiThang { get; set; }
    public int? SoDienTieuThu { get; set; }
    public int? SoNuocTieuThu { get; set; }
    public decimal? TienDien { get; set; }
    public decimal? TienNuoc { get; set; }
    public decimal? Total { get; set; }
    public DateTime CreateAt { get; set; }
    public Guid? IdPhong { get; set; }
    public Guid? IdKhu { get; set; }
    public string? NamePhong { get; set; }
    public string? NameKhu { get; set; }
    public string? NameCongTo { get; set; }
    public Guid? IdCongTo { get; set; }
}
