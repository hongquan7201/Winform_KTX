namespace ProjectQLKTX.Models;

public class Bienlai
{
    public Guid Id { get; set; }

    public decimal? Total { get; set; }

    public Guid? IdNhanVien { get; set; }

    public Guid? IdPhieuGiaHan { get; set; }

    public DateTime? CreateAt { get; set; }

    public  Nhanvien? IdNhanVienNavigation { get; set; }

    public  Phieugiahan? IdPhieuGiaHanNavigation { get; set; }
}
