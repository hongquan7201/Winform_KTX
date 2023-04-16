﻿using System;
using System.Collections.Generic;

namespace ProjectQLKTX.Models;

public partial class Sinhvien
{
    public Guid Id { get; set; }
    public string? Email { get; set; }
    public string? GioiTinh { get; set; }

    public string MaSv { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Cccd { get; set; }

    public string? Sdt { get; set; }

    public bool? Gender { get; set; }

    public Guid? IdPhong { get; set; }

    public Guid? IdTruong { get; set; }

    public string? BirthDay { get; set; }

    public bool? Status { get; set; }

    public string? Code { get; set; }

    public DateTime? CreateAt { get; set; }
    /// <summary>
    /// //////////////////
    /// </summary>
    public string? TenThanNhan { get;set; }
    public string? BirthDayThanNhan { get; set; }
    public string? GioiTinhThanNhan { get; set; }
    public string? AddressThanNha { get; set; }
    public string? SDTThanNhan { get; set; }
    public string? QuanHe { get;set; }
/// <summary>
/// ////////
/// </summary>
    public string? Truong { get; set; }
    public string? Phong { get; set; }
    public string? Khu { get;set; }

    public virtual ICollection<Bienlai> Bienlais { get; } = new List<Bienlai>();

    public virtual ICollection<Hoadon> Hoadons { get; } = new List<Hoadon>();

    public virtual ICollection<Hopdong> Hopdongs { get; } = new List<Hopdong>();

    public virtual Phong? IdPhongNavigation { get; set; }

    public virtual Truong? IdTruongNavigation { get; set; }

    public virtual ICollection<Thannhan> Thannhans { get; } = new List<Thannhan>();

    public virtual ICollection<Xe> Xes { get; } = new List<Xe>();
}
