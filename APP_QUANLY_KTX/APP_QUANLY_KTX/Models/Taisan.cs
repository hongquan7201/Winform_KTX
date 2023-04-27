using System;
using System.Collections.Generic;

namespace ProjectQLKTX.Models;

public partial class Taisan
{
    public Guid Id { get; set; }
    public string? NameVatDung { get; set; }
    public string? NamePhong { get; set; }
    public int? Quantity { get; set; }
    public int? STT { get; set; }
    public bool? Status { get; set; }
    public Guid? IdVatDung { get; set; }
    public string? TinhTrang { get; set; }
    public Guid IdPhong { get; set; }

}
