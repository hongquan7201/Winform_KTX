using System;
using System.Collections.Generic;

namespace ProjectQLKTX.Models;

public partial class Hoadon
{
    public Guid Id { get; set; }

    public Guid? IdSinhVien { get; set; }

    public Guid? IdNhanVien { get; set; }

    public Guid? IdPhong { get; set; }

    public Guid? IdLoai { get; set; }

    public DateTime? CreateAt { get; set; }

    public decimal? Total { get; set; }

    public bool? Status { get; set; }

}
