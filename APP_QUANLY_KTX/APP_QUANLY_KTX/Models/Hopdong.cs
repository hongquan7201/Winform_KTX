using System;
using System.Collections.Generic;

namespace ProjectQLKTX.Models;

public partial class Hopdong
{
    public Guid Id { get; set; }

    public Guid? IdNhanVien { get; set; }
    public int? STT { get; set; }
    public Guid? IdSinhVien { get; set; }
    public string? NameNhanVien { get; set; }
    public string? NameSinhVien { get; set; }
    public string? EmailNhanVien { get; set; }
    public string? MaSinhVien { get; set; }
    public string? EmailSinhVien { get; set; }
    public string? Phong { get;set; }
    public Guid? IdPhong { get; set; }

    public DateTime? NgayBatDau { get; set; }

    public DateTime? NgayKetThuc { get; set; }

    public DateTime? CreateAt { get; set; }
}
