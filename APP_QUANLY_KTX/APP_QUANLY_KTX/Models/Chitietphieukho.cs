using System;
using System.Collections.Generic;

namespace ProjectQLKTX.Models;

public partial class Chitietphieukho
{
    public Guid Id { get; set; }

    public int? Quantity { get; set; }

    public bool? Status { get; set; }

    public Guid? IdVatDung { get; set; }

    public Guid? IdPhieuKho { get; set; }

    public Guid? IdNhanVien { get; set; }

    public virtual Nhanvien? IdNhanVienNavigation { get; set; }

    public virtual Phieukho? IdPhieuKhoNavigation { get; set; }

    public virtual Vatdung? IdVatDungNavigation { get; set; }
}
