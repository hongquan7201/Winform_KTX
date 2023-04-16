using System;
using System.Collections.Generic;

namespace ProjectQLKTX.Models;

public partial class Bienlai
{
    public Guid Id { get; set; }

    public Guid? IdNhanVien { get; set; }

    public Guid? IdSinhVien { get; set; }

    public DateTime? NgayDong { get; set; }

    public DateTime NgayBatDau { get; set; }

    public DateTime? NgayHetHan { get; set; }

    public decimal? Total { get; set; }

    public bool? Status { get; set; }

    public virtual Nhanvien? IdNhanVienNavigation { get; set; }

    public virtual Sinhvien? IdSinhVienNavigation { get; set; }
}
