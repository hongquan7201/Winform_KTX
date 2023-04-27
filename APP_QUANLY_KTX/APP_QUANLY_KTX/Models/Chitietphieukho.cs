using System;
using System.Collections.Generic;

namespace ProjectQLKTX.Models;

public partial class Chitietphieukho
{
    public Guid Id { get; set; }

    public int? Quantity { get; set; }
    public int? STT { get; set; }
    public bool? Status { get; set; }
    public string? NameVatDung { get; set; }
    public string? NameNhanVien { get; set; }
    public Guid? IdVatDung { get; set; }

    public Guid? IdPhieuKho { get; set; }

    public Guid? IdNhanVien { get; set; }
    public string? TinhTrang { get; set; }
}
