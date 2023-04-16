using System;
using System.Collections.Generic;

namespace ProjectQLKTX.Models;

public partial class Hopdong
{
    public Guid Id { get; set; }

    public Guid? IdNhanVien { get; set; }

    public Guid? IdSinhVien { get; set; }

    public Guid? IdPhong { get; set; }

    public DateTime? NgayBatDau { get; set; }

    public DateTime? NgayKetThuc { get; set; }

    public DateTime? CreateAt { get; set; }

    public virtual Nhanvien? IdNhanVienNavigation { get; set; }

    public virtual Phong? IdPhongNavigation { get; set; }

    public virtual Sinhvien? IdSinhVienNavigation { get; set; }
}
