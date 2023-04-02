using DevExpress.CodeParser;

namespace ProjectQLKTX.Models;

public partial class Hoadon
{
    public Guid Id { get; set; }

    public Guid? IdPhong { get; set; }

    public Guid? IdLoai { get; set; }

    public Guid? IdCongTo { get; set; }

    public DateTime? CreateAt { get; set; }

    public decimal? Total { get; set; }

    public bool? Status { get; set; }

    public virtual Const? IdCongToNavigation { get; set; }

    public virtual Loaihoadon? IdLoaiNavigation { get; set; }

    public virtual Phong? IdPhongNavigation { get; set; }
}
