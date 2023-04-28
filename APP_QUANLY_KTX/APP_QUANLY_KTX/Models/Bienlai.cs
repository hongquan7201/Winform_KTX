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
    public decimal? TienPhong { get;set; }
    public decimal? TienXe { get; set; }
    public decimal? Total { get; set; }
    public bool? Status { get; set; }
    public string? NameSinhVien { get; set; }
    public string? MaSinhVien { get; set; }
    public string? GioiTinhSV { get;set; }
    public string? SdtSV { get;set; }
    public string? NgaySinhSV { get; set; }
    public string? EmailSV { get;set; }
    public string? CCCD { get;set; }
    public string? Phong { get; set; }
    public string? Khu { get; set; }
    public string? NameNhanVien { get; set; }
    public int? STT { get; set; }
    public string? EmailNV { get; set; }
    public string? TrangThai { get;set; }
}
