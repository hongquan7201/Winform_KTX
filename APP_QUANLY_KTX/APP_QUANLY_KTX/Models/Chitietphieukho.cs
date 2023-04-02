using System;
using System.Collections.Generic;

namespace ProjectQLKTX.Models;

public class Chitietphieukho
{
    public Guid Id { get; set; }

    public int? Quatity { get; set; }

    public bool? Status { get; set; }

    public Guid? IdVatDung { get; set; }

    public Guid? IdPhieuKho { get; set; }

    public Guid? IdNhanVien { get; set; }

    public  Nhanvien? IdNhanVienNavigation { get; set; }

    public  Phieukho? IdPhieuKhoNavigation { get; set; }

    public  Vatdung? IdVatDungNavigation { get; set; }
}
